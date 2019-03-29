using MovieList.Infrastructure;
using MovieList.Shared.Modules.Movies;
using MovieList.Shared.Presenters.Movies;
using MovieList.Shared.Views;
using MovieList.Shared.Views.Movies;
using SimpleInjector;

namespace MovieList.ViewControllers
{
    public partial  class MoviesViewController : ViewControllerBase<MoviesPresenter>, IMoviesView
    {
        protected override IViewBase ViewShared => this;
        protected override Container Container => MoviesModule.NewInstance(this).Container;

        public MoviesViewController() : base("MoviesViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            FetchMovies();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        async void FetchMovies()
        {
            await Presenter.FetchMovieList();
        }
    }
}

