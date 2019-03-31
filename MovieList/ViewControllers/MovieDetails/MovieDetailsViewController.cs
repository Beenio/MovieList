using System.Collections.Generic;
using MovieList.Infrastructure;
using MovieList.Shared.Modules.Movies;
using MovieList.Shared.Presenters.Movies;
using MovieList.Shared.ViewModels.Movies;
using MovieList.Shared.Views;
using MovieList.Shared.Views.Movies;
using SimpleInjector;
using UIKit;

namespace MovieList.ViewControllers.MovieDetails
{
    public partial class MovieDetailsViewController : ViewControllerBase<MoviesPresenter>, IMoviesView
    {
        protected override IViewBase ViewShared => this;
        protected override Container Container => MoviesModule.NewInstance(this).Container;

        MovieViewModel Movie;

        public MovieDetailsViewController(MovieViewModel Movie) : base("MovieDetailsViewController", null)
        {
            this.Movie = Movie;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void SetMovies(List<MovieViewModel> Movies)
        {
            throw new System.NotImplementedException();
        }
    }
}
