using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.Id3.Frames;
using Panosen.Id3.Handlers;
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
        public void TestUnicodEncoding()
        {
            TextFrameHandler handler = new TextFrameHandler();

            var expected = new TextFrame();
            expected.Encoding = Id3Encoding.Unicode;
            expected.Value = "this is a test.";

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
            expected.Value = "this is a test.";

            var bytes = handler.Encode(expected);

            var actual = handler.Decode("TIT2", bytes);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Encoding, actual.Encoding);
            Assert.AreEqual(expected.Value, actual.Value);
        }
    }
}
