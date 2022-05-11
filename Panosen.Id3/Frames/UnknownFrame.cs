using System;

namespace Panosen.Id3.Frames
{
    public sealed class UnknownFrame : Id3Frame, IEquatable<UnknownFrame>
    {
        public bool Equals(UnknownFrame other)
        {
            if (base.Equals(other))
                return true;
            if (!(other is UnknownFrame unknownFrame))
                return false;
            if (Id != unknownFrame.Id)
                return false;
            return ByteArrayHelper.AreEqual(Data, unknownFrame.Data);
        }

        public string Id { get; set; }

        public byte[] Data { get; internal set; }
    }
}