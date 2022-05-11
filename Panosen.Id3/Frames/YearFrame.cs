using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    public sealed class YearFrame : Id3FrameWithEncoding
    {
        public string Value { get; set; }
    }

    public class YearFrameHandler : FrameHandler<YearFrame>
    {
        protected override void OnEncode(YearFrame frame, List<byte> bytes)
        {
            bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.Value));
        }

        protected override void OnDecode(byte[] bytes, YearFrame frame)
        {
            frame.Value = Id3Encoding.ISO88591.GetString(bytes, 0, bytes.Length);
        }
    }
}
