using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// Id3Frame
    /// </summary>
    public abstract class Id3Frame
    {
        public FrameEnum FrameId { get; set; }
    }

    /// <summary>
    /// Id3Frame
    /// </summary>
    public abstract class Id3FrameWithEncoding : Id3Frame
    {
        /// <summary>
        /// ±àÂë
        /// </summary>
        public Id3Encoding Encoding { get; set; }
    }
}
