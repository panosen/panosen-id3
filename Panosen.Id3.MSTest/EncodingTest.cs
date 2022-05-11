using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class EncodingTest
    {
        [TestMethod]
        public void Test1()
        {
            var bytes = new byte[2] { 104, 0 };

            var expected = "h";
            var actual = Encoding.Unicode.GetString(bytes, 0, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            var bytes = new byte[0];

            var expected = "";
            var actual = Encoding.Unicode.GetString(bytes, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test3()
        {
            var expected = new byte[2] { 104, 0 };
            var actual = Encoding.Unicode.GetBytes("h");

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }

        [TestMethod]
        public void Test4()
        {
            var expected = new byte[0];
            var actual = Encoding.Unicode.GetBytes("");

            Assert.AreEqual(expected.Length, actual.Length);
        }
    }
}
