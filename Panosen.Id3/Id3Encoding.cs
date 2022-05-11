using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    /// <summary>
    /// ID3支持的编码
    /// </summary>
    public enum Id3EncodingEnum
    {
        /// <summary>
        /// iso-8859-1
        /// </summary>
        ISO88591,

        /// <summary>
        /// unicode
        /// </summary>
        Unicode
    }

    /// <summary>
    /// ID3支持的编码
    /// </summary>
    public class Id3Encoding
    {
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// iso-8859-1
        /// </summary>
        public static Id3Encoding ISO88591 { get; } = new Id3Encoding { Encoding = Encoding.GetEncoding("iso-8859-1") };

        /// <summary>
        /// unicode
        /// </summary>
        public static Id3Encoding Unicode { get; } = new Id3Encoding { Encoding = Encoding.Unicode };
    }

    public static class Id3EncodingExtension
    {
        public static byte[] GetPreamble(this Id3Encoding id3Encoding)
        {
            return id3Encoding.Encoding.GetPreamble();
        }

        public static byte[] GetBytes(this Id3Encoding id3Encoding, string text)
        {
            return id3Encoding.Encoding.GetBytes(text);
        }

        public static string GetString(this Id3Encoding id3Encoding, byte[] bytes, int start, int count)
        {
            return id3Encoding.Encoding.GetString(bytes, start, count);
        }
    }
}
