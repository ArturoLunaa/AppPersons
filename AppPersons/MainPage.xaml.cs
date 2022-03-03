using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace AppPersons
{
    public partial class MainPage : ContentPage
    {
        public List<PersonModel> Persons;


        public MainPage()
        {
            InitializeComponent();
        }
        private void ButtonLoadPersons_Clicked(object sender, EventArgs e)
        {
            ButtonLoadPersons.IsEnabled = true;
            IndicatorPersons.IsRunning = false;

            Persons = new List<PersonModel>
            {
                new PersonModel
                {
                    ID = 1,
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Age = 37,
                    Phone = "234242324",
                    Picture = "https://www.realmadrid.com/img/vertical_380px/cristiano_550x650_20180917025046.jpg"
                },
                new PersonModel
                {
                    ID = 2,
                    FirstName = "Leo",
                    LastName = "Messi",
                    Age = 35,
                    Phone = "531243453",
                    Picture = "https://img.olympicchannel.com/images/image/private/t_1-1_600/f_auto/v1538355600/primary/wfrhxc0kh2vvq77sonki"
                },
                new PersonModel
                {
                    ID = 3,
                    FirstName = "Javier",
                    LastName = "Hernández",
                    Age = 33,
                    Phone = "67890478",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2dzCRKm7cm-MC-dVDax1XqqT7sDnkGDgkqqrRkZkse_KhzUQUZ3JeDdsNVDiwGGrL_jY&usqp=CAU"
                }
            };
            ListPersons.ItemsSource = Persons;

            IndicatorPersons.IsRunning = false;
            ButtonLoadPersons.IsEnabled = true;
        }
        private void ButtonNewPerson_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailView(this));
        }

        public void ListRefresh()
        {
            ListPersons.ItemsSource = null;
            ListPersons.ItemsSource = Persons;
        }

        private void ListPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonModel personSelected = e.CurrentSelection.FirstOrDefault() as PersonModel;

            if(personSelected != null)
            {
                Navigation.PushAsync(new DetailView(this, personSelected));
            }
        }
    }
}
