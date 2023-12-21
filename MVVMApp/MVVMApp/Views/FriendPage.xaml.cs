using System;
using System.Collections.Generic;
using MVVMApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendPage : ContentPage
	{	
		public FriendViewModel ViewModel { get; set; }
		public FriendPage (FriendViewModel viewModel)
		{
			InitializeComponent ();
			ViewModel = viewModel;
			this.BindingContext = ViewModel;
		}
	}
}

