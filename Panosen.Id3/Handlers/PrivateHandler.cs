using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Handlers
{
    public class PrivateHandler : FrameHandler<PrivateFrame>
    {
        protected override void OnEncode(PrivateFrame frame, List<byte> bytes)
        {
            bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.OwnerId));
            bytes.AddRange(TextEncodingHelper.GetSplitterBytes(Id3Encoding.ISO88591));
            bytes.AddRange(frame.Data ?? new byte[0]);
        }

        protected override void OnDecode(byte[] bytes, PrivateFrame frame)
        {
            byte[] splitterSequence = TextEncodingHelper.GetSplitterBytes(Id3Encoding.ISO88591);
            byte[] ownerIdBytes = ByteArrayHelper.GetBytesUptoSequence(bytes, 0, splitterSequence);
            frame.OwnerId = TextEncodingHelper.GetString(ownerIdBytes, 0, ownerIdBytes.Length, Id3Encoding.ISO88591);
            frame.Data = new byte[bytes.Length - ownerIdBytes.Length - splitterSequence.Length];
            Array.Copy(bytes, ownerIdBytes.Length + splitterSequence.Length, frame.Data, 0, frame.Data.Length);
        }
    }
}
