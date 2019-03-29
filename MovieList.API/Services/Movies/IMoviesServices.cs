using System.Collections.Generic;
using System.Threading.Tasks;
using MovieList.API.Responses.Movies;

namespace MovieList.API.Services.Movies
{
    public interface IMoviesServices
    {
        Task<List<MovieResponse>> FetchMovies();
    }
}
