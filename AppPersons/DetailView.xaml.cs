using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPersons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        MainPage MainPage;
        PersonModel Person = new PersonModel();

        public DetailView(MainPage mainPage)
        {
            InitializeComponent();

            this.MainPage = mainPage;
        }

        public DetailView(MainPage mainPage, PersonModel person)
        {
            InitializeComponent();

            this.MainPage = mainPage;

            // Cargar persona seleccionada
            this.Person.ID = person.ID;
            ImagePicture.Source = person.Picture;
            EntryPicture.Text = person.Picture;
            EntryFirstName.Text = person.FirstName;
            EntryLastName.Text = person.LastName;
            EntryAge.Text = person.Age.ToString();
            EntryPhone.Text = person.Phone;
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if (this.Person.ID > 0)
            {
                // Actualizar
                for (int index = 0; index < this.MainPage.Persons.Count; index++)
                {
                    if(this.MainPage.Persons[index].ID == this.Person.ID)
                    {
                            this.MainPage.Persons[index].Picture = EntryPicture.Text;
                            this.MainPage.Persons[index].FirstName = EntryFirstName.Text;
                            this.MainPage.Persons[index].LastName = EntryLastName.Text;
                            this.MainPage.Persons[index].Age = int.Parse(EntryAge.Text);
                            this.MainPage.Persons[index].Phone = EntryPhone.Text;
                            break;   
                    }
                }
            }
            else
            {
                // Crear
                Person.Picture = EntryPicture.Text;
                Person.FirstName = EntryFirstName.Text;
                Person.LastName = EntryLastName.Text;
                Person.Age = int.Parse(EntryAge.Text);
                Person.Phone = EntryPhone.Text;

                // Agregamos la nueva persona a nuestro listado de personas
                this.MainPage.Persons.Add(Person);
            }
            // Refrescamos nuestro collectionviwe
            this.MainPage.ListRefresh();

            //Regresamos la vista del listado
            this.Navigation.PopAsync();
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        //Funcion delete
        private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            if (this.Person.ID > 0)
            {
                //Lo mismo que en actualizar, buscamos por el ID la persona pero ahora la eliminamos con RemoveAt
                for (int index = 0; index < this.MainPage.Persons.Count; index++)
                {
                    if (this.MainPage.Persons[index].ID == this.Person.ID)
                    {
                        this.MainPage.Persons.RemoveAt(index);
                        break;
                    }
                }
            }
            else
            {
                //Crear
                Person.Picture = EntryPicture.Text;
                Person.FirstName = EntryFirstName.Text;
                Person.LastName = EntryLastName.Text;
                Person.Age = int.Parse(EntryAge.Text);
                Person.Phone = EntryPhone.Text;

                // Agregamos la nueva persona a nuestro listado de personas
                this.MainPage.Persons.Add(Person);
            }
            //Refrescamos nuestro collectionview
            this.MainPage.ListRefresh();

            //Regresamos la vista del listado
            Navigation.PopAsync();
        }
    }
}