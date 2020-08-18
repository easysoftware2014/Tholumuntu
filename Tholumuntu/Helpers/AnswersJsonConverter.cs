using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tholumuntu.Helpers
{
    public class AnswersJsonConverter
    {
        [JsonProperty("key")]
        public long Key { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}