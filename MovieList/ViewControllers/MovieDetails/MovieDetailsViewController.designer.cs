// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MovieList.ViewControllers.MovieDetails
{
    [Register ("MovieDetailsViewController")]
    partial class MovieDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivPoster { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tfDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tfGenres { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tfMovieName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tfReleaseDate { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ivPoster != null) {
                ivPoster.Dispose ();
                ivPoster = null;
            }

            if (tfDescription != null) {
                tfDescription.Dispose ();
                tfDescription = null;
            }

            if (tfGenres != null) {
                tfGenres.Dispose ();
                tfGenres = null;
            }

            if (tfMovieName != null) {
                tfMovieName.Dispose ();
                tfMovieName = null;
            }

            if (tfReleaseDate != null) {
                tfReleaseDate.Dispose ();
                tfReleaseDate = null;
            }
        }
    }
}