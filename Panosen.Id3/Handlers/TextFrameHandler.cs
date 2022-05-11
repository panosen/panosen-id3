using Panosen.Id3.Frames;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Id3.Handlers
{
    public class TextFrameHandler : FrameHandler<TextFrame>
    {

        protected override void OnEncode(TextFrame frame, List<byte> bytes)
        {
            byte[] preamble = frame.Encoding.GetPreamble();
            byte[] textBytes = frame.Encoding.GetBytes(frame.Value);

            bytes.AddRange(preamble);
            bytes.AddRange(textBytes);
        }

        protected override void OnDecode(byte[] bytes, TextFrame frame)
        {
            if (frame.Encoding == Id3Encoding.Unicode)
            {
                frame.Value = frame.Encoding.GetString(bytes, 3, bytes.Length - 5);
            }
            else
            {
                frame.Value = frame.Encoding.GetString(bytes, 1, bytes.Length - 2);
            }
        }
    }
}
