using System.Collections.Generic;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// TextFrameHandler
    /// </summary>
    public class TextFrameHandler : FrameHandler<TextFrame>
    {
        /// <summary>
        /// OnEncode
        /// </summary>
        protected override void OnEncode(TextFrame frame, List<byte> bytes)
        {
            EncodeEncoding(frame, bytes);

            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.AddRange(frame.Encoding.GetPreamble());
            }

            bytes.AddRange(frame.Encoding.GetBytes(frame.Value));

            AppendZeroBytes(frame.Encoding, bytes);
        }

        /// <summary>
        /// AppendZeroBytes
        /// </summary>
        private static void AppendZeroBytes(Id3Encoding encoding, List<byte> bytes)
        {
            if (encoding == Id3Encoding.Unicode)
            {
                bytes.Add(0);
                bytes.Add(0);
            }
            else if (encoding == Id3Encoding.ISO88591)
            {
                bytes.Add(0);
            }
        }

        /// <summary>
        /// OnDecode
        /// </summary>
        protected override void OnDecode(byte[] bytes, TextFrame frame)
        {
            frame.Encoding = EncodingHelper.DetectEncoding(bytes);

            if (frame.Encoding == Id3Encoding.Unicode)
            {
                var startSize = 1;
                if (bytes[1] == 0xFF && bytes[2] == 0xFE)
                {
                    startSize = 3;
                }
                var endSize = 0;
                if (bytes[bytes.Length - 1] == 0 && bytes[bytes.Length - 2] == 0)
                {
                    endSize = 2;
                }
                frame.Value = frame.Encoding.GetString(bytes, startSize, bytes.Length - startSize - endSize);
            }
            else if (frame.Encoding == Id3Encoding.GB2312)
            {
                frame.Value = frame.Encoding.GetString(bytes, 1, bytes.Length - 1);
            }
            else
            {
                frame.Value = frame.Encoding.GetString(bytes, 1, bytes.Length - 1);
            }
        }

        /// <summary>
        /// 编码Encoding
        /// </summary>
        protected void EncodeEncoding(TextFrame frame, List<byte> bytes)
        {
            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.Add(1);
            }
            else if (frame.Encoding == Id3Encoding.ISO88591)
            {
                bytes.Add(0);
            }
            else if (frame.Encoding == Id3Encoding.GB2312)
            {
                bytes.Add(0);
            }
        }
    }
}
