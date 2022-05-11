using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Panosen.Id3.Frames
{
    public sealed class PrivateFrame : Id3Frame
    {
        public byte[] Data { get; set; }

        public string OwnerId { get; set; }
    }
}