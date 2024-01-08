using System;
using System.Collections.Generic;
using MVVMApp.Models;
using Xamarin.Forms;

namespace MVVMApp.Views
{	
	public partial class DBFriendPage : ContentPage
	{	
		public DBFriendPage ()
		{
			InitializeComponent ();
		}

        void Loobu_Clicked(System.Object sender, System.EventArgs e)
        {
			Navigation.PopAsync();
        }

        void Kustuta_Clicked(System.Object sender, System.EventArgs e)
        {
            Friend friend = (Friend)BindingContext;
            App.Database.DeleteItem(friend.Id);
            Navigation.PopAsync();
        }

        void Salvesta_Clicked(System.Object sender, System.EventArgs e)
        {
            Friend friend = (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
	        }
            this.Navigation.PopAsync();
        }
    }
}

