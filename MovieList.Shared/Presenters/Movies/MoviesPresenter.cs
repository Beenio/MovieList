using System;
using System.Net.Http;
using System.Threading.Tasks;
using MovieList.API.Constants;
using MovieList.API.Requests;
using MovieList.API.Responses.Movies;
using MovieList.Shared.Interactors.Movies;
using MovieList.Shared.Views.Movies;
using Newtonsoft.Json;

namespace MovieList.Shared.Presenters.Movies
{
    public class MoviesPresenter : PresenterBase<IMoviesView, IMoviesInteractor>
    {
        public MoviesPresenter(IMoviesView View, IMoviesInteractor Interactor) : base(View, Interactor)
        {
        }

        public async Task FetchMovieList()
        {
            await Task.Run(async () =>
            {
                try
                {
                    var Movies = await Interactor.FetchMovieList();
                }
                catch (Exception ex)
                {

                }
            });
        }
    }
}
