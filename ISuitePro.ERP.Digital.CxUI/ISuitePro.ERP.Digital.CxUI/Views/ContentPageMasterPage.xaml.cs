﻿using Xamarin.Forms;
using System.Collections.Generic;
using ISuitePro.ERP.Digital.CxUI;

namespace ISuitePro.ERP.Digital.CxUI.Views
{
    public partial class ContentPageMasterPage : ContentPage
    {
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create("Items", typeof(IList<NavigationItem>), typeof(ContentPageMasterPage), null);

        public IList<NavigationItem> Items
        {
            get { return (IList<NavigationItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        Page detailPage;

        public ContentPageMasterPage()
        {
            InitializeComponent();

            Items = new List<NavigationItem>
            {
                new NavigationItem("Save", "\uE105", new Command(async () => await DisplayAlert("Save", "Fake save dialog", "OK"))),
                new NavigationItem("Delete", "\uE107", new Command(async () => await DisplayAlert("Delete", "Fake delete dialog", "OK"))),
                new NavigationItem("Set Detail to Navigation Page", "\uE16F", new Command(() =>
                {
                    detailPage = (Parent as MasterDetailPage).Detail;
                    (Parent as MasterDetailPage).Detail = new NavigationPage(new ContentPageTwo());
                })),
                new NavigationItem("Set Detail to Content Page", "\uE160", new Command(() => (Parent as MasterDetailPage).Detail = (detailPage == null) ? (Parent as MasterDetailPage).Detail : detailPage))
            };
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            (e.Item as NavigationItem).Command.Execute(null);
        }
    }
}
