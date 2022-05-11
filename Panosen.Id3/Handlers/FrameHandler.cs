using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Handlers
{
    public abstract class FrameHandler<TEntity>
        where TEntity : Id3Frame, new()
    {
        public byte[] Encode(TEntity frame)
        {
            List<byte> bytes = new List<byte>();

            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.Add(1);
            }
            else if (frame.Encoding == Id3Encoding.ISO88591)
            {
                bytes.Add(0);
            }

            OnEncode(frame, bytes);

            if (frame.Encoding == Id3Encoding.Unicode)
            {
                bytes.Add(0);
                bytes.Add(0);
            }
            else if (frame.Encoding == Id3Encoding.ISO88591)
            {
                bytes.Add(0);
            }

            return bytes.ToArray();
        }

        public TEntity Decode(string frameId, byte[] bytes)
        {
            var frame = new TEntity();
            frame.FrameId = (FrameEnum)Enum.Parse(typeof(FrameEnum), frameId);

            if (bytes[0] == 1)
            {
                frame.Encoding = Id3Encoding.Unicode;
            }
            else
            {
                frame.Encoding = Id3Encoding.ISO88591;
            }

            OnDecode(bytes, frame);

            return frame;
        }

        protected abstract void OnEncode(TEntity frame, List<byte> bytes);

        protected abstract void OnDecode(byte[] bytes, TEntity frame);
    }
}
