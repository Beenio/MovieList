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
        UIImage Image;

        public MovieDetailsViewController(MovieViewModel Movie, UIImage Image) : base("MovieDetailsViewController", null)
        {
            this.Movie = Movie;
            this.Image = Image;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupView();
        }
        public void SetupView()
        {
            ivPoster.Image = Image;
            tfGenres.Text = Movie.Genres;
            tfDescription.Text = Movie.Description;
            tfReleaseDate.Text = Movie.ReleaseDate;
            tfMovieName.Text = Movie.Title;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public void SetMovies(List<MovieViewModel> Movies)
        {
            throw new System.NotImplementedException();
        }
    }
}
