using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// https://id3.org/id3v2.3.0#Comments
    /// </summary>
    public sealed class CommentFrame : Id3FrameWithEncoding
    {
        /// <summary>
        /// ����
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Content { get; set; }
    }
}