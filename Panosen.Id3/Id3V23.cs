using Panosen.Id3.Frames;
using System.Collections.Generic;

namespace Panosen.Id3
{
    /// <summary>
    /// Id3v2.3
    /// </summary>
    public sealed class Id3V23
    {
        /// <summary>
        /// 长度
        /// </summary>
        public int BytesLength { get; set; }

        /// <summary>
        /// [Standard]Experimental
        /// </summary>
        public bool Experimental { get; set; }

        /// <summary>
        /// [Standard]ExtendedHeader
        /// </summary>
        public bool ExtendedHeader { get; set; }

        /// <summary>
        /// [Standard]MajorVersion
        /// </summary>
        public byte MajorVersion { get; set; }

        /// <summary>
        /// [Standard]RevisionVersion
        /// </summary>
        public byte RevisionVersion { get; set; }

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
