using System;
using System.Collections.Generic;

namespace Panosen.Id3
{
    internal static class ByteArrayHelper
    {
        internal static bool AreEqual(byte[] bytes1, byte[] bytes2)
        {
            if (ReferenceEquals(bytes1, bytes2))
                return true;
            if (bytes1 == null || bytes2 == null)
                return false;
            if (bytes1.Length != bytes2.Length)
                return false;
            for (var i = 0; i < bytes1.Length; i++)
            {
                if (bytes1[i] != bytes2[i])
                    return false;
            }
            return true;
        }

        internal static byte[] GetBytesUptoSequence(byte[] bytes, int start, byte[] sequence)
        {
            int sequenceIndex = LocateSequence(bytes, start, bytes.Length - start + 1, sequence);
            if (sequenceIndex == -1)
                return null;
            var result = new byte[sequenceIndex - start];
            Array.Copy(bytes, start, result, 0, result.Length);
            return result;
        }

        internal static int LocateSequence(byte[] bytes, params byte[] sequence)
        {
            return LocateSequence(bytes, 0, bytes.Length, sequence);
        }

        internal static int LocateSequence(byte[] bytes, int start, int count, byte[] sequence)
        {
            int sequenceIndex = 0;
            int endIndex = Math.Min(bytes.Length, start + count);
            for (int byteIdx = start; byteIdx < endIndex; byteIdx++)
            {
                if (bytes[byteIdx] == sequence[sequenceIndex])
                {
                    sequenceIndex++;
                    if (sequenceIndex >= sequence.Length)
                        return byteIdx - sequence.Length + 1;
                } else
                    sequenceIndex = 0;
            }
            return -1;
        }

        internal static int[] LocateSequences(byte[] bytes, params byte[] sequence)
        {
            return LocateSequences(bytes, 0, bytes.Length, sequence);
        }

        internal static int[] LocateSequences(byte[] bytes, int start, int count, byte[] sequence)
        {
            var locations = new List<int>();

            int sequenceLocation = LocateSequence(bytes, start, count, sequence);
            while (sequenceLocation >= 0)
            {
                locations.Add(sequenceLocation);
                count -= sequenceLocation - start + 1;
                start = sequenceLocation + sequence.Length;
                sequenceLocation = LocateSequence(bytes, start, count, sequence);
            }

            return locations.ToArray();
        }

        internal static byte[][] SplitBySequence(byte[] bytes, params byte[] sequence)
        {
            return SplitBySequence(bytes, 0, bytes.Length, sequence);
        }

        internal static byte[][] SplitBySequence(byte[] bytes, int start, int count, byte[] sequence)
        {
            if (start + count > bytes.Length)
                count = bytes.Length - start;

            int[] locations = LocateSequences(bytes, start, count, sequence);
            if (locations.Length == 0)
                return new[] { bytes };

            var results = new List<byte[]>(locations.Length + 1);
            for (var locationIdx = 0; locationIdx < locations.Length; locationIdx++)
            {
                int startIndex = locationIdx > 0 ? locations[locationIdx - 1] + sequence.Length : start;
                int endIndex = locations[locationIdx] - 1;
                if (endIndex < startIndex)
                    results.Add(new byte[0]);
                else
                {
                    var splitBytes = new byte[endIndex - startIndex + 1];
                    Array.Copy(bytes, startIndex, splitBytes, 0, splitBytes.Length);
                    results.Add(splitBytes);
                }
            }

            if (locations[locations.Length - 1] + sequence.Length > start + count - 1)
                results.Add(new byte[0]);
            else
            {
                var splitBytes = new byte[start + count - locations[locations.Length - 1] - sequence.Length];
                Array.Copy(bytes, locations[locations.Length - 1] + sequence.Length, splitBytes, 0, splitBytes.Length);
                results.Add(splitBytes);
            }

            return results.ToArray();
        }
    }
}