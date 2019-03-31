using System.Collections.Generic;
using System.Threading.Tasks;
using MovieList.API.Constants;
using MovieList.API.Requests;
using MovieList.API.Responses.Movies;

namespace MovieList.API.Services.Movies
{
    public class MoviesService : ServiceBase, IMoviesServices
    {
        public async Task<List<MovieResponse>> FetchMovies(int Page)
        {
            var Request = new GenericRequest(string.Format(EndPoints.MoviesList,Page));
            var Response = await DoGet<GenericRequest, MovieListResponse>(Request);

            return Response?.Movies ?? new List<MovieResponse>();
        }
    }
}
