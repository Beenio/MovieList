using MovieList.Shared.Interactors.Movies;
using MovieList.Shared.Views.Movies;

namespace MovieList.Shared.Presenters.Movies
{
    public class MoviesPresenter : PresenterBase<IMoviesView, IMoviesInteractor>
    {
        public MoviesPresenter(IMoviesView View, IMoviesInteractor Interactor) : base(View, Interactor)
        {
        }
    }
}
