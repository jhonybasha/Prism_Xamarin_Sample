﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ISuitePro.ERP.Digital.CxUI.Views
{
    public partial class MenuPage : ContentPage
    {
        public static ObservableCollection<string> items { get; set; }

        public MenuPage()
        {
            items = new ObservableCollection<string>() { "speaker", "pen", "lamp", "monitor", "bag", "book", "cap", "tote", "floss", "phone" };
            InitializeComponent();

            var colors = new List<object>();
            for (int i = 0; i < 16; i++)
            {
                var c = 200 - 10 * i;
                colors.Add(new { Color = Color.FromRgb(c, c, c) });
            };

            listView.ItemsSource = colors;
        }

        private void Button1_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Button Clicked", "Button1", "Ok");
        }

        private void Button2_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Button Clicked", "Button2", "Ok");
        }

        private void Button3_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Button Clicked", "Button3", "Ok");
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //comment out if you want to keep selections
            ListView lst = (ListView)sender;
            lst.SelectedItem = null;
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            //put your refreshing logic here
            var itemList = items.Reverse().ToList();
            items.Clear();
            foreach (var s in itemList)
            {
                items.Add(s);
            }
            //make sure to end the refresh state
            list.IsRefreshing = false;
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            items.Remove(item.CommandParameter.ToString());
        }
    }
}
