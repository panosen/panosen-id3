using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    /// <summary>
    /// StreamExtension
    /// </summary>
    public static class StreamExtension
    {
        /// <summary>
        /// ReadBytes
        /// </summary>
        public static byte[] ReadBytes(this Stream stream, int count)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (count == 0)
            {
                return new byte[0];
            }

            byte[] result = new byte[count];
            int length = stream.Read(result, 0, count);

            if (length != result.Length)
            {
                byte[] copy = new byte[length];
                Array.Copy(result, copy, length);
                result = copy;
            }

            return result;
        }

        /// <summary>
        /// Write
        /// </summary>
        public static void WriteByte(this Stream stream, byte value)
        {
            stream.Write(new byte[1] { value }, 0, 1);
        }

        /// <summary>
        /// Write
        /// </summary>
        public static void WriteInt32(this Stream stream, int value)
        {
            var bytes = new byte[4];
            bytes[0] = (byte)value;
            bytes[1] = (byte)(value >> 8);
            bytes[2] = (byte)(value >> 16);
            bytes[3] = (byte)(value >> 24);
            stream.Write(bytes, 0, 4);
        }

        /// <summary>
        /// Write
        /// </summary>
        public static void WriteBytes(this Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
