using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    public sealed class PrivateFrame : Id3Frame
    {
        public byte[] Data { get; set; }

        public string OwnerId { get; set; }
    }
    /// <summary>
    /// PrivateHandler
    /// </summary>
    public class PrivateHandler : FrameHandler<PrivateFrame>
    {
        /// <summary>
        /// ±àÂë
        /// </summary>
        protected override void OnEncode(PrivateFrame frame, List<byte> bytes)
        {
            if (!string.IsNullOrEmpty(frame.OwnerId))
            {
                bytes.AddRange(Id3Encoding.ISO88591.GetBytes(frame.OwnerId));
            }

            bytes.Add(0);

            if (frame.Data != null && frame.Data.Length > 0)
            {
                bytes.AddRange(frame.Data ?? new byte[0]);
            }
        }

        /// <summary>
        /// ½âÂë
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="frame"></param>
        protected override void OnDecode(byte[] bytes, PrivateFrame frame)
        {
            int length = 0;
            while (bytes[length] != 0)
            {
                length++;
            }

            frame.OwnerId = Id3Encoding.ISO88591.GetString(bytes, 0, length);

            var dataBytes = new byte[bytes.Length - length - 1];
            for (int i = 0; i + length + 1 < bytes.Length; i++)
            {
                dataBytes[i] = bytes[i + length + 1];
            }
            frame.Data = dataBytes;
        }
    }
}