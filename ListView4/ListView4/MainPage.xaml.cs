using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using ListView4.Models;
using System.Collections.ObjectModel;

//
// Project adds "Context Actions" (Call & Delete) to ListView3
// Also, adds pull screen down to refresh ListView
//

namespace ListView4
{
    public partial class MainPage : ContentPage
    {
        // notifies subscribers of add/remove/... events
        // Xamarin ListView class is able to work with ObservableCollection
        // ListView is notified of add/remove event and refreshes itself
        private ObservableCollection<Contact> _contacts;

        public MainPage()
        {
            InitializeComponent();

            // ItemsSource type is IEnumerable which only iterates thru a collection:
            // it doesn't have methods to add/remove an object from a collection
            //myListView.ItemsSource = new List<Contact>
            _contacts = new ObservableCollection<Contact>
            {
                new Contact {Name="Jaime", ImageUrl= "https://placeimg.com/100/100/tech/any", Status="sure!"},
                new Contact {Name="Steph", ImageUrl= "https://placeimg.com/100/100/people/2", Status="not sure..."},
                new Contact {Name="Sophie", ImageUrl= "https://placeimg.com/100/100/people/3", Status="so happy"},
                //new Contact {Name="Denise", ImageUrl= "https://placeimg.com/100/100/people/4", Status="resentful"},
                //new Contact {Name="Caroline", ImageUrl= "https://placeimg.com/100/100/people/5", Status="am i alive?"}
            };

            myListView.ItemsSource = _contacts;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "Ok");

            //throw new NotImplementedException();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            _contacts.Remove(contact);

            //throw new NotImplementedException();
        }


        // 2 methods below are for Refreshing the ListView when pulling screen down from the top
        private void myListView_Refreshing(object sender, EventArgs e)
        {
            myListView.ItemsSource = GetContacts();
            myListView.EndRefresh();  // to remove Activity Indicator

        }

        ObservableCollection<Contact> GetContacts()
        {
            _contacts = new ObservableCollection<Contact> { 
                new Contact {Name="Jaime", ImageUrl= "https://placeimg.com/100/100/tech/any", Status="sure!"},
                new Contact {Name="Steph", ImageUrl= "https://placeimg.com/100/100/people/2", Status="not sure..."},
                new Contact {Name="Sophie", ImageUrl= "https://placeimg.com/100/100/people/3", Status="so happy"},
                new Contact {Name="Denise", ImageUrl= "https://placeimg.com/100/100/people/4", Status="resentful"},
                new Contact {Name="Caroline", ImageUrl= "https://placeimg.com/100/100/people/5", Status="am i alive?"}
             };

            return _contacts;
        }
    }
}
