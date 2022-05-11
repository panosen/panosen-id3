namespace Panosen.Id3
{
    public static class SyncSafeNumber
    {

        public static byte[] EncodeNormal(int size)
        {
            var bytes = new byte[4];
            bytes[3] = (byte)(size & 0xFF);
            bytes[2] = (byte)((size >> 8) & 0xFF);
            bytes[1] = (byte)((size >> 16) & 0xFF);
            bytes[0] = (byte)((size >> 24) & 0xFF);
            return bytes;
        }

        public static int DecodeNormal(byte[] bytes, int start, int count)
        {
            int size = 0, shift = 0;
            for (int byteIdx = start + count - 1; byteIdx >= start; byteIdx--)
            {
                size += bytes[byteIdx] << shift;
                shift += 8;
            }
            return size;
        }

        public static byte[] EncodeSafe(int size)
        {
            var bytes = new byte[4];
            bytes[3] = (byte)(size & 0x7F);
            bytes[2] = (byte)((size >> 7) & 0x7F);
            bytes[1] = (byte)((size >> 14) & 0x7F);
            bytes[0] = (byte)((size >> 21) & 0x7F);
            return bytes;
        }

        internal static int DecodeSafe(byte[] bytes, int start, int count)
        {
            int size = 0, shift = 0;
            for (int byteIdx = start + count - 1; byteIdx >= start; byteIdx--)
            {
                size += bytes[byteIdx] << shift;
                shift += 7;
            }
            return size;
        }
    }
}