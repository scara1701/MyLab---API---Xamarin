using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyLab.CoreDTO.Models;
using MyLab.MobileClient.Services;

namespace MyLab.MobileClient.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private List<MyFile> myFiles;
        public List<MyFile> MyFiles {
            get { return myFiles; }
            set
            {
                myFiles = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(INavigationService navService) : base(navService)
        {
        }

        public async override Task Init()
        {
            //await Task.Factory.StartNew(() => { GetFiles(); });
            //await Task.Run(()=>GetFiles());
            RestService restService = new RestService();
            MyFiles = await restService.GetFilesListAsync();
        }
    }
}
