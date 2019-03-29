using System;
using System.Threading.Tasks;
using MovieList.Shared.Interactors.Movies;
using MovieList.Shared.Resources;
using MovieList.Shared.Views.Movies;

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
                catch (Exception)
                {
                    this.ViewShared.ShowMessageAndContinue(Strings.MoviesNotFound, null);
                }
            });
        }
    }
}
