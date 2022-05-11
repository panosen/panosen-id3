using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Panosen.Id3.Frames;

namespace Panosen.Id3
{
    public static class Id3V2Extension
    {
        public static Id3Frame GetFrame(this Id3V23 id3V2, FrameEnum frameId)
        {
            if (id3V2.FrameList == null || id3V2.FrameList.Count == 0)
            {
                return null;
            }

            return id3V2.FrameList.FirstOrDefault(v => v.FrameId == frameId);
        }

        public static void t(this Id3V23 id3V2, string value, Id3Encoding encoding)
        {
            if (id3V2.FrameList == null || id3V2.FrameList.Count == 0)
            {
                id3V2.FrameList = new List<Id3Frame>();
            }

            var textFrame = id3V2.FrameList.FirstOrDefault(v => v.FrameId == FrameEnum.TIT2) as TextFrame;
            if (textFrame != null)
            {
                textFrame.Value = value;
                textFrame.Encoding = encoding;
            }
        }

        /// <summary>
        /// 读取所有的 id3v2 标签
        /// </summary>
        public static Stream WriteId3V23ToStream(this Id3V23 id3v23)
        {
            Stream stream = new MemoryStream();

            //ID3 byte[3]
            stream.WriteByte(0x49);
            stream.WriteByte(0x44);
            stream.WriteByte(0x33);

            //version byte[2]
            stream.WriteByte(id3v23.MajorVersion);
            stream.WriteByte(id3v23.RevisionVersion);

            //flags byte[1]
            byte flag = 0;
            if (id3v23.Unsyncronization)
            {
                flag |= 0x80;
            }
            if (id3v23.ExtendedHeader)
            {
                flag |= 0x40;
            }
            if (id3v23.Experimental)
            {
                flag |= 0x20;
            }

            //size byte[2]
            stream.WriteByte(flag);

            if (id3v23.ExtendedHeader)
            {
                int ExtendedHeaderSize = 0;

                stream.WriteBytes(Bytes.FromInt32Safe(ExtendedHeaderSize));
                stream.WriteByte(0);
                stream.WriteByte(0);
                stream.WriteBytes(Bytes.FromInt32Normal(id3v23.PaddingSize));

                //if ((extendedHeaderBytes[4] & 0x80) > 0)
                //{
                //    binaryWriter.Write(Bytes.FromInt32Normal(id3v23.Crc32));
                //}
            }

            int size = 0;
            stream.WriteInt32(size);

            if (id3v23.FrameList != null && id3v23.FrameList.Count > 0)
            {
                foreach (var frame in id3v23.FrameList)
                {
                    var bytes = EncodeFrame(frame);

                    stream.WriteBytes(Encoding.ASCII.GetBytes(frame.FrameId.ToString()));
                    stream.WriteBytes(Bytes.FromInt32Safe(bytes.Length));
                    stream.WriteByte(0);
                    stream.WriteByte(0);

                    stream.WriteBytes(bytes);

                    size += 10;
                    size += bytes.Length;
                }
            }

            if (size < id3v23.BytesLength)
            {
                stream.WriteBytes(new byte[id3v23.BytesLength - size]);
                size = id3v23.BytesLength;
            }

            stream.Seek(6, SeekOrigin.Begin);
            stream.WriteBytes(Bytes.FromInt32Safe(size));

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }

        /// <summary>
        /// EncodeFrame
        /// </summary>
        public static byte[] EncodeFrame(Id3Frame frame)
        {
            switch (frame.FrameId)
            {
                case FrameEnum.TALB:
                case FrameEnum.TPE1:
                case FrameEnum.TPE2:
                case FrameEnum.TPE3:
                case FrameEnum.TBPM:
                case FrameEnum.TCOM:
                case FrameEnum.TIT1:
                case FrameEnum.TCOP:
                case FrameEnum.TXXX:
                case FrameEnum.TENC:
                case FrameEnum.TSSE:
                case FrameEnum.TOWN:
                case FrameEnum.TFLT:
                case FrameEnum.TCON:
                case FrameEnum.TLEN:
                case FrameEnum.TEXT:
                case FrameEnum.TPUB:
                case FrameEnum.TDAT:
                case FrameEnum.TIT3:
                case FrameEnum.TIT2:
                case FrameEnum.TKEY:
                    {
                        return FrameHandlerFactory.textFrameHandler.Encode(frame as TextFrame);
                    }
                case FrameEnum.TYER:
                    {
                        return FrameHandlerFactory.yearFrameHandler.Encode(frame as YearFrame);
                    }
                case FrameEnum.TRCK:
                case FrameEnum.TPOS:
                    {
                        return FrameHandlerFactory.tposFrameHandler.Encode(frame as TextFrame);
                    }
                case FrameEnum.WOAR:
                case FrameEnum.WOAF:
                case FrameEnum.WOAS:
                case FrameEnum.WCOM:
                case FrameEnum.WCOP:
                case FrameEnum.WPAY:
                    {
                        return FrameHandlerFactory.urlLinkFrameHandler.Encode(frame as UrlLinkFrame);
                    }
                case FrameEnum.COMM:
                    {
                        return FrameHandlerFactory.commentFrameHandler.Encode(frame as CommentFrame);
                    }
                case FrameEnum.WXXX:
                    {
                        return FrameHandlerFactory.customUrlLinkHandler.Encode(frame as CustomUrlLinkFrame);
                    }
                case FrameEnum.USLT:
                    {
                        return FrameHandlerFactory.lyricsHandler.Encode(frame as LyricsFrame);
                    }
                case FrameEnum.APIC:
                    {
                        return FrameHandlerFactory.pictureHandler.Encode(frame as PictureFrame);
                    }
                case FrameEnum.PRIV:
                    {
                        return FrameHandlerFactory.privateHandler.Encode(frame as PrivateFrame);
                    }
                default:
                    return null;
            }
        }
    }
}
