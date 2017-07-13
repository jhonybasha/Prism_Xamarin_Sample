using System;
using Xamarin.Forms;
using ISuitePro.ERP.Digital.CxUI;

namespace ISuitePro.ERP.Digital.CxUI.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            //await DisplayAlert(WindowsPlatformSpecificsHelpers.Title, WindowsPlatformSpecificsHelpers.Message, WindowsPlatformSpecificsHelpers.Dismiss);
            await DisplayAlert("Alert", "Toolbar item clicked", "Ok");
        }
    }
}