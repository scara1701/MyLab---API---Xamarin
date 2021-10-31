using System;
using MyLab.MobileClient.Services;
using MyLab.MobileClient.ViewModels;
using MyLab.MobileClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLab.MobileClient
{
    public partial class App : Application
    {
        public static NavigationService NavService { get; set; }
        public App()
        {
            InitializeComponent();
            NavService = DependencyService.Get<INavigationService>() as NavigationService;
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            MainPage = new MainPage();
            NavService.XFNavigation = MainPage.Navigation;
            //register viewmodels on navigationstack
            NavService.RegisterViewMapping(typeof(HomeViewModel), typeof(HomeView));
            MainPage = new NavigationPage(new HomeView());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
