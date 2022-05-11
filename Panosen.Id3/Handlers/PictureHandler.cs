using Panosen.Id3.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.Handlers
{
    public class PictureHandler : FrameHandler<PictureFrame>
    {
        protected override void OnEncode(PictureFrame frame, List<byte> bytes)
        {
            Id3Encoding defaultEncoding = Id3Encoding.ISO88591;
            bytes.AddRange(!string.IsNullOrEmpty(frame.MimeType)
                ? defaultEncoding.GetBytes(frame.MimeType)
                : defaultEncoding.GetBytes("image/"));

            bytes.Add(0);
            bytes.Add((byte)frame.PictureType);

            Id3Encoding descriptionEncoding = frame.Encoding;
            bytes.AddRange(descriptionEncoding.GetPreamble());
            if (!string.IsNullOrEmpty(frame.Description))
                bytes.AddRange(descriptionEncoding.GetBytes(frame.Description));
            bytes.AddRange(TextEncodingHelper.GetSplitterBytes(frame.Encoding));

            if (frame.PictureData != null && frame.PictureData.Length > 0)
                bytes.AddRange(frame.PictureData);
        }

        protected override void OnDecode(byte[] bytes, PictureFrame frame)
        {
            byte[] mimeType = ByteArrayHelper.GetBytesUptoSequence(bytes, 1, new byte[] { 0x00 });
            if (mimeType == null)
            {
                frame.MimeType = "image/";
                return;
            }

            frame.MimeType = TextEncodingHelper.GetDefaultString(mimeType, 0, mimeType.Length);

            int currentPos = mimeType.Length + 2;
            frame.PictureType = (PictureType)bytes[currentPos];

            currentPos++;
            byte[] description = ByteArrayHelper.GetBytesUptoSequence(bytes, currentPos,
                TextEncodingHelper.GetSplitterBytes(frame.Encoding));
            if (description == null)
            {
                return;
            }
            frame.Description = TextEncodingHelper.GetString(description, 0, description.Length, frame.Encoding);

            currentPos += description.Length + TextEncodingHelper.GetSplitterBytes(frame.Encoding).Length;
            frame.PictureData = new byte[bytes.Length - currentPos];
            Array.Copy(bytes, currentPos, frame.PictureData, 0, frame.PictureData.Length);
        }
    }
}
