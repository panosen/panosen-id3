using System;
using System.Text;

namespace Panosen.Id3.Frames
{
    public sealed class CustomUrlLinkFrame : UrlLinkFrame
    {
        public string Description { get; set; }
    }
}