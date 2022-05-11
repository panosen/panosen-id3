using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    public sealed class LyricsFrame : Id3Frame, IEquatable<LyricsFrame>
    {
        public LyricsFrame()
        {
        }

        public LyricsFrame(string lyrics)
        {
            Lyrics = lyrics ?? throw new ArgumentNullException(nameof(lyrics));
        }

        public LyricsFrame(string lyrics, string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Lyrics = lyrics ?? throw new ArgumentNullException(nameof(lyrics));
        }

        public bool Equals(LyricsFrame other)
        {
            return other is LyricsFrame lyricsFrame &&
                lyricsFrame.Language == Language &&
                lyricsFrame.Description == Description;
        }

        public string Description { get; set; }

        public string Language { get; set; }

        public string Lyrics { get; set; }

        public static implicit operator LyricsFrame(string lyrics) => new LyricsFrame(lyrics);
    }
    public class LyricsHandler : FrameHandler<LyricsFrame>
    {
        protected override void OnEncode(LyricsFrame frame, List<byte> bytes)
        {
            throw new NotImplementedException();
        }

        protected override void OnDecode(byte[] bytes, LyricsFrame frame)
        {
            //frame.Language = Encoding.ASCII.GetString(bytes, 1, 3);

            //string[] splitStrings = TextEncodingHelper.GetSplitStrings(bytes, 4, bytes.Length - 4, frame.Encoding);
            //if (splitStrings.Length > 1)
            //{
            //    frame.Description = splitStrings[0];
            //    frame.Lyrics = splitStrings[1];
            //}
            //else if (splitStrings.Length == 1)
            //{
            //    frame.Lyrics = splitStrings[0];
            //}
        }
    }
}