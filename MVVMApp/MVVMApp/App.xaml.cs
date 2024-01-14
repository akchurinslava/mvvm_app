using System;
using System.IO;
using MVVMApp.Models;
using MVVMApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp
{

    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        public static FriendRepository database;
        public const string F_DATABASE_NAME = "family.db";
        public static FamilyRepository f_database;

        public static FriendRepository Database
        { 
            get
            {
                if (database == null)
                {
                    database = new FriendRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
		        }
                return database;
	        }
	    }

        public static FamilyRepository F_database
        {
            get
	        {
                if (f_database == null)
                {
                    f_database = new FamilyRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),F_DATABASE_NAME));
                }
                return f_database;
            }
	    }

        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
            //MainPage = new NavigationPage(new FriendsListPage());
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

