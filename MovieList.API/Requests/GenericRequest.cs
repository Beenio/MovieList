using System;
using Newtonsoft.Json;

namespace MovieList.API.Requests
{
    public class GenericRequest
    {
        [JsonIgnore]
        public string Host { get; set; }
        [JsonIgnore]
        public string Url { get; set; }
        [JsonIgnore]
        public int Timeout { get; set; } = 30;
        [JsonIgnore]
        public long MaxResponseContentBufferSize { get; set; } = long.MaxValue;

        public GenericRequest(string URL)
        {
            this.Url = URL;
        }
    }
}
