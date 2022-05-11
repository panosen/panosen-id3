using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    /// <summary>
    /// FrameHandler
    /// </summary>
    public abstract class FrameHandler<TEntity> where TEntity : Id3Frame, new()
    {
        private byte[] lastBytes;

        /// <summary>
        /// 编码
        /// </summary>
        public byte[] Encode(TEntity frame)
        {
            List<byte> bytes = new List<byte>();

            OnEncode(frame, bytes);

            return bytes.ToArray();
        }

        /// <summary>
        /// 解码
        /// </summary>
        public TEntity Decode(string frameId, byte[] bytes)
        {
            lastBytes = bytes;

            var frame = new TEntity();
            frame.FrameId = (FrameEnum)Enum.Parse(typeof(FrameEnum), frameId);

            OnDecode(bytes, frame);

            return frame;
        }

        /// <summary>
        /// 编码
        /// </summary>
        protected abstract void OnEncode(TEntity frame, List<byte> bytes);

        /// <summary>
        /// 解码
        /// </summary>
        protected abstract void OnDecode(byte[] bytes, TEntity frame);
    }
}
