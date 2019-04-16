using System;
using System.Collections.Generic;
using MovieList.API.Responses.Movies;
using MovieList.Shared.ViewModels.Movies;

namespace MovieList.Shared.Views.Movies
{
    public interface IMoviesView : IViewBase
    {
        void SetMovies(List<MovieViewModel> Movies);
    }
}
