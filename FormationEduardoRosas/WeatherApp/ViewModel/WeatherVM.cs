using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        private CurrentConditions currentConditions;
        private City selectedCity;

        public ObservableCollection<City> Cities { get; set; }
        public SearchCommand SearchCommand { get; set; }

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
                GetCurrentConditions();
            }
        }


        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? CanExecuteChanged;
        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);

            Cities = new ObservableCollection<City>();

        }

        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);

        }
    }
}
