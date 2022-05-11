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
    public enum FrameEnum
    {
        /// <summary>
        /// NONE
        /// </summary>
        NONE,

        /// <summary>
        /// #sec4.20|Audio encryption
        /// </summary>
        AENC,

        /// <summary>
        /// #sec4.15 Attached picture
        /// </summary>
        APIC,

        /// <summary>
        /// #sec4.11 Comments
        /// </summary>
        COMM,

        /// <summary>
        /// #sec4.25 Commercial frame
        /// </summary>
        COMR,

        /// <summary>
        /// #sec4.26 Encryption method registration
        /// </summary>
        ENCR,

        /// <summary>
        /// #sec4.13 Equalization
        /// </summary>
        EQUA,

        /// <summary>
        /// #sec4.6 Event timing codes
        /// </summary>
        ETCO,

        /// <summary>
        /// #sec4.16 General encapsulated object
        /// </summary>
        GEOB,

        /// <summary>
        /// #sec4.27 Group identification registration
        /// </summary>
        GRID,

        /// <summary>
        /// #sec4.4 Involved people list
        /// </summary>
        IPLS,

        /// <summary>
        /// #sec4.21 Linked information
        /// </summary>
        LINK,

        /// <summary>
        /// #sec4.5 Music CD identifier
        /// </summary>
        MCDI,

        /// <summary>
        /// #sec4.7 MPEG location lookup table
        /// </summary>
        MLLT,

        /// <summary>
        /// #sec4.24 Ownership frame
        /// </summary>
        OWNE,

        /// <summary>
        /// #sec4.28 Private frame
        /// </summary>
        PRIV,

        /// <summary>
        /// #sec4.17 Play counter
        /// </summary>
        PCNT,

        /// <summary>
        /// #sec4.18 Popularimeter
        /// </summary>
        POPM,

        /// <summary>
        /// #sec4.22 Position synchronisation frame
        /// </summary>
        POSS,

        /// <summary>
        /// #sec4.19 Recommended buffer size
        /// </summary>
        RBUF,

        /// <summary>
        /// #sec4.12 Relative volume adjustment
        /// </summary>
        RVAD,

        /// <summary>
        /// #sec4.14 Reverb
        /// </summary>
        RVRB,

        /// <summary>
        /// #sec4.10 Synchronized lyric/text
        /// </summary>
        SYLT,

        /// <summary>
        /// #sec4.8 Synchronized tempo codes
        /// </summary>
        SYTC,

        /// <summary>
        /// #TALB Album/Movie/Show title
        /// </summary>
        TALB,

        /// <summary>
        /// #TBPM BPM (beats per minute)
        /// </summary>
        TBPM,

        /// <summary>
        /// #TCOM Composer
        /// </summary>
        TCOM,

        /// <summary>
        /// #TCON Content type
        /// </summary>
        TCON,

        /// <summary>
        /// #TCOP Copyright message
        /// </summary>
        TCOP,

        /// <summary>
        /// #TDAT Date
        /// </summary>
        TDAT,

        /// <summary>
        /// #TDLY Playlist delay
        /// </summary>
        TDLY,

        /// <summary>
        /// #TENC Encoded by
        /// </summary>
        TENC,

        /// <summary>
        /// #TEXT Lyricist/Text writer
        /// </summary>
        TEXT,

        /// <summary>
        /// #TFLT File type
        /// </summary>
        TFLT,

        /// <summary>
        /// #TIME Time
        /// </summary>
        TIME,

        /// <summary>
        /// #TIT1 Content group description
        /// </summary>
        TIT1,

        /// <summary>
        /// #TIT2 Title/songname/content description
        /// </summary>
        TIT2,

        /// <summary>
        /// #TIT3 Subtitle/Description refinement
        /// </summary>
        TIT3,

        /// <summary>
        /// #TKEY Initial key
        /// </summary>
        TKEY,

        /// <summary>
        /// #TLAN Language(s)
        /// </summary>
        TLAN,

        /// <summary>
        /// #TLEN Length
        /// </summary>
        TLEN,

        /// <summary>
        /// #TMED Media type
        /// </summary>
        TMED,

        /// <summary>
        /// #TOAL Original album/movie/show title
        /// </summary>
        TOAL,

        /// <summary>
        /// #TOFN Original filename
        /// </summary>
        TOFN,

        /// <summary>
        /// #TOLY Original lyricist(s)/text writer(s)
        /// </summary>
        TOLY,

        /// <summary>
        /// #TOPE Original artist(s)/performer(s)
        /// </summary>
        TOPE,

        /// <summary>
        /// #TORY Original release year
        /// </summary>
        TORY,

        /// <summary>
        /// #TOWN File owner/licensee
        /// </summary>
        TOWN,

        /// <summary>
        /// #TPE1 Lead performer(s)/Soloist(s)
        /// </summary>
        TPE1,

        /// <summary>
        /// #TPE2 Band/orchestra/accompaniment
        /// </summary>
        TPE2,

        /// <summary>
        /// #TPE3 Conductor/performer refinement
        /// </summary>
        TPE3,

        /// <summary>
        /// #TPE4 Interpreted, remixed, or otherwise modified by
        /// </summary>
        TPE4,

        /// <summary>
        /// #TPOS Part of a set
        /// </summary>
        TPOS,

        /// <summary>
        /// #TPUB Publisher
        /// </summary>
        TPUB,

        /// <summary>
        /// #TRCK Track number/Position in set
        /// </summary>
        TRCK,

        /// <summary>
        /// #TRDA Recording dates
        /// </summary>
        TRDA,

        /// <summary>
        /// #TRSN Internet radio station name
        /// </summary>
        TRSN,

        /// <summary>
        /// #TRSO Internet radio station owner
        /// </summary>
        TRSO,

        /// <summary>
        /// #TSIZ Size
        /// </summary>
        TSIZ,

        /// <summary>
        /// #TSRC ISRC (international standard recording code)
        /// </summary>
        TSRC,

        /// <summary>
        /// #TSEE Software/Hardware and settings used for encoding
        /// </summary>
        TSSE,

        /// <summary>
        /// #TYER Year
        /// </summary>
        TYER,

        /// <summary>
        /// #TXXX User defined text information frame
        /// </summary>
        TXXX,

        /// <summary>
        /// #sec4.1 Unique file identifier
        /// </summary>
        UFID,

        /// <summary>
        /// #sec4.23 Terms of use
        /// </summary>
        USER,

        /// <summary>
        /// #sec4.9 Unsychronized lyric/text transcription
        /// </summary>
        USLT,

        /// <summary>
        /// #WCOM Commercial information
        /// </summary>
        WCOM,

        /// <summary>
        /// #WCOP Copyright/Legal information
        /// </summary>
        WCOP,

        /// <summary>
        /// #WOAF Official audio file webpage
        /// </summary>
        WOAF,

        /// <summary>
        /// #WOAR Official artist/performer webpage
        /// </summary>
        WOAR,

        /// <summary>
        /// #WOAS Official audio source webpage
        /// </summary>
        WOAS,

        /// <summary>
        /// #WORS Official internet radio station homepage
        /// </summary>
        WORS,

        /// <summary>
        /// #WPAY Payment
        /// </summary>
        WPAY,

        /// <summary>
        /// #WPUB Publishers official webpage
        /// </summary>
        WPUB,

        /// <summary>
        /// #WXXX User defined URL link frame
        /// </summary>
        WXXX,
    }
}
