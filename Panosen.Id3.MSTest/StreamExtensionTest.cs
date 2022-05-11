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
    public class StreamExtensionTest
    {

        [TestMethod]
        public void Test()
        {
            var bytes = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            using (var stream = new MemoryStream(bytes))
            {
                {
                    var temp = stream.ReadBytes(4);
                    Assert.IsNotNull(temp);
                    Assert.AreEqual(4, temp.Length);
                    Assert.AreEqual(0, temp[0]);
                    Assert.AreEqual(1, temp[1]);
                    Assert.AreEqual(2, temp[2]);
                    Assert.AreEqual(3, temp[3]);
                }

                {
                    var temp = stream.ReadBytes(8);
                    Assert.IsNotNull(temp);
                    Assert.AreEqual(6, temp.Length);
                    Assert.AreEqual(4, temp[0]);
                    Assert.AreEqual(5, temp[1]);
                    Assert.AreEqual(6, temp[2]);
                    Assert.AreEqual(7, temp[3]);
                    Assert.AreEqual(8, temp[4]);
                    Assert.AreEqual(9, temp[5]);
                }
            }
        }
    }
}
