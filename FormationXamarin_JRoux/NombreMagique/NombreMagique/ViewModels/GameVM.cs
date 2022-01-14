using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NombreMagique.Annotations;
using NombreMagique.Models.Enums;
using NombreMagique.ViewModels.Commands;
using NombreMagique.Views;

namespace NombreMagique.ViewModels
{
    public class GameVM : INotifyPropertyChanged
    {
        private int _nbrGuess;
        private int _mysteryNumber;
        private GamePage _page;
        private int _nbrOfAttempts;
        private bool isWon;
        private int minValue;
        private int maxValue;

        public int NbrGuess
        {
            get => _nbrGuess;
            set
            {
                _nbrGuess = value;
                OnPropertyChanged("NbrGuess");
            }
        }

        public int NbrOfAttempts
        {
            get => _nbrOfAttempts;
            set
            {
                _nbrOfAttempts = value;
                OnPropertyChanged("NbrOfAttempts");
            }
        }

        public int MysteryNumber
        {
            get => _mysteryNumber;
            set
            {
                _mysteryNumber = value;
                OnPropertyChanged("MysteryNumber");
            }
        }

        public bool IsWon
        {
            get => isWon;
            set
            {
                isWon = value;
                OnPropertyChanged("IsWon");
            }
        }

        public int MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                OnPropertyChanged("MinValue");
            }
        }

        public int MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                OnPropertyChanged("MaxValue");
            }
        }

        public string WelcomeMessage { get; set; }

        public TestNumberCommand TestNumberCommand { get; set; }
        public TryAgainCommand TryAgainCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public GameVM(GamePage page, Difficulties difficulty)
        {
            _page = page;

            switch(difficulty)
            {
                case Difficulties.Easy:
                    MinValue = 0;
                    MaxValue = 10;
                    break;
                case Difficulties.Medium:
                    MinValue = 0;
                    MaxValue = 100;
                    break;
                case Difficulties.Hard:
                    MinValue = 0;
                    MaxValue = 1000;
                    break;
                case Difficulties.Nightmare:
                    MinValue = -666;
                    MaxValue = 666;
                    break;
                default:
                    break;
            }

            MysteryNumber = new Random().Next(MinValue, MaxValue+1);
            WelcomeMessage = $"Guess a number between {MinValue} and {MaxValue}";

            TestNumberCommand = new TestNumberCommand(this);
            TryAgainCommand = new TryAgainCommand(this);
        }

        public GameVM()
        {

        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TestMysteryNumber()
        {
            NbrOfAttempts++;

            if (NbrGuess == MysteryNumber)
            {
                _page.DisplayAlert("Congratulations", $"You've won with only {NbrOfAttempts} tries!", "OK");
                isWon = true;
            }
            else if (MysteryNumber > NbrGuess)
            {
                _page.DisplayAlert("Too low", $"The mystery number is greater than {NbrGuess}", "Try Again");
            }
            else if (_mysteryNumber < NbrGuess)
            {
                _page.DisplayAlert("Too high", $"The mystery number is lower than {NbrGuess}", "Try Again");
            }

            NbrGuess = 0;
        }

        public void GenerateNewNumber()
        {
            isWon = false;
            MysteryNumber = new Random().Next(MinValue, MaxValue+1);
            NbrOfAttempts = 0;
        }
    }
}