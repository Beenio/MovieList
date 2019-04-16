using System.Collections.Generic;
using System.Threading.Tasks;
using MovieList.API.Responses.Genres;
using MovieList.API.Responses.Movies;

namespace MovieList.Shared.Interactors.Movies
{
    public interface IMoviesInteractor : IInteractorBase
    {
        Task<List<MovieResponse>> FetchMovieList(int Page);
        Task<List<GenreResponse>> FetchGenres();
    }
}
