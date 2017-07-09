using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ISuitePro.ERP.Digital.CxUI.ViewModels
{
    public class MenuLink
    {
        public string Title { get; set; }
        public string IconName { get; set; }
    }
    public class HomePageViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<MenuLink> _menuItems;
        private INavigationService _navigationService;

        public ObservableCollection<MenuLink> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public DelegateCommand HomeCommand { get; set; }

        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get
            {
                if (_goToDetailPage == null)
                {
                    _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
                    {
                        NavigationParameters param = new NavigationParameters();
                        param.Add("show", selected.Item);
                        await _navigationService.NavigateAsync("DetailsPage", param);
                    });
                }

                return _goToDetailPage;
            }
        }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            HomeCommand = new DelegateCommand(Home);
        }

        private void Home()
        {
            //TODO: call service

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (MenuItems == null || MenuItems.Count == 0)
             {
                //var result = _apiService.GetMainMenu();
                var menu = new List<MenuLink>();
                menu.Add(new MenuLink { Title = "Apprisal Year" });
                menu.Add(new MenuLink { Title = "Employee Level" });
                menu.Add(new MenuLink { Title = "Leave Type" });
                menu.Add(new MenuLink { Title = "Claim Types" });
                menu.Add(new MenuLink { Title = "Salary Component" });
                menu.Add(new MenuLink { Title = "Off-Day" });
                MenuItems = new ObservableCollection<MenuLink>(menu);
            }
        }
    }
}
