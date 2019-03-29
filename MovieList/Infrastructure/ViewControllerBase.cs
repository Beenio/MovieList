using Foundation;
using MovieList.Shared.Presenters;
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
    }
}
