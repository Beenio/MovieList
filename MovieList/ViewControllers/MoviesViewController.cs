using System.Collections.Generic;
using Foundation;
using MovieList.API.Responses.Movies;
using MovieList.Infrastructure;
using MovieList.Shared.Modules.Movies;
using MovieList.Shared.Presenters.Movies;
using MovieList.Shared.Resources;
using MovieList.Shared.ViewModels.Movies;
using MovieList.Shared.Views;
using MovieList.Shared.Views.Movies;
using MovieList.ViewControllers.DataSources.Movies;
using SimpleInjector;
using UIKit;

namespace MovieList.ViewControllers
{
    public partial class MoviesViewController : ViewControllerBase<MoviesPresenter>, IMoviesView, IUICollectionViewDelegateFlowLayout
    {
        protected override IViewBase ViewShared => this;
        protected override Container Container => MoviesModule.NewInstance(this).Container;

        UIEdgeInsets SectionInsets = new UIEdgeInsets(0, 10, 0, 10);

        int ItensPerRow = 2;

        public MoviesViewController() : base("MoviesViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = Strings.MoviesTitle;

            FetchMovies();
        }

        async void FetchMovies()
        {
            await Presenter.FetchMovieList();
        }

        public void SetMovies(List<MovieViewModel> Movies)
        {
            InvokeOnMainThread(() =>
            {
                collectionView.RegisterClassForCell(typeof(MovieViewCell), MovieViewCell.Key);
                collectionView.DataSource = new MoviesDataSource(Movies);
                collectionView.Delegate = this;
                collectionView.ReloadData();
            });
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            var Padding = SectionInsets.Left * (ItensPerRow + 1);
            var AvailableWidth = View.Frame.Width - Padding;
            var WidthPerItem = AvailableWidth / ItensPerRow;
            if (WidthPerItem > 182)
                WidthPerItem = 182;
            return new CoreGraphics.CGSize(WidthPerItem, 300);
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
    }
}

