using Newtonsoft.Json;
using PizzaApp.Models;
using PizzaApp.ViewModels.Commands;
using PizzaApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace PizzaApp.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private List<Pizza> pizzas;
        private Pizza selectedPizza;
        private MainView view;
        private bool pizzaListVisibility;
        private bool loadingVisibility;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
            set
            {
                this.pizzas = value;
                OnPropertyChanged("Pizzas");
            }
        }

        public Pizza SelectedPizza
        {
            get => selectedPizza;
            set
            {
                selectedPizza = value;
                OnPropertyChanged("SelectedPizza");
            }
        }

        public bool PizzaListVisibility 
        { 
            get => pizzaListVisibility;
            set 
            { 
                pizzaListVisibility = value;
                OnPropertyChanged("PizzaListVisibility");
            }
        }
        public bool LoadingVisibility
        {
            get => loadingVisibility;
            set
            {
                loadingVisibility = value;
                OnPropertyChanged("LoadingVisibility");
            }
        }

        public RefreshPizzaListCommand RefreshPizzaListCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public MainVM(MainView view)
        {
            this.view = view;

            RefreshPizzaListCommand = new RefreshPizzaListCommand(this);

            /* Pour récupérer le fichier dans les dossier de la solution
            string fileLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Datas/Pizza.json");


            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainVM)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("PizzaApp.Datas.Pizza.json");
            string json = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                json = reader.ReadToEnd();
                Pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            */

            RefreshPizzasFromDrive();
            
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async void RefreshPizzasFromDrive()
        {

            string fileDLLink = "https://drive.google.com/uc?export=download&id=1l2ugFT_A7MibHYStErhm_A0x7KR9DoNQ";
            string json = String.Empty;

            using (var WebClient = new WebClient())
            {
                try
                {
                    WebClient.DownloadStringCompleted += (s, e) =>
                    {
                        json = e.Result;

                        Pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);

                        LoadingVisibility = false;
                    };
                    
                    WebClient.DownloadStringAsync(new Uri(fileDLLink));
                }
                catch (Exception ex)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        view.DisplayAlert("Erreur", "Une erreur réseau s'est produite: " + ex.Message, "OK");
                    });

                    return;
                }
            }

            
        }
    }
}
