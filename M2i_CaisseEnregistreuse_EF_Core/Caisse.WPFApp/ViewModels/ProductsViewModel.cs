using Caisse.WPFApp.ViewModels.Commands;
using Caisse.WPFApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse.WPFApp.ViewModels
{
    internal class ProductsViewModel
    {

        public AddProductCommand AddProductCommand { get; set; }

        public ProductsViewModel()
        {
            AddProductCommand = new AddProductCommand(this);
        }

        public void AddProduct()
        {
            NewProductView view = new NewProductView();
            view.ShowDialog();
        }
    }
}
