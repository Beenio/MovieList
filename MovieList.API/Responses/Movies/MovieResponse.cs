using Newtonsoft.Json;

namespace MovieList.API.Responses.Movies
{
    public class MovieResponse : GenericResponse
    {
        [JsonProperty("vote_average")]
        public string VoteAverage { get; set; }
        [JsonProperty("popularity")]
        public string Popularity { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("overview")]
        public string Description { get; set; }
        [JsonProperty("poster_path")]
        public string Poster { get; set; }
    }
}
