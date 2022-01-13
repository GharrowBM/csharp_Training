using FirstApp.Models;
using FirstApp.ViewModels.Converters;
using FirstApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FirstApp.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        private List<Article> articles;
        private Article selectedArticle;
        private ListPage _listPage;

        public Article SelectedArticle
        {
            get { return selectedArticle; }
            set 
            { 
                selectedArticle = value; 
                OnPropertyChanged("SelectedArticle");
                if (SelectedArticle != null)
                {
                    DisplayArticleDesc(SelectedArticle);
                }
            }
        }


        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public DecimalToStringConverter DecimalToStringConverter { get; set; } = new DecimalToStringConverter();

        public event PropertyChangedEventHandler PropertyChanged;

        public ListViewModel(ListPage listpage)
        {
            _listPage = listpage;

            articles = new List<Article>()
            {
                new Article()
                {
                    Title = "Pomme",
                    Price = 1.50m,
                    Description = "Un fruit commun, parfois empoisonné..."
                },
                new Article()
                {
                    Title = "PS5",
                    Price = 499.99m,
                    Description= "Une console de jeu faite par SONY, en quantité très très limitée..."
                },
                new Article()
                {
                    Title="Sherlock Holmes: Etude en Rouge",
                    Price= 14.99m,
                    Description="Un classique de littérature rédigé par E.C.Doyle"
                }
            };
        }

        public ListViewModel()
        {
           
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void DisplayArticleDesc(Article article)
        {
            _listPage.DisplayAlert("Description", article.Description, "OK");
        }
    }
}
