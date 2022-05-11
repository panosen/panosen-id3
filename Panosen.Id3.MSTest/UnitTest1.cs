using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Panosen.Id3.MSTest
{
    //[TestClass]
    public class UnitTest1
    {

        //[TestMethod]
        public void TestMethod1()
        {
            string folder = @"G:\tmp001";

            List<string> files = new List<string>();
            files.Add("music001");
            files.Add("music002");

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new EncodingConverter());
            settings.Converters.Add(new FrameEnumConverter());

            foreach (var file in files)
            {
                var path = Path.Combine(folder, file + ".mp3");

                using (Mp3File mp3File = new Mp3File(path))
                {
                    var id3v1Bytes = mp3File.Mp3Stream.GetAllV1TagBytes();
                    var id3v23Bytes = mp3File.Mp3Stream.GetAllV23TagBytes();
                    var audioBytes = mp3File.GetAudioBytes();

                    Assert.AreEqual(mp3File.Mp3Stream.Length, id3v1Bytes.Length + id3v23Bytes.Length + audioBytes.Length);

                    var v1Tags = mp3File.Mp3Stream.ReadAllV1Tags();
                    File.WriteAllText(Path.Combine(folder, file + "-id3v1.tx"), JsonConvert.SerializeObject(v1Tags, Formatting.Indented, settings));

                    var v23Tags = mp3File.Mp3Stream.ReadAllV23Tags();
                    File.WriteAllText(Path.Combine(folder, file + "-id3v2.tx"), JsonConvert.SerializeObject(v23Tags, Formatting.Indented, settings));

                    var zz = 0;
                }
            }
        }
    }
}
