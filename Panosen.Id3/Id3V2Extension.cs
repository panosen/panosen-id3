using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    public static class Id3V2Extension
    {
        public static Id3Frame GetFrame(this Id3V2 id3V2, FrameEnum frameId)
        {
            if (id3V2.FrameList == null || id3V2.FrameList.Count == 0)
            {
                return null;
            }

            return id3V2.FrameList.FirstOrDefault(v => v.FrameId == frameId);
        }

        public static void t(this Id3V2 id3V2, string value, Id3Encoding encoding)
        {
            if (id3V2.FrameList == null || id3V2.FrameList.Count == 0)
            {
                id3V2.FrameList = new List<Id3Frame>();
            }

            var textFrame = id3V2.FrameList.FirstOrDefault(v => v.FrameId == FrameEnum.TIT2) as TextFrame;
            if (textFrame != null)
            {
                textFrame.Value = value;
                textFrame.Encoding = encoding;
            }
        }
    }
}
