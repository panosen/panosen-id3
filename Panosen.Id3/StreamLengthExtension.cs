using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    /// <summary>
    /// StreamExtensionV1
    /// </summary>
    public static class StreamLengthExtension
    {

        /// <summary>
        /// 获取 id3v1 长度
        /// </summary>
        public static int GetV1TagLength(this Stream stream)
        {
            if (stream.Length < 128)
            {
                return 0;
            }

            stream.Seek(-128, SeekOrigin.End);
            byte[] magicBytes = new byte[3];
            stream.Read(magicBytes, 0, 3);
            string magic = Encoding.ASCII.GetString(magicBytes, 0, 3);
            if (magic == "TAG")
            {
                return 128;
            }

            return 0;
        }


        /// <summary>
        /// 获取 id3v2 长度
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int GetV2TagLength(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            var bytes = new byte[10];
            stream.Read(bytes, 0, 10);

            if (bytes[0] != 0x49 || bytes[1] != 0x44 || bytes[2] != 0x33)
            {
                return 0;
            }

            return Bytes.ToInt32Safe(bytes, 6, 4) + 10;
        }
    }
}
