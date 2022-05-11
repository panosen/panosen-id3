using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    public static class StreamExtensionV1
    {

        public static bool HasV1Tag(this Stream stream)
        {
            if (stream.Length < 128)
            {
                return false;
            }

            stream.Seek(-128, SeekOrigin.End);
            byte[] magicBytes = new byte[3];
            stream.Read(magicBytes, 0, 3);
            string magic = TextEncodingHelper.GetDefaultString(magicBytes, 0, 3);
            return magic == "TAG";
        }

        public static int GetV1TagLength(this Stream stream)
        {
            if (!stream.HasV1Tag())
            {
                return 0;
            }

            return 128;
        }

        public static byte[] GetAllV1TagBytes(this Stream stream)
        {
            if (!stream.HasV1Tag())
            {
                return null;
            }

            stream.Seek(-128, SeekOrigin.End);
            byte[] tagBytes = new byte[128];
            stream.Read(tagBytes, 0, 128);
            return tagBytes;
        }

        public static void DeleteAllV1Tags(Stream stream)
        {
            if (!stream.HasV1Tag())
            {
                return;
            }
            stream.SetLength(stream.Length - 128);
            stream.Flush();
        }

        public static Id3TagV1 ReadAllV1Tags(this Stream stream)
        {
            if (!stream.HasV1Tag())
            {
                return null;
            }

            stream.Seek(-125, SeekOrigin.End);
            byte[] tagBytes = new byte[125];
            stream.Read(tagBytes, 0, 125);

            Id3TagV1 tag = new Id3TagV1();
            tag.Title = ReadTagString(tagBytes, 0, 30);
            tag.Artists = ReadTagString(tagBytes, 30, 30);
            tag.Album = ReadTagString(tagBytes, 60, 30);
            tag.Year = ReadTagString(tagBytes, 90, 4);
            tag.Genre = ReadTagString(tagBytes, 124, 1);
            string comment;
            if (tagBytes[122] == 0 && tagBytes[123] != 0)
            {
                comment = ReadTagString(tagBytes, 94, 28);
                tag.Track = tagBytes[123];
            }
            else
            {
                comment = ReadTagString(tagBytes, 94, 30);
                tag.Track = -1;
            }
            tag.Comments = comment;

            return tag;
        }

        public static string ReadTagString(byte[] bytes, int index, int length)
        {
            int endIndex = ByteArrayHelper.LocateSequence(bytes, index, length, new byte[] { 0 });
            if (endIndex == -1 || endIndex <= index)
            {
                endIndex = index + length;
            }
            return Encoding.ASCII.GetString(bytes, index, endIndex - index).Trim();
        }

        public static void WriteAllTags(Stream stream, Id3TagV1 tag)
        {
            Id3Encoding encoding = Id3Encoding.ISO88591;

            byte[] bytes = new byte[128];
            encoding.GetBytes("TAG").CopyTo(bytes, 0);

            byte[] itemBytes;
            if (!string.IsNullOrEmpty(tag.Title))
            {
                itemBytes = encoding.GetBytes(tag.Title);
                Array.Copy(itemBytes, 0, bytes, 3, Math.Min(30, itemBytes.Length));
            }
            if (!string.IsNullOrEmpty(tag.Artists))
            {
                itemBytes = encoding.GetBytes(tag.Artists);
                Array.Copy(itemBytes, 0, bytes, 33, Math.Min(30, itemBytes.Length));
            }
            if (!string.IsNullOrEmpty(tag.Album))
            {
                itemBytes = encoding.GetBytes(tag.Album);
                Array.Copy(itemBytes, 0, bytes, 63, Math.Min(30, itemBytes.Length));
            }
            if (!string.IsNullOrEmpty(tag.Year))
            {
                itemBytes = encoding.GetBytes(tag.Year);
                Array.Copy(itemBytes, 0, bytes, 93, Math.Min(4, itemBytes.Length));
            }
            if (!string.IsNullOrEmpty(tag.Comments))
            {
                itemBytes = encoding.GetBytes(tag.Comments);
                int maxCommentLength = tag.Track == -1 ? 30 : 28;
                Array.Copy(itemBytes, 0, bytes, 97, Math.Min(maxCommentLength, itemBytes.Length));
            }
            if (tag.Track >= 0)
            {
                bytes[126] = (byte)tag.Track;
            }

            if (stream.HasV1Tag())
            {
                stream.Seek(-128, SeekOrigin.End);
            }
            else
            {
                stream.Seek(0, SeekOrigin.End);
            }

            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
