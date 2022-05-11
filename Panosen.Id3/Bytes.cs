namespace Panosen.Id3
{
    /// <summary>
    /// Bytes
    /// </summary>
    public static class Bytes
    {

        /// <summary>
        /// FromInt32Normal
        /// </summary>
        public static byte[] FromInt32Normal(int size)
        {
            var bytes = new byte[4];
            bytes[3] = (byte)(size & 0xFF);
            bytes[2] = (byte)((size >> 8) & 0xFF);
            bytes[1] = (byte)((size >> 16) & 0xFF);
            bytes[0] = (byte)((size >> 24) & 0xFF);
            return bytes;
        }

        /// <summary>
        /// ToInt32Normal
        /// </summary>
        public static int ToInt32Normal(byte[] bytes, int start, int count)
        {
            int size = 0, shift = 0;
            for (int byteIdx = start + count - 1; byteIdx >= start; byteIdx--)
            {
                size += bytes[byteIdx] << shift;
                shift += 8;
            }
            return size;
        }

        /// <summary>
        /// int ת byte[]
        /// </summary>
        public static byte[] FromInt32Safe(int size)
        {
            var bytes = new byte[4];
            bytes[3] = (byte)(size & 0x7F);
            bytes[2] = (byte)((size >> 7) & 0x7F);
            bytes[1] = (byte)((size >> 14) & 0x7F);
            bytes[0] = (byte)((size >> 21) & 0x7F);
            return bytes;
        }

        /// <summary>
        /// byte[] ת int
        /// </summary>
        public static int ToInt32Safe(byte[] bytes, int start, int count)
        {
            int size = 0, shift = 0;
            for (int index = start + count - 1; index >= start; index--)
            {
                size += bytes[index] << shift;
                shift += 7;
            }
            return size;
        }
    }
}