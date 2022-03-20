using EXO_02.Logic;
using EXO_02.Models;
using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_02.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEventPage : ContentPage
    {
        public AddEventPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = VenueLogic.GetVenues(position.Latitude, position.Longitude);
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            TravelEvent newEvent = new TravelEvent
            {
                Title = titleEntry.Text,
                Description = descEntry.Text,
                Date = datePicker.Date
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TravelEvent>();
                int nbRows = conn.Insert(newEvent);

                if (nbRows > 0)
                {
                    DisplayAlert("Réussi", "L'évènement a été ajouté avec succès", "Ok");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Erreur", "Un problème est survenu lors de l'ajout de l'évènement", "Ok");
                }
            }
        }
    }
}