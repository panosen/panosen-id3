using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    public sealed class CustomUrlLinkFrame : UrlLinkFrame
    {
        public string Description { get; set; }
    }

    public class CustomUrlLinkHandler : FrameHandler<CustomUrlLinkFrame>
    {
        protected override void OnEncode(CustomUrlLinkFrame frame, List<byte> bytes)
        {
            //bytes.AddRange(frame.Encoding.GetPreamble());
            if (!string.IsNullOrEmpty(frame.Description))
            {
                bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.Description));
            }
            //bytes.AddRange(TextEncodingHelper.GetSplitterBytes(frame.Encoding));
            if (frame.Url != null)
            {
                bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.Url));
            }
        }

        protected override void OnDecode(byte[] bytes, CustomUrlLinkFrame frame)
        {
            //byte[][] splitBytes = ByteArrayHelper.SplitBySequence(bytes, 1, bytes.Length - 1, TextEncodingHelper.GetSplitterBytes(frame.Encoding));

            //if (splitBytes.Length > 1)
            //{
            //    frame.Description = TextEncodingHelper.GetString(splitBytes[0], 0, splitBytes[0].Length, frame.Encoding);
            //    frame.Url = TextEncodingHelper.GetDefaultString(splitBytes[1], 0, splitBytes[1].Length);
            //}
            //else if (splitBytes.Length == 1)
            //{
            //    frame.Url = TextEncodingHelper.GetDefaultString(splitBytes[0], 0, splitBytes[0].Length);
            //}
        }
    }
}