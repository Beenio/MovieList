using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MovieList.API.Responses.Genres;
using MovieList.API.Responses.Movies;
using MovieList.Shared.Constants;

namespace MovieList.Shared.ViewModels.Movies
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string ReleaseDate { get; set; }
        public string Genres { get; set; }

        public MovieViewModel(MovieResponse Movie, List<GenreResponse> Genres)
        {
            if(Movie != null)
            {
                this.Title = Movie.Title;
                this.Description = Movie.Description;
                this.Poster = URLConstants.URL_IMAGE + Movie.Poster;
                var AllGenres = Genres.Where(w => Movie.GenreIds.Contains(w.Id)). Select(s =>
                {
                    return s.Name;
                });

                this.Genres = string.Join(",", AllGenres);

                DateTime Date = DateTime.MinValue;
                bool Done = DateTime.TryParseExact(Movie.ReleaseDate,"yyyy-MM-dd", null , DateTimeStyles.None,out Date);
                if (Done)
                    ReleaseDate = Date.ToString("dd/MM/yyyy");

            }
        }
    }
}
