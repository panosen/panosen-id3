using System;
using System.IO;

namespace Panosen.Id3
{
    /// <summary>
    /// Mp3File
    /// </summary>
    public class Mp3File : IDisposable
    {
        /// <summary>
        /// Mp3Stream
        /// </summary>
        public Stream Mp3Stream { get; }

        private bool ownStream;

        /// <summary>
        /// Mp3File
        /// </summary>
        public Mp3File(string fileName, FileAccess fileAccess = FileAccess.Read)
        {
            FileStream fileStream = File.Open(fileName, FileMode.Open, fileAccess, FileShare.Read);
            this.Mp3Stream = fileStream;
            this.ownStream = true;
        }

        /// <summary>
        /// Mp3File
        /// </summary>
        public Mp3File(FileInfo fileInfo, FileAccess fileAccess = FileAccess.Read)
        {
            this.Mp3Stream = fileInfo.Open(FileMode.Open, fileAccess, FileShare.Read);
            this.ownStream = true;
        }

        /// <summary>
        /// Mp3File
        /// </summary>
        public Mp3File(Stream stream)
        {
            this.Mp3Stream = stream;
            this.ownStream = false;
        }

        /// <summary>
        /// Mp3File
        /// </summary>
        public Mp3File(byte[] byteStream)
        {
            var stream = new MemoryStream(byteStream.Length);
            stream.Write(byteStream, 0, byteStream.Length);

            this.Mp3Stream = stream;
            this.ownStream = true;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (ownStream)
            {
                Mp3Stream?.Dispose();
            }
        }
    }
}
