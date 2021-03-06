﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieList.API.Responses.Genres;
using MovieList.Shared.Interactors.Movies;
using MovieList.Shared.Resources;
using MovieList.Shared.ViewModels.Movies;
using MovieList.Shared.Views.Movies;

namespace MovieList.Shared.Presenters.Movies
{
    public class MoviesPresenter : PresenterBase<IMoviesView, IMoviesInteractor>
    {
        int Page = 1;
        List<GenreResponse> Genres = new List<GenreResponse>();

        public MoviesPresenter(IMoviesView View, IMoviesInteractor Interactor) : base(View, Interactor)
        {
        }

        public async Task FetchGenres()
        {
            await Task.Run(async () =>
            {
                try
                {
                    var Response = await Interactor.FetchGenres();
                    Genres.AddRange(Response);
                }
                catch (Exception ex)
                {
                    this.ViewShared.ShowMessageAndContinue(Strings.GenresNotFound, null);
                }
            });
        }

        public async Task FetchMovieList()
        {
            await Task.Run(async () =>
            {
                try
                {
                    var Movies = await DoRequest();
                    this.ViewShared.SetMovies(Movies);
                }
                catch (Exception ex)
                {
                    this.ViewShared.ShowMessageAndContinue(Strings.MoviesNotFound, null);
                }
            });
        }

        public async Task LoadMore()
        {
            await Task.Run(async () =>
            {
                try
                {
                    Page++;
                    var Movies = await DoRequest();
                    this.ViewShared.SetMovies(Movies);
                }
                catch (Exception ex)
                {
                    this.ViewShared.ShowMessageAndContinue(Strings.MoviesNotFound, null);
                }
            });
        }

        async Task<List<MovieViewModel>> DoRequest()
        {
            var Movies = await Interactor.FetchMovieList(Page);
            var MoviesViewModel = Movies?.Select(s =>
            {
                return new MovieViewModel(s, Genres);
            }).ToList();

            return MoviesViewModel;
        }
    }
}
