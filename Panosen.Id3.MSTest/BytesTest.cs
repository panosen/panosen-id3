using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class BytesTest
    {
        [TestMethod]
        public void Test()
        {
            var bytes = new byte[10];
            bytes[6] = 17;
            bytes[7] = 18;
            bytes[8] = 19;
            bytes[9] = 20;

            var expected = bytes[6] * 2097152 + bytes[7] * 16384 + bytes[8] * 128 + bytes[9];
            var actual = Bytes.ToInt32Safe(bytes, 6, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            var bytes = new byte[10];
            bytes[8] = 9;
            bytes[9] = 6;

            var expected = bytes[6] * 2097152 + bytes[7] * 16384 + bytes[8] * 128 + bytes[9];
            var actual = Bytes.ToInt32Safe(bytes, 6, 4);
            Assert.AreEqual(expected, actual);
        }
    }
}
