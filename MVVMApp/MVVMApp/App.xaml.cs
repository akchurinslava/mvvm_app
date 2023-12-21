using System;
using MVVMApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp
{
    public partial class App : Application
    {
        public App ()
        {
            // InitializeComponent();

            MainPage = new NavigationPage(new FriendsListPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

