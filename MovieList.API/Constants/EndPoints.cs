using System;
namespace MovieList.API.Constants
{
    public class EndPoints
    {
        const string APIKEY = "1f54bd990f1cdfb230adb312546d765d";
        const string BASE = "https://api.themoviedb.org/3";
        public static string MoviesList = $"{BASE}/movie/upcoming?api_key={APIKEY}&page={{0}}";
        public static string GenreList = $"{BASE}/genre/movie/list?api_key={APIKEY}";
    }
}
