using System;
using System.Collections.Generic;
using MyLab.MobileClient.Services;
using MyLab.MobileClient.ViewModels;
using Xamarin.Forms;

namespace MyLab.MobileClient.Views
{
    public partial class HomeView : ContentPage
    {
        HomeViewModel _viewModel => BindingContext as HomeViewModel;

        public HomeView()
        {
            InitializeComponent();
            Title = "Files from API";
            this.BindingContext = new HomeViewModel(DependencyService.Get<INavigationService>());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel != null)
            {
                await _viewModel.Init();
            }
            
            //cView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, new Binding("."));
            //cView.BindingContext = _viewModel.MyFiles;
        }
    }
}
