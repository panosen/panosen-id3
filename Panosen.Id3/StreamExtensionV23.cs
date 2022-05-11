using Panosen.Id3.Frames;
using Panosen.Id3.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    public static class StreamExtensionV23
    {

        private const int BufferSize = 8192;

        private static readonly TextFrameHandler textFrameHandler = new TextFrameHandler();
        private static readonly UrlLinkFrameHandler urlLinkFrameHandler = new UrlLinkFrameHandler();
        private static readonly CommentFrameHandler commentFrameHandler = new CommentFrameHandler();
        private static readonly CustomUrlLinkHandler customUrlLinkHandler = new CustomUrlLinkHandler();
        private static readonly LyricsHandler lyricsHandler = new LyricsHandler();
        private static readonly PictureHandler pictureHandler = new PictureHandler();
        private static readonly PrivateHandler privateHandler = new PrivateHandler();

        public static bool HasV23Tag(this Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            var headerBytes = new byte[5];
            stream.Read(headerBytes, 0, 5);

            string magic = Encoding.ASCII.GetString(headerBytes, 0, 3);
            return magic == "ID3" && headerBytes[3] == 3;
        }

        public static int GetV23TagLength(this Stream stream)
        {
            if (!stream.HasV23Tag())
            {
                return 0;
            }

            var sizeBytes = new byte[4];
            stream.Seek(6, SeekOrigin.Begin);
            stream.Read(sizeBytes, 0, 4);
            int tagSize = SyncSafeNumber.DecodeSafe(sizeBytes, 0, 4);

            return tagSize + 10;
        }

        public static byte[] GetAllV23TagBytes(this Stream stream)
        {
            if (!stream.HasV23Tag())
            {
                return null;
            }

            var sizeBytes = new byte[4];
            stream.Seek(6, SeekOrigin.Begin);
            stream.Read(sizeBytes, 0, 4);
            int tagSize = SyncSafeNumber.DecodeSafe(sizeBytes, 0, 4);

            var tagBytes = new byte[tagSize + 10];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(tagBytes, 0, tagBytes.Length);
            return tagBytes;
        }

        public static Id3V2 ReadAllV23Tags(this Stream stream)
        {
            if (!stream.HasV23Tag())
            {
                return null;
            }

            Id3V2 id3V2 = new Id3V2();

            stream.Seek(4, SeekOrigin.Begin);
            var headerBytes = new byte[6];
            stream.Read(headerBytes, 0, 6);

            byte flags = headerBytes[1];

            id3V2.Revision = headerBytes[0];
            id3V2.Unsyncronization = (flags & 0x80) > 0;
            id3V2.ExtendedHeader = (flags & 0x40) > 0;
            id3V2.Experimental = (flags & 0x20) > 0;

            int tagSize = SyncSafeNumber.DecodeSafe(headerBytes, 2, 4);
            var tagData = new byte[tagSize];
            stream.Read(tagData, 0, tagSize);

            var currentPos = 0;
            if (id3V2.ExtendedHeader)
            {
                SyncSafeNumber.DecodeSafe(tagData, currentPos, 4);
                currentPos += 4;

                id3V2.PaddingSize = SyncSafeNumber.DecodeNormal(tagData, currentPos + 2, 4);

                if ((tagData[currentPos] & 0x80) > 0)
                {
                    id3V2.Crc32 = SyncSafeNumber.DecodeNormal(tagData, currentPos + 6, 4);
                    currentPos += 10;
                }
                else
                {
                    currentPos += 6;
                }
            }

            while (currentPos < tagSize && tagData[currentPos] != 0x00)
            {
                string frameId = Encoding.ASCII.GetString(tagData, currentPos, 4);
                currentPos += 4;

                int frameSize = SyncSafeNumber.DecodeNormal(tagData, currentPos, 4);
                currentPos += 4;

                byte[] frameFlags = new byte[2] { tagData[currentPos], tagData[currentPos + 1] };
                currentPos += 2;

                var frameData = new byte[frameSize];
                Array.Copy(tagData, currentPos, frameData, 0, frameSize);

                var frame = Decode(frameId, frameFlags, frameData);
                if (frame != null)
                {
                    id3V2.AddFrame(frame);
                }

                currentPos += frameSize;
            }

            return id3V2;
        }

        public static Id3Frame Decode(string frameId, byte[] frameFlags, byte[] bytes)
        {
            switch (frameId)
            {
                case FrameConstant.TALB:
                case FrameConstant.TPE1:
                case FrameConstant.TBPM:
                case FrameConstant.TCOM:
                case FrameConstant.TPE3:
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
                case FrameConstant.TRCK:
                case FrameConstant.TYER:
                    {
                        if (bytes.Length == 1)
                        {
                            return null;
                        }
                        return textFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.WOAR:
                case FrameConstant.WOAF:
                case FrameConstant.WOAS:
                case FrameConstant.WCOM:
                case FrameConstant.WCOP:
                case FrameConstant.WPAY:
                    {
                        return urlLinkFrameHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.COMM:
                    {
                        //var frame = commentFrameHandler.Decode(frameId, bytes);
                        //return frame;
                        return null;
                    }
                case FrameConstant.WXXX:
                    {
                        return customUrlLinkHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.USLT:
                    {
                        return lyricsHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.APIC:
                    {
                        return pictureHandler.Decode(frameId, bytes);
                    }
                case FrameConstant.PRIV:
                    {
                        return privateHandler.Decode(frameId, bytes);
                    }
                default:
                    return null;
            }
        }

        public static byte[] Encode<TEntity>(Id3Frame frame)
        {
            switch (frame.FrameId)
            {
                case FrameEnum.TALB:
                case FrameEnum.TPE1:
                case FrameEnum.TBPM:
                case FrameEnum.TCOM:
                case FrameEnum.TPE3:
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
                case FrameEnum.TRCK:
                case FrameEnum.TYER:
                    {
                        return textFrameHandler.Encode(frame as TextFrame);
                    }
                case FrameEnum.WOAR:
                case FrameEnum.WOAF:
                case FrameEnum.WOAS:
                case FrameEnum.WCOM:
                case FrameEnum.WCOP:
                case FrameEnum.WPAY:
                    {
                        return urlLinkFrameHandler.Encode(frame as UrlLinkFrame);
                    }
                case FrameEnum.COMM:
                    {
                        return commentFrameHandler.Encode(frame as CommentFrame);
                    }
                case FrameEnum.WXXX:
                    {
                        return customUrlLinkHandler.Encode(frame as CustomUrlLinkFrame);
                    }
                case FrameEnum.USLT:
                    {
                        return lyricsHandler.Encode(frame as LyricsFrame);
                    }
                case FrameEnum.APIC:
                    {
                        return pictureHandler.Encode(frame as PictureFrame);
                    }
                case FrameEnum.PRIV:
                    {
                        return privateHandler.Encode(frame as PrivateFrame);
                    }
                default:
                    return null;
            }
        }

        public static void WriteAllTags(Stream stream, Id3V2 id3V2)
        {
            byte[] tagBytes = GetTagBytes(id3V2);
            int requiredTagSize = tagBytes.Length;
            if (stream.HasV23Tag())
            {
                int currentTagSize = GetV23TagLength(stream);
                if (requiredTagSize > currentTagSize)
                {
                    MakeSpaceForTag(stream, currentTagSize, requiredTagSize);
                }
            }
            else
            {
                MakeSpaceForTag(stream, 0, requiredTagSize);
            }

            stream.Seek(0, SeekOrigin.Begin);
            stream.Write(tagBytes, 0, requiredTagSize);
            stream.Flush();
        }

        private static byte[] GetTagBytes(Id3V2 tag)
        {
            var bytes = new List<byte>();
            bytes.AddRange(Encoding.ASCII.GetBytes("ID3"));
            bytes.AddRange(new byte[] { 3, 0, 0 });

            ////////foreach (Id3Frame frame in tag)
            ////////{
            ////////    if (!frame.IsAssigned)
            ////////        continue;
            ////////    FrameHandler mapping = FrameHandlers[frame.GetType()];
            ////////    if (mapping == null)
            ////////        continue;
            ////////    byte[] frameBytes = mapping.Encoder(frame);
            ////////    bytes.AddRange(Encoding.ASCII.GetBytes(GetFrameIdFromFrame(frame)));
            ////////    bytes.AddRange(SyncSafeNumber.EncodeNormal(frameBytes.Length));
            ////////    bytes.AddRange(new byte[] { 0, 0 });
            ////////    bytes.AddRange(frameBytes);
            ////////}


            int framesSize = bytes.Count - 6;
            bytes.InsertRange(6, SyncSafeNumber.EncodeSafe(framesSize));
            return bytes.ToArray();
        }

        private static void MakeSpaceForTag(Stream stream, int currentTagSize, int requiredTagSize)
        {
            if (currentTagSize >= requiredTagSize)
                return;

            int increaseRequired = requiredTagSize - currentTagSize;
            var readPos = (int)stream.Length;
            int writePos = readPos + increaseRequired;
            stream.SetLength(writePos);

            var buffer = new byte[BufferSize];
            while (readPos > currentTagSize)
            {
                int bytesToRead = (readPos - BufferSize < currentTagSize) ? readPos - currentTagSize : BufferSize;
                readPos -= bytesToRead;
                stream.Seek(readPos, SeekOrigin.Begin);
                stream.Read(buffer, 0, bytesToRead);
                writePos -= bytesToRead;
                stream.Seek(writePos, SeekOrigin.Begin);
                stream.Write(buffer, 0, bytesToRead);
            }
        }
    }
}
