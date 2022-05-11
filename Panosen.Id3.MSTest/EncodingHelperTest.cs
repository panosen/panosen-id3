using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class EncodingHelperTest
    {

        [TestMethod]
        public void TestGB2312()
        {
            var bytes = new byte[5] { 1, 212, 173, 180, 180 };

            var expectedEncoding = Id3Encoding.GB2312;
            var actualEncoding = EncodingHelper.DetectEncoding(bytes);
            Assert.AreEqual(expectedEncoding, actualEncoding);

            var expectedText = "原创";
            var actualText = actualEncoding.GetString(bytes, 1, 4);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void TestUnicode()
        {
            var expectedEncoding = Id3Encoding.Unicode;
            var expectedText = "原创";

            {
                var bytes = new byte[7] { 1, 255, 254, 159, 83, 27, 82 };

                var actualEncoding = EncodingHelper.DetectEncoding(bytes);
                Assert.AreEqual(expectedEncoding, actualEncoding);

                var actualText = actualEncoding.GetString(bytes, 3, 4);
                Assert.AreEqual(expectedText, actualText);
            }


        }
    }
}
