using System;
using MovieList.Infrastructure;
using MovieList.Shared.Presenters.Movies;
using MovieList.Shared.Views.Movies;

namespace MovieList.ViewControllers
{
    public class MoviesViewController : ViewControllerBase<MoviesPresenter>, IMoviesView
    {
    }
}
