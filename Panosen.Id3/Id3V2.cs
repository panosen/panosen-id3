using Panosen.Id3.Frames;
using System.Collections.Generic;

namespace Panosen.Id3
{
    public sealed class Id3V2
    {
        /// <summary>
        /// [Standard]Experimental
        /// </summary>
        public bool Experimental { get; set; }

        /// <summary>
        /// [Standard]ExtendedHeader
        /// </summary>
        public bool ExtendedHeader { get; set; }

        /// <summary>
        /// [Standard]Revision
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// [Standard]Unsyncronization
        /// </summary>
        public bool Unsyncronization { get; set; }

        /// <summary>
        /// [Extended]Crc32
        /// </summary>
        public int Crc32 { get; set; }

        /// <summary>
        /// [Extended]PaddingSize
        /// </summary>
        public int PaddingSize { get; set; }

        public List<Id3Frame> FrameList { get; set; }

        public void AddFrame(Id3Frame frame)
        {
            if (this.FrameList == null)
            {
                this.FrameList = new List<Id3Frame>();
            }
            this.FrameList.Add(frame);
        }
    }
}
