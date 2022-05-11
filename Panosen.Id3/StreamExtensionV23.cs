using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Panosen.Id3.Frames;

namespace Panosen.Id3
{
    /// <summary>
    /// StreamExtensionV23
    /// </summary>
    public static class StreamExtensionV23
    {
        /// <summary>
        /// 读取所有的 id3v2 标签
        /// </summary>
        public static Id3V23 ReadId3V23FromStream(this Stream stream)
        {
            byte[] id3HeadBytes = stream.ReadBytes(10);

            //ID3 byte[3]
            if (id3HeadBytes[0] != 0x49 || id3HeadBytes[1] != 0x44 || id3HeadBytes[2] != 0x33)
            {
                return null;
            }

            Id3V23 id3v23 = new Id3V23();

            //version byte[2]
            id3v23.MajorVersion = id3HeadBytes[3];
            id3v23.RevisionVersion = id3HeadBytes[4];

            //flag byte[1]
            id3v23.Unsyncronization = (id3HeadBytes[5] & 0x80) > 0;
            id3v23.ExtendedHeader = (id3HeadBytes[5] & 0x40) > 0;
            id3v23.Experimental = (id3HeadBytes[5] & 0x20) > 0;

            if (id3v23.ExtendedHeader)
            {
                var extendedHeaderBytes = stream.ReadBytes(10);
                var ExtendedHeaderSize = Bytes.ToInt32Safe(extendedHeaderBytes, 0, 4);
                var extendedFlags = new byte[2] { extendedHeaderBytes[4], extendedHeaderBytes[5] };
                id3v23.PaddingSize = Bytes.ToInt32Normal(extendedHeaderBytes, 6, 4);

                if ((extendedHeaderBytes[4] & 0x80) > 0)
                {
                    var crc32Bytes = stream.ReadBytes(4);
                    id3v23.Crc32 = Bytes.ToInt32Normal(crc32Bytes, 0, crc32Bytes.Length);
                }
            }

            //size byte[4]
            id3v23.BytesLength = Bytes.ToInt32Safe(id3HeadBytes, 6, 4);
            int index = 0;
            while (index < id3v23.BytesLength)
            {
                byte[] frameHeadBytes = stream.ReadBytes(10);
                var frameId = Encoding.ASCII.GetString(frameHeadBytes, 0, 4);
                var frameLength = Bytes.ToInt32Safe(frameHeadBytes, 4, 4);

                byte[] frameBodyBytes = stream.ReadBytes(frameLength);

                var frame = DecodeFrame(frameId, frameBodyBytes);
                if (frame != null)
                {
                    id3v23.AddFrame(frame);
                }

                index += frameLength;
            }

            return id3v23;
        }

        /// <summary>
        /// DecodeFrame
        /// </summary>
        public static Id3Frame DecodeFrame(string frameId, byte[] bytes)
        {
            switch (frameId)
            {
                case FrameConstant.TALB:
                case FrameConstant.TPE1:
                case FrameConstant.TPE2:
                case FrameConstant.TPE3:
                case FrameConstant.TBPM:
                case FrameConstant.TCOM:
                case FrameConstant.TIT1:
                case FrameConstant.TCOP:
                case FrameConstant.TXXX:
                case FrameConstant.TENC:
                case FrameConstant.TSSE:
                case FrameConstant.TOWN:
                case FrameConstant.TFLT:
                case FrameConstant.TCON:
                case FrameConstant.TLEN:
                case FrameConstant.TEXT:
                case FrameConstant.TPUB:
                case FrameConstant.TDAT:
                case FrameConstant.TIT3:
                case FrameConstant.TIT2:
                case FrameConstant.TKEY:
                    {
                        return FrameHandlerFactory.textFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.TYER:
                    {
                        return FrameHandlerFactory.yearFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.TRCK:
                case FrameConstant.TPOS:
                    {
                        return FrameHandlerFactory.tposFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.WOAR:
                case FrameConstant.WOAF:
                case FrameConstant.WOAS:
                case FrameConstant.WCOM:
                case FrameConstant.WCOP:
                case FrameConstant.WPAY:
                    {
                        return FrameHandlerFactory.urlLinkFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.COMM:
                    {
                        return FrameHandlerFactory.commentFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.WXXX:
                    {
                        return FrameHandlerFactory.customUrlLinkHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.USLT:
                    {
                        return FrameHandlerFactory.lyricsHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.APIC:
                    {
                        //return FrameHandlerFactory.pictureHandler.Decode(frameId, bytes);
                        return null;
                    }
                case FrameConstant.PRIV:
                    {
                        return FrameHandlerFactory.privateHandler.Decode(frameId, bytes);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
