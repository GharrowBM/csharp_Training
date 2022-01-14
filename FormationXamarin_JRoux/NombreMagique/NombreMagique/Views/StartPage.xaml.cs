using NombreMagique.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NombreMagique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartVM VM { get; set; }

        public StartPage()
        {
            InitializeComponent();

            BindingContext = VM = new StartVM(this);
        }
    }
}