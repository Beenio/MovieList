using System;
using System.Collections.Generic;
using Foundation;
using MovieList.API.Responses.Movies;
using MovieList.Shared.ViewModels.Movies;
using UIKit;

namespace MovieList.ViewControllers.DataSources.Movies
{
    public class MoviesDataSource : UICollectionViewDataSource
    {
        List<MovieViewModel> Movies;

        public MoviesDataSource(List<MovieViewModel> Movies)
        {
            this.Movies = Movies;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var Cell = collectionView.DequeueReusableCell(MovieViewCell.Key, indexPath) as MovieViewCell;
            Cell.SetupCell(Movies[indexPath.Row]);
            return Cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Movies?.Count ?? 0;
        }
    }
}
