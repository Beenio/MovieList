using System;
using System.Collections.Generic;
using System.Linq;
using CoreFoundation;
using Foundation;
using MovieList.Infrastructure;
using MovieList.Shared.Modules.Movies;
using MovieList.Shared.Presenters.Movies;
using MovieList.Shared.Resources;
using MovieList.Shared.ViewModels.Movies;
using MovieList.Shared.Views;
using MovieList.Shared.Views.Movies;
using MovieList.ViewControllers.DataSources.Movies;
using MovieList.ViewControllers.MovieDetails;
using SimpleInjector;
using UIKit;

namespace MovieList.ViewControllers
{
    public partial class MoviesViewController : ViewControllerBase<MoviesPresenter>, IMoviesView, IUICollectionViewDelegateFlowLayout, IUICollectionViewDelegate
    {
        protected override IViewBase ViewShared => this;
        protected override Container Container => MoviesModule.NewInstance(this).Container;

        UIEdgeInsets SectionInsets = new UIEdgeInsets(0, 10, 0, 10);

        int ItensPerRow = 2;
        nfloat MaxWidth = 182;
        bool IsLoading = false;
        List<MovieViewModel> Movies = new List<MovieViewModel>();

        public MoviesViewController() : base("MoviesViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = Strings.MoviesTitle;

            collectionView.RegisterClassForCell(typeof(MovieViewCell), MovieViewCell.Key);
            collectionView.DataSource = new MoviesDataSource(Movies);
            collectionView.Delegate = this;
            Init();
        }

        async void Init()
        {
            await Presenter.FetchGenres();
            await Presenter.FetchMovieList();
        }

        public void SetMovies(List<MovieViewModel> Movies)
        {
            InvokeOnMainThread(() =>
            {
                var paths = Movies.Select(s => NSIndexPath.FromItemSection(Movies.IndexOf(s)+this.Movies.Count, 0)).ToArray();
                this.Movies.AddRange(Movies);
                collectionView.PerformBatchUpdates(delegate {
                    collectionView.InsertItems(paths);
                }, null);
                IsLoading = false;
            });
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            var Padding = SectionInsets.Left * (ItensPerRow + 1);
            var AvailableWidth = View.Frame.Width - Padding;
            var WidthPerItem = AvailableWidth / ItensPerRow;
            if (WidthPerItem > MaxWidth)
                WidthPerItem = MaxWidth;
            return new CoreGraphics.CGSize(WidthPerItem, 360);
        }

        [Export("collectionView:layout:insetForSectionAtIndex:")]
        public UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, System.nint section)
        {
            return SectionInsets;
        }

        [Export("collectionView:layout:minimumLineSpacingForSectionAtIndex:")]
        public System.nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, System.nint section)
        {
            return SectionInsets.Left;
        }

        [Export("collectionView:willDisplayCell:forItemAtIndexPath:")]
        public async void WillDisplayCell(UICollectionView collectionView, UICollectionViewCell cell, NSIndexPath indexPath)
        {
            if (indexPath.Row == Movies.Count - 2 && !IsLoading)
            {
                IsLoading = true;
                await Presenter.LoadMore();
            }
        }

        [Export("collectionView:didSelectItemAtIndexPath:")]
        public void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var Selected = Movies[indexPath.Row];
            this.NavigationController.PushViewController(new MovieDetailsViewController(Selected), true);
        }
    }
}

