using System;
namespace MovieList.Shared.Views
{
    public interface IViewBase
    {
        void ShowMessageAndContinue(string Message, Action Continue);
    }
}
