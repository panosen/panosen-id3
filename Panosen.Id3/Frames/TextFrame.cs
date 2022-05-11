using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// TextFrame
    /// </summary>
    public sealed class TextFrame : Id3FrameWithEncoding
    {
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// If the textstring is followed by a termination ($00 (00)) all the following information should be ignored and not be displayed.
        /// </summary>
        public bool Hidden { get; set; }
    }
}
