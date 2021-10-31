﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MyLab.MobileClient.Services;
using MyLab.MobileClient.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(NavigationService))]
namespace MyLab.MobileClient.Services
{
    public class NavigationService : INavigationService
    {
        public INavigation XFNavigation { get; set; }
        readonly IDictionary<Type, Type> _viewMapping = new Dictionary<Type, Type>();

        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _viewMapping.Add(viewModel, view);
        }

        public Task BackToMainPage()
        {
            return XFNavigation.PopToRootAsync(true);
        }

        public async Task NavigateTo<TVM>() where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));
            if (XFNavigation.NavigationStack.Last().BindingContext is BaseViewModel)
            {
                await ((BaseViewModel)(XFNavigation.NavigationStack.Last().BindingContext)).Init();
            }
        }

        //Navigate to specific viewmodel within dictionary
        public async Task NavigateToView(Type viewModelType)
        {
            Type viewType;
            if (!_viewMapping.TryGetValue(viewModelType, out viewType))
            {
                throw new ArgumentException("No view found in View Mapping for" + viewModelType.FullName + ".");
            }

            var constructor = viewType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(dc => !dc.GetParameters().Any());

            var view = constructor.Invoke(null) as Page;
            await XFNavigation.PushAsync(view, true);
        }

        public Task<Page> RemoveViewFromStack()
        {
            return XFNavigation.PopAsync();
        }
    }
}
