using System;
using Newtonsoft.Json;

namespace MovieList.API.Responses.Genres
{
    public class GenreResponse : GenericResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
