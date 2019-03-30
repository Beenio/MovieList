using System;
using MovieList.API.Responses.Movies;
using MovieList.Shared.Constants;

namespace MovieList.Shared.ViewModels.Movies
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }

        public MovieViewModel(MovieResponse Movie)
        {
            if(Movie != null)
            {
                this.Title = Movie.Title;
                this.Description = Movie.Description;
                this.Poster = URLConstants.URL_IMAGE + Movie.Poster;
            }
        }
    }
}
