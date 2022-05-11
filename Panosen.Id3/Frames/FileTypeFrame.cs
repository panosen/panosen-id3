using System.Collections.Generic;
using System.Linq;

namespace Panosen.Id3.Frames
{

    //private static readonly Dictionary<string, FileAudioType> FileAudioTypeMapping = new Dictionary<string, FileAudioType>(8)
    //{
    //    ["MPG"] = FileAudioType.Mpeg,
    //    ["MPG/1"] = FileAudioType.Mpeg_1_2_Layer1,
    //    ["MPG/2"] = FileAudioType.Mpeg_1_2_Layer2,
    //    ["MPG/3"] = FileAudioType.Mpeg_1_2_Layer3,
    //    ["MPG/2.5"] = FileAudioType.Mpeg_2_5,
    //    ["MPG/AAC"] = FileAudioType.Mpeg_Aac,
    //    ["VQF"] = FileAudioType.Vqf,
    //    ["PCM"] = FileAudioType.Pcm
    //};

    public enum FileAudioType
    {
        Mpeg,
        Mpeg_1_2_Layer1,
        Mpeg_1_2_Layer2,
        Mpeg_1_2_Layer3,
        Mpeg_2_5,
        Mpeg_Aac,
        Vqf,
        Pcm,
    }
}