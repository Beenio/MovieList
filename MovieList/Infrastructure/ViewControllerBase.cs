using System;
using Foundation;
using MovieList.Shared.Presenters;
using MovieList.Shared.Resources;
using MovieList.Shared.Views;
using SimpleInjector;
using UIKit;

namespace MovieList.Infrastructure
{
    public abstract class ViewControllerBase<T> : UIViewController, IViewBase where T : PresenterBase
    {
        public T Presenter { get; set; }
        protected abstract IViewBase ViewShared { get; }
        protected abstract Container Container { get; }

        public ViewControllerBase(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreatePresenter();
        }

        protected void CreatePresenter()
        {
            Presenter = Container.GetInstance<T>();
        }

        public void ShowMessageAndContinue(string Message, Action Continue)
        {
            InvokeOnMainThread(() =>
            {
                var Okalert = UIAlertController.Create(Strings.Warning, Message, UIAlertControllerStyle.Alert);
                Okalert.AddAction(UIAlertAction.Create(Strings.Ok, UIAlertActionStyle.Default, alert => Continue?.Invoke()));
                this.NavigationController?.PresentViewController(Okalert, true, null);
            });
        }
    }
}
