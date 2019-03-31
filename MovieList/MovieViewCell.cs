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
        UILabel TitleLabel;

        public MovieViewCell (IntPtr handle) : base (handle)
        {
        }

        public void SetupCell(MovieViewModel Movie)
        {
            if (!Created)
                CreateComponents();

            ImageView.Image = null;
            TitleLabel.Text = Movie.Title;

            NSUrlSession.SharedSession.CreateDataTask(new NSUrl(Movie.Poster), (data, response, error) =>
            {
                if(data != null)
                {
                    try
                    {
                        var Image = new UIImage(data);
                        DispatchQueue.MainQueue.DispatchAsync(() => {
                            ImageView.Image = Image;
                        });
                    }
                    catch (Exception) { }
                }
            }).Resume();
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

            Created = true;
        }
    }
}