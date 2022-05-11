using System.Collections.Generic;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// TextFrameHandler
    /// </summary>
    public class TposFrameHandler : FrameHandler<TextFrame>
    {
        /// <summary>
        /// OnEncode
        /// </summary>
        protected override void OnEncode(TextFrame frame, List<byte> bytes)
        {
            bytes.Add(0);

            bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.Value));

            if (frame.Hidden)
            {
                bytes.Add(0);
            }
        }

        /// <summary>
        /// OnDecode
        /// </summary>
        protected override void OnDecode(byte[] bytes, TextFrame frame)
        {
            frame.Encoding = Id3Encoding.ISO88591;

            var text = frame.Encoding.GetString(bytes, 1, bytes.Length - 1);

            frame.Hidden = text.EndsWith("\0");
            frame.Value = text.TrimEnd('\0');
        }
    }
}
