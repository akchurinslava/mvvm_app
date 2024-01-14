using System;
using System.Collections.Generic;
using System.Linq;
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

        void Entry_Completed(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry && !string.IsNullOrEmpty(entry.Text))
            {
                entry.Text = char.ToUpper(entry.Text[0]) + entry.Text.Substring(1);
            }
        }

        void Entry_Completed_1(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry)
            {
                entry.Text = ToTitleCase(entry.Text);
            }

            if (sender is Entry entry1)
            {
                entry1.Text = char.ToUpper(entry1.Text[0]) + entry1.Text.Substring(1);

                Friend friend = (Friend)BindingContext;

                FormattedString formattedString = new FormattedString();

                formattedString.Spans.Add(new Span { Text = $" Friend: {entry1.Text}", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                formattedString.Spans.Add(new Span { Text = " 🤝", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) });

                friend.Name = formattedString.ToString();
            }
        }
        private string ToTitleCase(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }

            return string.Join(' '.ToString(), words);
        }

        void Entry_Completed_2(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry)
            {
                string formattedNumber = FormatPhoneNumber(e.ToString());
                entry.Text = formattedNumber + entry.Text;
            }
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

            if (!digitsOnly.StartsWith("+372"))
            {
                digitsOnly = "+372 " + digitsOnly;
            }

            return digitsOnly;
        }
    }
}

