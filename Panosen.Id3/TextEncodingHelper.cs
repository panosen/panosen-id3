using System.Diagnostics;
using System.Text;

namespace Panosen.Id3
{
    public static class TextEncodingHelper
    {
        ///////// <summary>
        ///////// iso-8859-1
        ///////// </summary>
        //////public static readonly Encoding ISO88591 = Encoding.GetEncoding("iso-8859-1");

        ///////// <summary>
        ///////// unicode
        ///////// </summary>
        //////public static readonly Encoding UNICODE = Encoding.Unicode;

        internal static string GetDefaultString(byte[] bytes, int start, int count)
        {
            return Id3Encoding.ISO88591.GetString(bytes, start, count);
        }

        internal static string GetString(byte[] bytes, int start, int count, Id3Encoding encoding)
        {
            string str = encoding.GetString(bytes, start, count);

            if (encoding == Id3Encoding.Unicode && (str[0] == '\xFFFE' || str[0] == '\xFEFF'))
            {
                str = str.Remove(0, 1);
            }

            return str;
        }

        internal static string[] GetSplitStrings(byte[] bytes, int start, int count, Id3Encoding encoding)
        {
            byte[][] splitBytes = ByteArrayHelper.SplitBySequence(bytes, start, count, GetSplitterBytes(encoding));
            if (splitBytes.Length == 0)
            {
                return new[] { string.Empty };
            }

            var strings = new string[splitBytes.Length];
            for (int splitByteIdx = 0; splitByteIdx < splitBytes.Length; splitByteIdx++)
            {
                strings[splitByteIdx] = GetString(splitBytes[splitByteIdx], 0, splitBytes[splitByteIdx].Length, encoding);
            }
            return strings;
        }

        internal static byte[] GetSplitterBytes(Id3Encoding encoding)
        {
            return new byte[GetSplitterLength(encoding)];
        }

        private static int GetSplitterLength(Id3Encoding encoding)
        {
            if (encoding ==Id3Encoding.ISO88591)
            {
                return 1;
            }
            if (encoding == Id3Encoding.Unicode)
            {
                return 2;
            }

            return -1;
        }
    }
}