using System;
using System.Diagnostics;
using System.Text;

namespace Panosen.Id3.Frames
{
    public abstract class TextFrameBase<TValue> : Id3Frame
    {
        public TValue Value { get; set; }
    }
    public class FileTypeFrame : TextFrameBase<FileAudioType>
    {
    }
    public sealed class LengthFrame : TextFrameBase<TimeSpan>
    {
    }
    public sealed class NumericFrame : TextFrameBase<int?>
    {
    }
    public sealed class TextFrame : TextFrameBase<string>
    {
    }
}
