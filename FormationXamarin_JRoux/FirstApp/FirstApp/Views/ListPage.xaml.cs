using FirstApp.Models;
using FirstApp.ViewModels;
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
    public partial class ListPage : ContentPage
    {
        public ListViewModel listViewModel { get; set; }

        public ListPage()
        {

            InitializeComponent();
            BindingContext = listViewModel = new ListViewModel(this);
        }
    }
}