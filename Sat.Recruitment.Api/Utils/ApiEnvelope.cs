
using Newtonsoft.Json;

namespace Sat.Recruitment.Api.Utils
{
    public class ApiEnvelope<TData> where TData : class
    {
        public ApiEnvelope(string link, string meta, TData data)
        {

            Link = link;
            Meta = meta;
            Data = data;

        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }
               
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Meta { get; set; }
     
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }
    }
}
