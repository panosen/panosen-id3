using System;
using System.Diagnostics;
using System.Text;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// Id3Frame
    /// </summary>
    public abstract class Id3Frame
    {
        public FrameEnum FrameId { get; set; }

        public Id3Encoding Encoding { get; set; }
    }
}
