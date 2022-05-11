using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

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

    public sealed class PictureFrameList : Collection<PictureFrame>
    {
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
}