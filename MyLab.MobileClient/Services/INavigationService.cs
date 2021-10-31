using System;
using System.Threading.Tasks;
using MyLab.MobileClient.ViewModels;
using Xamarin.Forms;

namespace MyLab.MobileClient.Services
{
    public interface INavigationService
    {
        //removes most recent page from the stack
        Task<Page> RemoveViewFromStack();

        //returns to the rootpage after removing the current page from the stack
        Task BackToMainPage();

        //Navigate to particular viewmodel within our MVVM Model
        Task NavigateTo<TVM>() where TVM : BaseViewModel;
    }
}
