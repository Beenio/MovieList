using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MovieList.API.Enums;
using MovieList.API.Exceptions;
using MovieList.API.Responses.Movies;
using MovieList.API.Services.Movies;
using Newtonsoft.Json;

namespace MovieList.Shared.Interactors.Movies
{
    public class MoviesInteractor : IMoviesInteractor
    {
        public CancellationTokenSource CancellationTokenSource { get; private set; }

        public async Task<List<MovieResponse>> FetchMovieList()
        {
            var Service = new MoviesService();
            var Movies = await Service.FetchMovies();

            return Movies;
        }
    }
}
