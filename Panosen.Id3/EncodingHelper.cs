using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    public static class EncodingHelper
    {
        public static Id3Encoding DetectEncoding(byte[] bytes)
        {
            if (bytes[0] == 1 && bytes[1] == 0xFF && bytes[2] == 0xFE)
            {
                return Id3Encoding.Unicode;
            }
            if (bytes[0] == 0 && bytes[bytes.Length - 1] == 0)
            {
                return Id3Encoding.ISO88591;
            }
            return Id3Encoding.GB2312;
        }
    }
}
