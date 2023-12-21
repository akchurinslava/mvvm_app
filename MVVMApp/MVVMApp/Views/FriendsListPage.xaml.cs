using System;
using System.Collections.Generic;
using MVVMApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendsListPage : ContentPage
	{	
		public FriendsListPage ()
		{
			InitializeComponent ();
			BindingContext = new FriendsListViewModel() { navigation = this.Navigation };
		}
	}
}

