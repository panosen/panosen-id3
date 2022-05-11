using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    public class Id3TagV1
    {
        public string Title { get; set; }
        public string Artists { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public int Track { get; set; }
        public string Comments { get; set; }
    }
}
