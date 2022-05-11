using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Frames
{
    public sealed class PictureFrame : Id3Frame
    {
        public PictureFrame()
        {
            PictureType = PictureType.FrontCover;
        }

        public void LoadImage(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            PictureData = bytes;
        }

        public void LoadImage(string filePath)
        {
            PictureData = File.ReadAllBytes(filePath);
        }

        public void SaveImage(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            stream.Write(PictureData, 0, PictureData.Length);
        }

        public void SaveImage(string filePath)
        {
            File.WriteAllBytes(filePath, PictureData);
        }

        public string GetExtension()
        {
            if (string.IsNullOrEmpty(MimeType))
                return "jpg";
            string[] parts = MimeType.Split('/');
            if (parts.Length < 2 || string.IsNullOrEmpty(parts[1]))
                return "jpg";
            return parts[1];
        }

        public string Description { get; set; }

        public string MimeType { get; set; }

        public byte[] PictureData { get; set; }

        public PictureType PictureType { get; set; }
    }

    public enum PictureType : byte
    {
        Other = 0x00,
        FileIcon = 0x01,
        OtherFileIcon = 0x02,
        FrontCover = 0x03,
        BackCover = 0x04,
        LeafletPage = 0x05,
        Media = 0x06,
        LeadArtistPerformerSoloist = 0x07,
        ArtistOrPerformer = 0x08,
        Conductor = 0x09,
        BandOrOrchestra = 0x0A,
        Composer = 0x0B,
        LyricistOrTextWriter = 0x0C,
        RecordingLocation = 0x0D,
        DuringRecording = 0x0E,
        DuringPerformance = 0x0F,
        MovieOrVideoScreenCapture = 0x10,
        ABrightColouredFish = 0x11,
        Illustration = 0x12,
        BandOrArtistLogotype = 0x13,
        PublisherOrStudioLogotype = 0x14
    }
    public class PictureHandler : FrameHandler<PictureFrame>
    {
        protected override void OnEncode(PictureFrame frame, List<byte> bytes)
        {
            Id3Encoding defaultEncoding = Id3Encoding.ISO88591;
            bytes.AddRange(!string.IsNullOrEmpty(frame.MimeType)
                ? defaultEncoding.GetBytes(frame.MimeType)
                : defaultEncoding.GetBytes("image/"));

            bytes.Add(0);
            bytes.Add((byte)frame.PictureType);

            Id3Encoding descriptionEncoding = Id3Encoding.ISO88591;
            bytes.AddRange(descriptionEncoding.GetPreamble());
            if (!string.IsNullOrEmpty(frame.Description))
                bytes.AddRange(descriptionEncoding.GetBytes(frame.Description));
            bytes.AddRange(TextEncodingHelper.GetSplitterBytes(Id3Encoding.ISO88591));

            if (frame.PictureData != null && frame.PictureData.Length > 0)
                bytes.AddRange(frame.PictureData);
        }

        protected override void OnDecode(byte[] bytes, PictureFrame frame)
        {
            byte[] mimeType = ByteArrayHelper.GetBytesUptoSequence(bytes, 1, new byte[] { 0x00 });
            if (mimeType == null)
            {
                frame.MimeType = "image/";
                return;
            }

            frame.MimeType = TextEncodingHelper.GetDefaultString(mimeType, 0, mimeType.Length);

            int currentPos = mimeType.Length + 2;
            frame.PictureType = (PictureType)bytes[currentPos];

            currentPos++;
            byte[] description = ByteArrayHelper.GetBytesUptoSequence(bytes, currentPos,
                TextEncodingHelper.GetSplitterBytes(Id3Encoding.ISO88591));
            if (description == null)
            {
                return;
            }
            frame.Description = TextEncodingHelper.GetString(description, 0, description.Length, Id3Encoding.ISO88591);

            currentPos += description.Length + TextEncodingHelper.GetSplitterBytes(Id3Encoding.ISO88591).Length;
            frame.PictureData = new byte[bytes.Length - currentPos];
            Array.Copy(bytes, currentPos, frame.PictureData, 0, frame.PictureData.Length);
        }
    }
}