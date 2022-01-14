using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NombreMagique.Models.Enums;
using NombreMagique.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NombreMagique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GameVM VM { get; set; }
        
        public GamePage(Difficulties difficulty)
        {
            InitializeComponent();

            BindingContext = VM = new GameVM(this, difficulty);
        }
    }
}