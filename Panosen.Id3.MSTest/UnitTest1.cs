using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string folder = @"G:\tmp001";

            List<string> files = new List<string>();
            //files.Add("music001");
            //files.Add("music002");
            //files.Add("music003");
            //files.Add("music004");
            //files.Add("music005");

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new EncodingConverter());
            settings.Converters.Add(new FrameEnumConverter());

            foreach (var file in files)
            {
                var path = Path.Combine(folder, file + ".mp3");

                Id3V23 id3v23;
                byte[] auditBytes;
                using (Mp3File mp3File = new Mp3File(path))
                {
                    id3v23 = mp3File.Mp3Stream.ReadId3V23FromStream();
                    auditBytes = mp3File.GetAudioBytes();
                }

                File.WriteAllText(Path.Combine(folder, file + "-id3v2.txt"), JsonConvert.SerializeObject(id3v23, Formatting.Indented, settings));

                    var stream = id3v23.WriteId3V23ToStream();

                var newPath = Path.Combine(folder, file + "-2.mp3");
                using (FileStream fileStream = new FileStream(newPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);

                    fileStream.Write(auditBytes);

                    fileStream.Flush();
                }
            }
        }
    }
}
