using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieList.API.Responses.Genres
{
    public class GenreListResponse : GenericResponse
    {
        [JsonProperty("genres")]
        public List<GenreResponse> Genres { get; set; }
    }
}
