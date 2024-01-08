using System;
using System.Collections.Generic;
using MVVMApp.Models;
using Xamarin.Forms;

namespace MVVMApp.Views
{	
	public partial class DBListPage : ContentPage
	{
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            friendsList2.ItemsSource = App.F_database.GetItems();
            base.OnAppearing();
        }

        private async void friendsList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Friend selectedfriend = (Friend)e.SelectedItem;
            DBFriendPage friendPage = new DBFriendPage();
            friendPage.BindingContext = selectedfriend;
            await Navigation.PushAsync(friendPage);
        }

        private async void Lisa_Clicked(System.Object sender, System.EventArgs e)
        {
            Friend friend = new Friend();
            DBFriendPage friendPage = new DBFriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void Lisa_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Family family = new Family();
            DBFamilyPage familyPage = new DBFamilyPage();
            familyPage.BindingContext = family;
            await Navigation.PushAsync(familyPage);
        }

        private async void friendsList2_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Family selectedfamily = (Family)e.SelectedItem;
            DBFamilyPage familyPage = new DBFamilyPage();
            familyPage.BindingContext = selectedfamily;
            await Navigation.PushAsync(familyPage);
        }
    }
}

