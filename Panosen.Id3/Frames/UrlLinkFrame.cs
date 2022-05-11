using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    public class UrlLinkFrame : Id3FrameWithEncoding
    {
        public string Url { get; set; }
    }
    public class UrlLinkFrameHandler : FrameHandler<UrlLinkFrame>
    {
        protected override void OnEncode(UrlLinkFrame frame, List<byte> bytes)
        {
            if (string.IsNullOrEmpty(frame.Url))
            {
                return;
            }

            bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.Url));
        }

        protected override void OnDecode(byte[] bytes, UrlLinkFrame frame)
        {
            frame.Url = Id3Encoding.ISO88591.GetString(bytes, 0, bytes.Length);
        }
    }
}
