using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void Test()
        {
            List<string> lines = new List<string>();
            lines.Add("the first three bytes of the tag are always");
            lines.Add("or not unsynchronisation is used");
            lines.Add("contains information that is not vital");

            byte[] actualBytes;
            using (var stream = new MemoryStream())
            {
                int frameCount = 0;
                stream.Write(Bytes.FromInt32Safe(frameCount));

                foreach (var line in lines)
                {
                    stream.Write(Bytes.FromInt32Safe(0));

                    var bytes = Encoding.ASCII.GetBytes(line);
                    stream.Write(bytes, 0, bytes.Length);

                    stream.Seek(-bytes.Length - 4, SeekOrigin.Current);
                    stream.Write(Bytes.FromInt32Safe(bytes.Length));
                    stream.Seek(bytes.Length, SeekOrigin.Current);

                    frameCount++;
                }

                stream.Seek(0, SeekOrigin.Begin);
                stream.Write(Bytes.FromInt32Safe(frameCount));

                actualBytes = stream.ToArray();
            }

            using (var stream = new MemoryStream(actualBytes))
            {
                BinaryReader reader = new BinaryReader(stream);
                int length = Bytes.ToInt32Safe(reader.ReadBytes(4), 0, 4);
            }
        }
    }
}
