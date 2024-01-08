using System;
using System.Collections.Generic;
using System.Linq;
using MVVMApp.Models;
using Xamarin.Forms;

namespace MVVMApp.Views
{	
	public partial class DBFamilyPage : ContentPage
	{	
		public DBFamilyPage ()
		{
			InitializeComponent ();
		}

        void Loobu_Clicked(System.Object sender, System.EventArgs e)
        {
			Navigation.PopAsync();
        }

        void Kustuta_Clicked(System.Object sender, System.EventArgs e)
        {
            Family family = (Family)BindingContext;
            App.F_database.DeleteItem(family.Id);
            Navigation.PopAsync();
        }

        void Salvesta_Clicked(System.Object sender, System.EventArgs e)
        {
            Family family = (Family)BindingContext;
            if (!String.IsNullOrEmpty(family.Name))
            {
                App.F_database.SaveItem(family);

            }
            this.Navigation.PopAsync();
        }

        void Entry_Completed(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry)
            {
                entry.Text = ToTitleCase(entry.Text);
            }

            if (sender is Entry entry1)
            {
                entry1.Text = char.ToUpper(entry1.Text[0]) + entry1.Text.Substring(1);

                Family family = (Family)BindingContext;

                FormattedString formattedString = new FormattedString();

                formattedString.Spans.Add(new Span { Text = $" Family: {entry1.Text}", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
                formattedString.Spans.Add(new Span { Text = " 👨‍👩‍👦‍👦", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) });

                family.Name = formattedString.ToString();
            }
        }

        void Entry_Completed_1(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry)
            {
                string formattedNumber = FormatPhoneNumber(e.ToString());
                entry.Text = formattedNumber + entry.Text;
            }
        }

        void Entry_Completed_2(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry && !string.IsNullOrEmpty(entry.Text))
            {
                entry.Text = char.ToUpper(entry.Text[0]) + entry.Text.Substring(1);
            }
        }

        void Entry_Completed_3(System.Object sender, System.EventArgs e)
        {
            if (sender is Entry entry && !string.IsNullOrEmpty(entry.Text))
            {
                entry.Text = char.ToUpper(entry.Text[0]) + entry.Text.Substring(1);
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

