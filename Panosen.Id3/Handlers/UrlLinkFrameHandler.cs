using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Handlers
{
    public class UrlLinkFrameHandler : FrameHandler<UrlLinkFrame>
    {
        protected override void OnEncode(UrlLinkFrame frame, List<byte> bytes)
        {
            if (string.IsNullOrEmpty(frame.Url))
            {
                bytes.Add(0);
                return;
            }

            bytes.AddRange(frame.Encoding.GetBytes(frame.Url));
        }


        protected override void OnDecode(byte[] bytes, UrlLinkFrame frame)
        {
            frame.Url = frame.Encoding.GetString(bytes, 0, bytes.Length);
        }
    }
}
