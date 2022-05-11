using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Panosen.Id3.Frames
{
    public sealed class CommentFrame : Id3Frame
    {
        public CommentFrame()
        {
        }

        public CommentFrame(string comment)
        {
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public CommentFrame(string comment, string description)
        {
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string Comment { get; set; }

        public string Description { get; set; }

        public Id3Language Language { get; set; } = Id3Language.eng;

        public static implicit operator CommentFrame(string comment) => new CommentFrame(comment);
    }

    public sealed class CommentFrameList : Collection<CommentFrame>
    {
        public CommentFrame[] ByLanguage(Id3Language language)
        {
            return this.Where(commentFrame => commentFrame.Language == language).ToArray();
        }

        public CommentFrame[] ByDescription(string description)
        {
            return this.Where(frame => frame.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public CommentFrame ByLanguageAndDescription(Id3Language language, string description)
        {
            return this.FirstOrDefault(frame =>
                frame.Language == language &&
                frame.Description.Equals(description, StringComparison.OrdinalIgnoreCase));
        }
    }
}