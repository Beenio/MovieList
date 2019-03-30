using System;
using System.Linq;
using System.Threading.Tasks;
using MovieList.Shared.Interactors.Movies;
using MovieList.Shared.Resources;
using MovieList.Shared.ViewModels.Movies;
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
                    var MoviesViewModel = Movies?.Select(s =>
                    {
                        return new MovieViewModel(s);
                    }).ToList();

                this.ViewShared.SetMovies(MoviesViewModel);
                }
                catch (Exception ex)
                {
                    this.ViewShared.ShowMessageAndContinue(Strings.MoviesNotFound, null);
                }
            });
        }
    }
}
