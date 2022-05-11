using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Panosen.Id3.Frames;

namespace Panosen.Id3
{
    /// <summary>
    /// FrameHandlerFactory
    /// </summary>
    public static class FrameHandlerFactory
    {

        public static readonly TextFrameHandler textFrameHandler = new TextFrameHandler();

        public static readonly UrlLinkFrameHandler urlLinkFrameHandler = new UrlLinkFrameHandler();

        public static readonly CommentFrameHandler commentFrameHandler = new CommentFrameHandler();

        public static readonly CustomUrlLinkHandler customUrlLinkHandler = new CustomUrlLinkHandler();

        public static readonly LyricsHandler lyricsHandler = new LyricsHandler();

        public static readonly PictureHandler pictureHandler = new PictureHandler();

        public static readonly PrivateHandler privateHandler = new PrivateHandler();

        public static readonly YearFrameHandler yearFrameHandler = new YearFrameHandler();

        public static readonly TposFrameHandler tposFrameHandler = new TposFrameHandler();
    }
}
