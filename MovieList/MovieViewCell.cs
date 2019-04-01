using CoreFoundation;
using Foundation;
using MovieList.API.Responses.Movies;
using MovieList.Shared.ViewModels.Movies;
using System;
using UIKit;

namespace MovieList
{
    public partial class MovieViewCell : UICollectionViewCell
    {
        public static string Key = "MovieCell";
        bool Created = false;

        UIImageView ImageView;
        UILabel TitleLabel, Genres, ReleaseDate;
        NSUrlSessionDataTask Data;

        public MovieViewCell (IntPtr handle) : base (handle)
        {
        }

        public async void SetupCell(MovieViewModel Movie)
        {
            Data?.Cancel();
            Data = null;

            if (!Created)
                CreateComponents();

            ImageView.Image = null;
            TitleLabel.Text = Movie.Title;
            Genres.Text = Movie.Genres;
            ReleaseDate.Text = Movie.ReleaseDate;

            var Request = NSUrlSession.SharedSession.CreateDataTaskAsync(new NSUrl(Movie.Poster), out Data);
            Data.Resume();

            try
            {
                var Response = await Request;

                if (Response != null && Response.Data != null)
                {
                    var Image = new UIImage(Response.Data);
                    DispatchQueue.MainQueue.DispatchAsync(() =>
                    {
                        ImageView.Image = Image;
                    });
                }
            }
            catch (Exception) { }
        }

        void CreateComponents()
        {
            ImageView = new UIImageView()
            {
                ContentMode = UIViewContentMode.ScaleAspectFit,
            };

            this.AddSubview(ImageView);
            this.BackgroundColor = UIColor.FromRGB(239, 239, 239);
            this.Layer.CornerRadius = 10;
            this.Layer.MasksToBounds = true;

            ImageView.TranslatesAutoresizingMaskIntoConstraints = false;

            ImageView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            ImageView.TopAnchor.ConstraintEqualTo(TopAnchor, 5).Active = true;
            ImageView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            ImageView.WidthAnchor.ConstraintEqualTo(WidthAnchor).Active = true;
            ImageView.HeightAnchor.ConstraintEqualTo(245).Active = true;
            ImageView.Layer.CornerRadius = 10;
            ImageView.Layer.MasksToBounds = true;

            TitleLabel = new UILabel();

            this.AddSubview(TitleLabel);

            TitleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            TitleLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            TitleLabel.TopAnchor.ConstraintEqualTo(ImageView.BottomAnchor, 2).Active = true;
            TitleLabel.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            TitleLabel.WidthAnchor.ConstraintEqualTo(WidthAnchor).Active = true;
            TitleLabel.Lines = 2;
            TitleLabel.LineBreakMode = UILineBreakMode.TailTruncation;
            TitleLabel.TextAlignment = UITextAlignment.Center;

            var Content = new UIView();

            this.AddSubview(Content);

            Content.TranslatesAutoresizingMaskIntoConstraints = false;
            Content.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 10).Active = true;
            Content.TopAnchor.ConstraintEqualTo(TitleLabel.BottomAnchor, 5).Active = true;
            Content.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 10 * -1).Active = true;
            Content.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

            var LineView = new UIView();
            LineView.BackgroundColor = UIColor.LightGray;

            Content.AddSubview(LineView);

            LineView.TranslatesAutoresizingMaskIntoConstraints = false;
            LineView.LeadingAnchor.ConstraintEqualTo(Content.LeadingAnchor).Active = true;
            LineView.TopAnchor.ConstraintEqualTo(Content.TopAnchor).Active = true;
            LineView.TrailingAnchor.ConstraintEqualTo(Content.TrailingAnchor).Active = true;
            LineView.HeightAnchor.ConstraintEqualTo(1).Active = true;

            Genres = new UILabel();
            Genres.Lines = 2;
            Genres.LineBreakMode = UILineBreakMode.TailTruncation;
            Genres.Font = UIFont.SystemFontOfSize(12);

            this.AddSubview(Genres);

            Genres.TranslatesAutoresizingMaskIntoConstraints = false;
            Genres.LeadingAnchor.ConstraintEqualTo(Content.LeadingAnchor).Active = true;
            Genres.TopAnchor.ConstraintEqualTo(LineView.BottomAnchor,5).Active = true;
            Genres.TrailingAnchor.ConstraintEqualTo(Content.TrailingAnchor).Active = true;

            ReleaseDate = new UILabel();
            ReleaseDate.LineBreakMode = UILineBreakMode.TailTruncation;
            ReleaseDate.Font = UIFont.BoldSystemFontOfSize(12);
            ReleaseDate.TextColor = UIColor.DarkGray;

            Content.AddSubview(ReleaseDate);

            ReleaseDate.TranslatesAutoresizingMaskIntoConstraints = false;
            ReleaseDate.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 10).Active = true;
            ReleaseDate.TopAnchor.ConstraintEqualTo(Genres.BottomAnchor, 5).Active = true;
            ReleaseDate.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 10 * -1).Active = true;
            ReleaseDate.BottomAnchor.ConstraintEqualTo(Content.BottomAnchor);

            Created = true;
        }
    }
}