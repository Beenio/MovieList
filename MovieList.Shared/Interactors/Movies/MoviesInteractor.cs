using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MovieList.API.Responses.Genres;
using MovieList.API.Responses.Movies;
using MovieList.API.Services.Movies;

namespace MovieList.Shared.Interactors.Movies
{
    public class MoviesInteractor : IMoviesInteractor
    {
        public CancellationTokenSource CancellationTokenSource { get; private set; }

        public async Task<List<GenreResponse>> FetchGenres()
        {
            var Service = new MoviesService();
            var Genres = await Service.FetchGenres();

            return Genres;
        }

        public async Task<List<MovieResponse>> FetchMovieList(int Page)
        {
            var Service = new MoviesService();
            var Movies = await Service.FetchMovies(Page);

            return Movies;
        }
    }
}
