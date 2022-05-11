using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    [TestClass]
    public class FrameEnumTest
    {

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(FrameEnum.AENC, Enum.Parse(typeof(FrameEnum), "AENC"));
            Assert.AreEqual(FrameEnum.APIC, Enum.Parse(typeof(FrameEnum), "APIC"));
            Assert.AreEqual(FrameEnum.COMM, Enum.Parse(typeof(FrameEnum), "COMM"));
            Assert.AreEqual(FrameEnum.COMR, Enum.Parse(typeof(FrameEnum), "COMR"));
            Assert.AreEqual(FrameEnum.ENCR, Enum.Parse(typeof(FrameEnum), "ENCR"));
            Assert.AreEqual(FrameEnum.EQUA, Enum.Parse(typeof(FrameEnum), "EQUA"));
            Assert.AreEqual(FrameEnum.ETCO, Enum.Parse(typeof(FrameEnum), " ETCO"));
            Assert.AreEqual(FrameEnum.GEOB, Enum.Parse(typeof(FrameEnum), "GEOB"));
            Assert.AreEqual(FrameEnum.GRID, Enum.Parse(typeof(FrameEnum), "GRID"));
            Assert.AreEqual(FrameEnum.IPLS, Enum.Parse(typeof(FrameEnum), " IPLS"));
            Assert.AreEqual(FrameEnum.LINK, Enum.Parse(typeof(FrameEnum), "LINK"));
            Assert.AreEqual(FrameEnum.MCDI, Enum.Parse(typeof(FrameEnum), " MCDI"));
            Assert.AreEqual(FrameEnum.MLLT, Enum.Parse(typeof(FrameEnum), " MLLT"));
            Assert.AreEqual(FrameEnum.OWNE, Enum.Parse(typeof(FrameEnum), "OWNE"));
            Assert.AreEqual(FrameEnum.PRIV, Enum.Parse(typeof(FrameEnum), "PRIV"));
            Assert.AreEqual(FrameEnum.PCNT, Enum.Parse(typeof(FrameEnum), "PCNT"));
            Assert.AreEqual(FrameEnum.POPM, Enum.Parse(typeof(FrameEnum), "POPM"));
            Assert.AreEqual(FrameEnum.POSS, Enum.Parse(typeof(FrameEnum), "POSS"));
            Assert.AreEqual(FrameEnum.RBUF, Enum.Parse(typeof(FrameEnum), "RBUF"));
            Assert.AreEqual(FrameEnum.RVAD, Enum.Parse(typeof(FrameEnum), "RVAD"));
            Assert.AreEqual(FrameEnum.RVRB, Enum.Parse(typeof(FrameEnum), "RVRB"));
            Assert.AreEqual(FrameEnum.SYLT, Enum.Parse(typeof(FrameEnum), "SYLT"));
            Assert.AreEqual(FrameEnum.SYTC, Enum.Parse(typeof(FrameEnum), " SYTC"));
            Assert.AreEqual(FrameEnum.TALB, Enum.Parse(typeof(FrameEnum), "TALB"));
            Assert.AreEqual(FrameEnum.TBPM, Enum.Parse(typeof(FrameEnum), "TBPM"));
            Assert.AreEqual(FrameEnum.TCOM, Enum.Parse(typeof(FrameEnum), "TCOM"));
            Assert.AreEqual(FrameEnum.TCON, Enum.Parse(typeof(FrameEnum), "TCON"));
            Assert.AreEqual(FrameEnum.TCOP, Enum.Parse(typeof(FrameEnum), "TCOP"));
            Assert.AreEqual(FrameEnum.TDAT, Enum.Parse(typeof(FrameEnum), "TDAT"));
            Assert.AreEqual(FrameEnum.TDLY, Enum.Parse(typeof(FrameEnum), "TDLY"));
            Assert.AreEqual(FrameEnum.TENC, Enum.Parse(typeof(FrameEnum), "TENC"));
            Assert.AreEqual(FrameEnum.TEXT, Enum.Parse(typeof(FrameEnum), "TEXT"));
            Assert.AreEqual(FrameEnum.TFLT, Enum.Parse(typeof(FrameEnum), "TFLT"));
            Assert.AreEqual(FrameEnum.TIME, Enum.Parse(typeof(FrameEnum), "TIME"));
            Assert.AreEqual(FrameEnum.TIT1, Enum.Parse(typeof(FrameEnum), "TIT1"));
            Assert.AreEqual(FrameEnum.TIT2, Enum.Parse(typeof(FrameEnum), "TIT2"));
            Assert.AreEqual(FrameEnum.TIT3, Enum.Parse(typeof(FrameEnum), "TIT3"));
            Assert.AreEqual(FrameEnum.TKEY, Enum.Parse(typeof(FrameEnum), "TKEY"));
            Assert.AreEqual(FrameEnum.TLAN, Enum.Parse(typeof(FrameEnum), "TLAN"));
            Assert.AreEqual(FrameEnum.TLEN, Enum.Parse(typeof(FrameEnum), "TLEN"));
            Assert.AreEqual(FrameEnum.TMED, Enum.Parse(typeof(FrameEnum), "TMED"));
            Assert.AreEqual(FrameEnum.TOAL, Enum.Parse(typeof(FrameEnum), "TOAL"));
            Assert.AreEqual(FrameEnum.TOFN, Enum.Parse(typeof(FrameEnum), "TOFN"));
            Assert.AreEqual(FrameEnum.TOLY, Enum.Parse(typeof(FrameEnum), "TOLY"));
            Assert.AreEqual(FrameEnum.TOPE, Enum.Parse(typeof(FrameEnum), "TOPE"));
            Assert.AreEqual(FrameEnum.TORY, Enum.Parse(typeof(FrameEnum), "TORY"));
            Assert.AreEqual(FrameEnum.TOWN, Enum.Parse(typeof(FrameEnum), "TOWN"));
            Assert.AreEqual(FrameEnum.TPE1, Enum.Parse(typeof(FrameEnum), "TPE1"));
            Assert.AreEqual(FrameEnum.TPE2, Enum.Parse(typeof(FrameEnum), "TPE2"));
            Assert.AreEqual(FrameEnum.TPE3, Enum.Parse(typeof(FrameEnum), "TPE3"));
            Assert.AreEqual(FrameEnum.TPE4, Enum.Parse(typeof(FrameEnum), "TPE4"));
            Assert.AreEqual(FrameEnum.TPOS, Enum.Parse(typeof(FrameEnum), "TPOS"));
            Assert.AreEqual(FrameEnum.TPUB, Enum.Parse(typeof(FrameEnum), "TPUB"));
            Assert.AreEqual(FrameEnum.TRCK, Enum.Parse(typeof(FrameEnum), "TRCK"));
            Assert.AreEqual(FrameEnum.TRDA, Enum.Parse(typeof(FrameEnum), "TRDA"));
            Assert.AreEqual(FrameEnum.TRSN, Enum.Parse(typeof(FrameEnum), "TRSN"));
            Assert.AreEqual(FrameEnum.TRSO, Enum.Parse(typeof(FrameEnum), "TRSO"));
            Assert.AreEqual(FrameEnum.TSIZ, Enum.Parse(typeof(FrameEnum), "TSIZ"));
            Assert.AreEqual(FrameEnum.TSRC, Enum.Parse(typeof(FrameEnum), "TSRC"));
            Assert.AreEqual(FrameEnum.TSSE, Enum.Parse(typeof(FrameEnum), "TSSE"));
            Assert.AreEqual(FrameEnum.TYER, Enum.Parse(typeof(FrameEnum), "TYER"));
            Assert.AreEqual(FrameEnum.TXXX, Enum.Parse(typeof(FrameEnum), "TXXX"));
            Assert.AreEqual(FrameEnum.UFID, Enum.Parse(typeof(FrameEnum), " UFID"));
            Assert.AreEqual(FrameEnum.USER, Enum.Parse(typeof(FrameEnum), "USER"));
            Assert.AreEqual(FrameEnum.USLT, Enum.Parse(typeof(FrameEnum), " USLT"));
            Assert.AreEqual(FrameEnum.WCOM, Enum.Parse(typeof(FrameEnum), "WCOM"));
            Assert.AreEqual(FrameEnum.WCOP, Enum.Parse(typeof(FrameEnum), "WCOP"));
            Assert.AreEqual(FrameEnum.WOAF, Enum.Parse(typeof(FrameEnum), "WOAF"));
            Assert.AreEqual(FrameEnum.WOAR, Enum.Parse(typeof(FrameEnum), "WOAR"));
            Assert.AreEqual(FrameEnum.WOAS, Enum.Parse(typeof(FrameEnum), "WOAS"));
            Assert.AreEqual(FrameEnum.WORS, Enum.Parse(typeof(FrameEnum), "WORS"));
            Assert.AreEqual(FrameEnum.WPAY, Enum.Parse(typeof(FrameEnum), "WPAY"));
            Assert.AreEqual(FrameEnum.WPUB, Enum.Parse(typeof(FrameEnum), "WPUB"));
            Assert.AreEqual(FrameEnum.WXXX, Enum.Parse(typeof(FrameEnum), "WXXX"));
        }
    }
}
