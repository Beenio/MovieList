using System;
namespace MovieList.API.Constants
{
    public class EndPoints
    {
        const string APIKEY = "1f54bd990f1cdfb230adb312546d765d";
        public static string MoviesList = $"https://api.themoviedb.org/3/movie/upcoming?api_key={APIKEY}&page={{0}}";
    }
}
