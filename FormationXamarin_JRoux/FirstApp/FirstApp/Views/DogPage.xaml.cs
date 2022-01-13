using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogPage : ContentPage
    {
        public DogPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dogSVG.FadeTo(1, 2000, Easing.CubicInOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            dogSVG.FadeTo(0, 2000);
        }
    }
}