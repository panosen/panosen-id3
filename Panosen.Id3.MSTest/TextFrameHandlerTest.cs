using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class TextFrameHandlerTest
    {
        [TestMethod]
        public void TesyUnicodeBOM()
        {
            var text = "sample";

            var bytes = Encoding.Unicode.GetPreamble();
            Assert.AreEqual(0xFF, bytes[0]);
            Assert.AreEqual(0xFE, bytes[1]);

            var expected = new byte[12] { 115, 0, 97, 0, 109, 0, 112, 0, 108, 0, 101, 0 };
            var actual = Encoding.Unicode.GetBytes(text);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int index = 0; index < expected.Length; index++)
            {
                Assert.AreEqual(expected[index], actual[index]);
            }
        }

        [TestMethod]
        public void TestUnicodEncoding()
        {
            TextFrameHandler handler = new TextFrameHandler();

            var expected = new TextFrame();
            expected.Encoding = Id3Encoding.Unicode;
            expected.Value = "sample";

            var bytes = handler.Encode(expected);

            var actual = handler.Decode("TIT2", bytes);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Encoding, actual.Encoding);
            Assert.AreEqual(expected.Value, actual.Value);
        }

        [TestMethod]
        public void TestDefaultEncoding()
        {
            TextFrameHandler handler = new TextFrameHandler();

            var expected = new TextFrame();
            expected.Encoding = Id3Encoding.ISO88591;
            expected.Value = "sample";

            var bytes = handler.Encode(expected);

            var actual = handler.Decode("TIT2", bytes);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Encoding, actual.Encoding);
            Assert.AreEqual(expected.Value, actual.Value);
        }
    }
}
