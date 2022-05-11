using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Id3.MSTest
{
    public class EncodingConverter : JsonConverter<Id3Encoding>
    {
        public override Id3Encoding ReadJson(JsonReader reader, Type objectType, Id3Encoding existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Id3Encoding value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Encoding.EncodingName);
        }
    }
}
