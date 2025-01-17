﻿using NombreMagique.Models.Enums;
using NombreMagique.ViewModels.Commands;
using NombreMagique.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NombreMagique.ViewModels
{
    public class StartVM : INotifyPropertyChanged
    {
        private Difficulties difficulty;
        private StartPage page;

        public Difficulties Difficulty
        {
            get => difficulty;

            set 
            { 
                difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

        public List<Difficulties> DifficultiesList { get; } = Enum.GetValues(typeof(Difficulties)).Cast<Difficulties>().ToList();
        public StartNewGameCommand StartNewGameCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public StartVM(StartPage page)
        {
            this.page = page;

            StartNewGameCommand = new StartNewGameCommand(this);
        }

        public StartVM()
        {

        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void StartNewGame()
        {
            page.Navigation.PushAsync(new GamePage(Difficulty));
        }
    }
}
