using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Handlers
{
    public class LyricsHandler : FrameHandler<LyricsFrame>
    {
        protected override void OnEncode(LyricsFrame frame, List<byte> bytes)
        {
            throw new NotImplementedException();
        }

        protected override void OnDecode(byte[] bytes, LyricsFrame frame)
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
                frame.Lyrics = splitStrings[1];
            }
            else if (splitStrings.Length == 1)
            {
                frame.Lyrics = splitStrings[0];
            }
        }
    }
}
