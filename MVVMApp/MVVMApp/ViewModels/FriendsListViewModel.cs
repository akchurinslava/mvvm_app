using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MVVMApp.Models;
using MVVMApp.Views;
using Xamarin.Forms;


namespace MVVMApp.ViewModels
{
    public class FriendsListViewModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<FriendViewModel> Friends { get; set; }
		public ICommand CreateFriendCommand { get; set; }
		public ICommand DeleteFriendCommand { get; set; }
		public ICommand SaveFriendCommand { get; set; }
		public ICommand BackCommand { get; set; }
		FriendViewModel selectedFriend;
		public INavigation navigation { get; set; }

		public FriendsListViewModel()
		{
			Friends = new ObservableCollection<FriendViewModel>();
			CreateFriendCommand = new Command(CreateFriend);
			DeleteFriendCommand = new Command(DeleteFriend);
			SaveFriendCommand = new Command(SaveFriend);
			BackCommand = new Command(Back);

		}
		public FriendViewModel SelectedFriend
		{ 
			get { return selectedFriend; }
			set
			{
				if(selectedFriend != value)
				{
					FriendViewModel tempFriend = value;
					selectedFriend = null;
					OnPropertyChanged("SelectFriend");
					navigation.PushAsync(new FriendPage(tempFriend));
				}
			}
		}

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(v)); }
            }
        }

        private void SaveFriend(object friendobject)
        {
			FriendViewModel friend = (FriendViewModel) friendobject;
			if (friend!=null && friend.IsValid && !Friends.Contains(friend))
			{
				Friends.Add(friend);
			}

			Back();
        }

        public void Back()
		{
			navigation.PopAsync();
		}
		

		private void DeleteFriend(object friendobject)
		{
			FriendViewModel friend = (FriendViewModel)friendobject;
			if (friend != null)
			{
				Friends.Remove(friend);
				
				
				
			}

		}



        private void CreateFriend(object obj)
        {
			navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel=this}));
        }
    }
}

