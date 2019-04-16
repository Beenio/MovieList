using System.Collections.Generic;
using System.Threading.Tasks;
using MovieList.API.Constants;
using MovieList.API.Requests;
using MovieList.API.Responses.Genres;
using MovieList.API.Responses.Movies;

namespace MovieList.API.Services.Movies
{
    public class MoviesService : ServiceBase, IMoviesServices
    {
        public async Task<List<GenreResponse>> FetchGenres()
        {
            var Request = new GenericRequest(EndPoints.GenreList);
            var Response = await DoGet<GenericRequest, GenreListResponse>(Request);

            return Response?.Genres ?? new List<GenreResponse>();
        }

        public async Task<List<MovieResponse>> FetchMovies(int Page)
        {
            var Request = new GenericRequest(string.Format(EndPoints.MoviesList,Page));
            var Response = await DoGet<GenericRequest, MovieListResponse>(Request);

            return Response?.Movies ?? new List<MovieResponse>();
        }
    }
}
