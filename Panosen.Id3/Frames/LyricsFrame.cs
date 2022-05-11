using System;
using System.Collections.ObjectModel;
using System.Text;

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

        public Id3Language Language { get; set; } = Id3Language.eng;

        public string Lyrics { get; set; }

        public static implicit operator LyricsFrame(string lyrics) => new LyricsFrame(lyrics);
    }

    public sealed class LyricsFrameList : Collection<LyricsFrame>
    {
        public void Add(string lyrics, string description)
        {
            Add(new LyricsFrame(lyrics, description));
        }
    }
}