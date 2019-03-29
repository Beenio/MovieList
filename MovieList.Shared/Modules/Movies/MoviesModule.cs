using System;
using MovieList.Shared.Interactors.Movies;
using MovieList.Shared.Presenters.Movies;
using MovieList.Shared.Views.Movies;
using SimpleInjector;

namespace MovieList.Shared.Modules.Movies
{
    public class MoviesModule : ModuleBase
    {
        private MoviesModule(IMoviesView View) 
        {
            Container.Register(() => View, Lifestyle.Transient);
            Container.Register<IMoviesInteractor, MoviesInteractor>();
            Container.Register<MoviesPresenter>();
            Container.Verify();
        }

        public MoviesModule NewInstance(IMoviesView View)
        {
            return new MoviesModule(View);
        }
    }
}
