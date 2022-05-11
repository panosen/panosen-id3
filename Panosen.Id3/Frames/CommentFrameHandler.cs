using System.Collections.Generic;
using System.Text;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// 评论
    /// </summary>
    public class CommentFrameHandler : FrameHandler<CommentFrame>
    {
        /// <summary>
        /// 编码
        /// </summary>
        protected override void OnEncode(CommentFrame frame, List<byte> bytes)
        {
            EncodeEncoding(frame, bytes);

            bytes.AddRange(Encoding.ASCII.GetBytes(frame.Language));

            if (!string.IsNullOrEmpty(frame.Short))
            {
                bytes.AddRange(frame.Encoding.GetBytes(frame.Short));
            }
            else if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.AddRange(Encoding.Unicode.GetPreamble());
            }

            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.Add(0);
                bytes.Add(0);
            }
            else if (frame.Encoding == Id3Encoding.ISO88591)
            {
                bytes.Add(0);
            }

            if (!string.IsNullOrEmpty(frame.Content))
            {
                bytes.AddRange(frame.Encoding.GetBytes(frame.Content));
            }

            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.Add(0);
                bytes.Add(0);
            }
        }

        /// <summary>
        /// 解码
        /// </summary>
        protected override void OnDecode(byte[] bytes, CommentFrame frame)
        {
            frame.Encoding = DecodeEncoding(bytes);

            frame.Language = Encoding.ASCII.GetString(bytes, 1, 3);

            var index = 4;
            var length = 0;
            if (frame.Encoding == Id3Encoding.Unicode)
            {
                if (bytes[index] == 0xFF && bytes[index + 1] == 0xFE)
                {
                    index = 6;
                }
                while (index + length < bytes.Length)
                {
                    if (bytes[index + length] == 0 && bytes[index + length + 1] == 0)
                    {
                        break;
                    }
                    length += 2;
                }
                frame.Short = frame.Encoding.GetString(bytes, index, length);
                frame.Content = frame.Encoding.GetString(bytes, index + length + 2, bytes.Length - index - length - 4);
            }
            else
            {
                while (index < bytes.Length)
                {
                    if (bytes[index + length] == 0)
                    {
                        break;
                    }
                    length++;
                }
                frame.Short = frame.Encoding.GetString(bytes, index, length);
                frame.Content = frame.Encoding.GetString(bytes, index + length + 1, bytes.Length - index - length - 1);
            }
        }

        /// <summary>
        /// 解码Encoding
        /// </summary>
        private Id3Encoding DecodeEncoding(byte[] bytes)
        {
            if (bytes[0] == 1)
            {
                return Id3Encoding.Unicode;
            }
            else
            {
                return Id3Encoding.ISO88591;
            }
        }

        /// <summary>
        /// 解码Encoding
        /// </summary>
        private void EncodeEncoding(CommentFrame frame, List<byte> bytes)
        {
            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.Add(1);
            }
            else
            {
                bytes.Add(0);
            }
        }
    }
}