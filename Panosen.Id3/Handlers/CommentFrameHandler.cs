using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Handlers
{
    public class CommentFrameHandler : FrameHandler<CommentFrame>
    {
        protected override void OnEncode(CommentFrame frame, List<byte> bytes)
        {
            bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.Language.ToString()));

            bytes.AddRange(frame.Encoding.GetPreamble());
            if (!string.IsNullOrEmpty(frame.Description))
            {
                bytes.AddRange(frame.Encoding.GetBytes(frame.Description));
            }
            bytes.AddRange(TextEncodingHelper.GetSplitterBytes(frame.Encoding));
            bytes.AddRange(frame.Encoding.GetPreamble());
            if (!string.IsNullOrEmpty(frame.Comment))
            {
                bytes.AddRange(frame.Encoding.GetBytes(frame.Comment));
            }
        }

        protected override void OnDecode(byte[] bytes, CommentFrame frame)
        {
            string language = Id3Encoding.ISO88591.GetString(bytes, 1, 3).ToLowerInvariant();
            if (!Enum.IsDefined(typeof(Id3Language), language))
            {
                frame.Language = Id3Language.eng;
            }
            else
            {
                frame.Language = (Id3Language)Enum.Parse(typeof(Id3Language), language, true);
            }

            string[] splitStrings = TextEncodingHelper.GetSplitStrings(bytes, 4, bytes.Length - 4, frame.Encoding);
            if (splitStrings.Length > 1)
            {
                frame.Description = splitStrings[0];
                frame.Comment = splitStrings[1];
            }
            else if (splitStrings.Length == 1)
            {
                frame.Comment = splitStrings[0];
            }
        }
    }
}
