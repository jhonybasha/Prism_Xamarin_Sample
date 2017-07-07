using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ISuitePro.ERP.Digital.CxUI.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public LoginPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        private INavigationService _navigationService;

        public DelegateCommand NavigateToSpeakPageCommand { get; private set; }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToSpeakPageCommand = new DelegateCommand(NavigateToSpeakPage);
        }

        private void NavigateToSpeakPage()
        {
            _navigationService.NavigateAsync("SpeakPage");
        }
    }
}
