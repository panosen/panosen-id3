using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    /// <summary>
    /// Mp3FileExtension
    /// </summary>
    public static class Mp3FileExtension
    {
        /// <summary>
        /// GetAudioBytes
        /// </summary>
        public static byte[] GetAudioBytes(this Mp3File mp3File)
        {
            var mp3Stream = mp3File.Mp3Stream;

            int v1TagLength = mp3File.Mp3Stream.GetV1TagLength();
            int v23TagLength = mp3File.Mp3Stream.GetV2TagLength();

            long audioStreamLength = mp3Stream.Length - v1TagLength - v23TagLength;
            var audioStream = new byte[audioStreamLength];

            if (v23TagLength > 0)
            {
                mp3Stream.Seek(v23TagLength, SeekOrigin.Begin);
            }
            else
            {
                mp3Stream.Seek(0, SeekOrigin.Begin);
            }

            mp3Stream.Read(audioStream, 0, (int)audioStreamLength);
            return audioStream;
        }
    }
}
