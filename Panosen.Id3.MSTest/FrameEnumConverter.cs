using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    public class FrameEnumConverter : JsonConverter<FrameEnum>
    {
        public override FrameEnum ReadJson(JsonReader reader, Type objectType, FrameEnum existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, FrameEnum value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
}
