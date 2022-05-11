using System;
using System.IO;

namespace Panosen.Id3
{
    public class Mp3File : IDisposable
    {
        public Stream Mp3Stream { get; }

        private bool ownStream;

        public Mp3File(string filename, FileAccess fileAccess = FileAccess.Read)
        {
            FileStream fileStream = File.Open(filename, FileMode.Open, fileAccess, FileShare.Read);
            this.Mp3Stream = fileStream;
            this.ownStream = true;
        }

        public Mp3File(FileInfo fileInfo, FileAccess fileAccess = FileAccess.Read)
        {
            this.Mp3Stream = fileInfo.Open(FileMode.Open, fileAccess, FileShare.Read);
            this.ownStream = true;
        }

        public Mp3File(Stream stream)
        {
            this.Mp3Stream = stream;
            this.ownStream = false;
        }

        public Mp3File(byte[] byteStream)
        {
            var stream = new MemoryStream(byteStream.Length);
            stream.Write(byteStream, 0, byteStream.Length);

            this.Mp3Stream = stream;
            this.ownStream = true;
        }

        public void Dispose()
        {
            if (ownStream)
            {
                Mp3Stream?.Dispose();
            }
        }
    }
}
