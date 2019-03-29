using MovieList.Shared.Interactors;
using MovieList.Shared.Views;

namespace MovieList.Shared.Presenters
{
    public abstract partial class PresenterBase
    {
        protected IViewBase ViewShared { get; set; }
        protected IInteractorBase Interactor { get; set; }
        public PresenterBase(IViewBase view, IInteractorBase interactor)
        {
            ViewShared = view;
            Interactor = interactor;
        }
    }

    public abstract class PresenterBase<V, I> : PresenterBase where V : IViewBase where I : IInteractorBase
    {
        public PresenterBase(V view, I interactor) : base(view, interactor)
        {
        }

        protected new V ViewShared
        {
            get
            {
                return (V)base.ViewShared;
            }
            set
            {
                base.ViewShared = value;
            }
        }

        protected new I Interactor
        {
            get
            {
                return (I)base.Interactor;
            }
            set
            {
                base.Interactor = value;
            }
        }
    }
}
