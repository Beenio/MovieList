using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieList.API.Responses.Movies
{
    public class MovieListResponse : GenericResponse
    {
        [JsonProperty("results")]
        public List<MovieResponse> Movies { get; set; }
    }
}
