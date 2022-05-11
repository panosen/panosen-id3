using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3
{
    /// <summary>
    /// https://id3.org/id3v2.3.0#Declared_ID3v2_frames
    /// </summary>
    public class FrameConstant
    {
        /// <summary>
        /// #sec4.20|Audio encryption
        /// </summary>
        public const string AENC = "AENC";

        /// <summary>
        /// #sec4.15 Attached picture
        /// </summary>
        public const string APIC = "APIC";

        /// <summary>
        /// #sec4.11 Comments
        /// </summary>
        public const string COMM = "COMM";

        /// <summary>
        /// #sec4.25 Commercial frame
        /// </summary>
        public const string COMR = "COMR";

        /// <summary>
        /// #sec4.26 Encryption method registration
        /// </summary>
        public const string ENCR = "ENCR";

        /// <summary>
        /// #sec4.13 Equalization
        /// </summary>
        public const string EQUA = "EQUA";

        /// <summary>
        /// #sec4.6 Event timing codes
        /// </summary>
        public const string ETCO = " ETCO";

        /// <summary>
        /// #sec4.16 General encapsulated object
        /// </summary>
        public const string GEOB = "GEOB";

        /// <summary>
        /// #sec4.27 Group identification registration
        /// </summary>
        public const string GRID = "GRID";

        /// <summary>
        /// #sec4.4 Involved people list
        /// </summary>
        public const string IPLS = " IPLS";

        /// <summary>
        /// #sec4.21 Linked information
        /// </summary>
        public const string LINK = "LINK";

        /// <summary>
        /// #sec4.5 Music CD identifier
        /// </summary>
        public const string MCDI = " MCDI";

        /// <summary>
        /// #sec4.7 MPEG location lookup table
        /// </summary>
        public const string MLLT = " MLLT";

        /// <summary>
        /// #sec4.24 Ownership frame
        /// </summary>
        public const string OWNE = "OWNE";

        /// <summary>
        /// #sec4.28 Private frame
        /// </summary>
        public const string PRIV = "PRIV";

        /// <summary>
        /// #sec4.17 Play counter
        /// </summary>
        public const string PCNT = "PCNT";

        /// <summary>
        /// #sec4.18 Popularimeter
        /// </summary>
        public const string POPM = "POPM";

        /// <summary>
        /// #sec4.22 Position synchronisation frame
        /// </summary>
        public const string POSS = "POSS";

        /// <summary>
        /// #sec4.19 Recommended buffer size
        /// </summary>
        public const string RBUF = "RBUF";

        /// <summary>
        /// #sec4.12 Relative volume adjustment
        /// </summary>
        public const string RVAD = "RVAD";

        /// <summary>
        /// #sec4.14 Reverb
        /// </summary>
        public const string RVRB = "RVRB";

        /// <summary>
        /// #sec4.10 Synchronized lyric/text
        /// </summary>
        public const string SYLT = "SYLT";

        /// <summary>
        /// #sec4.8 Synchronized tempo codes
        /// </summary>
        public const string SYTC = " SYTC";

        /// <summary>
        /// #TALB Album/Movie/Show title
        /// </summary>
        public const string TALB = "TALB";

        /// <summary>
        /// #TBPM BPM (beats per minute)
        /// </summary>
        public const string TBPM = "TBPM";

        /// <summary>
        /// #TCOM Composer
        /// </summary>
        public const string TCOM = "TCOM";

        /// <summary>
        /// #TCON Content type
        /// </summary>
        public const string TCON = "TCON";

        /// <summary>
        /// #TCOP Copyright message
        /// </summary>
        public const string TCOP = "TCOP";

        /// <summary>
        /// #TDAT Date
        /// </summary>
        public const string TDAT = "TDAT";

        /// <summary>
        /// #TDLY Playlist delay
        /// </summary>
        public const string TDLY = "TDLY";

        /// <summary>
        /// #TENC Encoded by
        /// </summary>
        public const string TENC = "TENC";

        /// <summary>
        /// #TEXT Lyricist/Text writer
        /// </summary>
        public const string TEXT = "TEXT";

        /// <summary>
        /// #TFLT File type
        /// </summary>
        public const string TFLT = "TFLT";

        /// <summary>
        /// #TIME Time
        /// </summary>
        public const string TIME = "TIME";

        /// <summary>
        /// #TIT1 Content group description
        /// </summary>
        public const string TIT1 = "TIT1";

        /// <summary>
        /// #TIT2 Title/songname/content description
        /// </summary>
        public const string TIT2 = "TIT2";

        /// <summary>
        /// #TIT3 Subtitle/Description refinement
        /// </summary>
        public const string TIT3 = "TIT3";

        /// <summary>
        /// #TKEY Initial key
        /// </summary>
        public const string TKEY = "TKEY";

        /// <summary>
        /// #TLAN Language(s)
        /// </summary>
        public const string TLAN = "TLAN";

        /// <summary>
        /// #TLEN Length
        /// </summary>
        public const string TLEN = "TLEN";

        /// <summary>
        /// #TMED Media type
        /// </summary>
        public const string TMED = "TMED";

        /// <summary>
        /// #TOAL Original album/movie/show title
        /// </summary>
        public const string TOAL = "TOAL";

        /// <summary>
        /// #TOFN Original filename
        /// </summary>
        public const string TOFN = "TOFN";

        /// <summary>
        /// #TOLY Original lyricist(s)/text writer(s)
        /// </summary>
        public const string TOLY = "TOLY";

        /// <summary>
        /// #TOPE Original artist(s)/performer(s)
        /// </summary>
        public const string TOPE = "TOPE";

        /// <summary>
        /// #TORY Original release year
        /// </summary>
        public const string TORY = "TORY";

        /// <summary>
        /// #TOWN File owner/licensee
        /// </summary>
        public const string TOWN = "TOWN";

        /// <summary>
        /// #TPE1 Lead performer(s)/Soloist(s)
        /// </summary>
        public const string TPE1 = "TPE1";

        /// <summary>
        /// #TPE2 Band/orchestra/accompaniment
        /// </summary>
        public const string TPE2 = "TPE2";

        /// <summary>
        /// #TPE3 Conductor/performer refinement
        /// </summary>
        public const string TPE3 = "TPE3";

        /// <summary>
        /// #TPE4 Interpreted, remixed, or otherwise modified by
        /// </summary>
        public const string TPE4 = "TPE4";

        /// <summary>
        /// #TPOS Part of a set
        /// </summary>
        public const string TPOS = "TPOS";

        /// <summary>
        /// #TPUB Publisher
        /// </summary>
        public const string TPUB = "TPUB";

        /// <summary>
        /// #TRCK Track number/Position in set
        /// </summary>
        public const string TRCK = "TRCK";

        /// <summary>
        /// #TRDA Recording dates
        /// </summary>
        public const string TRDA = "TRDA";

        /// <summary>
        /// #TRSN Internet radio station name
        /// </summary>
        public const string TRSN = "TRSN";

        /// <summary>
        /// #TRSO Internet radio station owner
        /// </summary>
        public const string TRSO = "TRSO";

        /// <summary>
        /// #TSIZ Size
        /// </summary>
        public const string TSIZ = "TSIZ";

        /// <summary>
        /// #TSRC ISRC (international standard recording code)
        /// </summary>
        public const string TSRC = "TSRC";

        /// <summary>
        /// #TSEE Software/Hardware and settings used for encoding
        /// </summary>
        public const string TSSE = "TSSE";

        /// <summary>
        /// #TYER Year
        /// </summary>
        public const string TYER = "TYER";

        /// <summary>
        /// #TXXX User defined text information frame
        /// </summary>
        public const string TXXX = "TXXX";

        /// <summary>
        /// #sec4.1 Unique file identifier
        /// </summary>
        public const string UFID = " UFID";

        /// <summary>
        /// #sec4.23 Terms of use
        /// </summary>
        public const string USER = "USER";

        /// <summary>
        /// #sec4.9 Unsychronized lyric/text transcription
        /// </summary>
        public const string USLT = " USLT";

        /// <summary>
        /// #WCOM Commercial information
        /// </summary>
        public const string WCOM = "WCOM";

        /// <summary>
        /// #WCOP Copyright/Legal information
        /// </summary>
        public const string WCOP = "WCOP";

        /// <summary>
        /// #WOAF Official audio file webpage
        /// </summary>
        public const string WOAF = "WOAF";

        /// <summary>
        /// #WOAR Official artist/performer webpage
        /// </summary>
        public const string WOAR = "WOAR";

        /// <summary>
        /// #WOAS Official audio source webpage
        /// </summary>
        public const string WOAS = "WOAS";

        /// <summary>
        /// #WORS Official internet radio station homepage
        /// </summary>
        public const string WORS = "WORS";

        /// <summary>
        /// #WPAY Payment
        /// </summary>
        public const string WPAY = "WPAY";

        /// <summary>
        /// #WPUB Publishers official webpage
        /// </summary>
        public const string WPUB = "WPUB";

        /// <summary>
        /// #WXXX User defined URL link frame
        /// </summary>
        public const string WXXX = "WXXX";
    }
}
