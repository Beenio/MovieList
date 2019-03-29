using System;
using MovieList.Shared.Presenters;
using MovieList.Shared.Views;
using UIKit;

namespace MovieList.Infrastructure
{
    public class ViewControllerBase<T> : UIViewController, IViewBase where T : PresenterBase
    {
    }
}
