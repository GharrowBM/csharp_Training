using Caisse.WPFApp.ViewModels.Commands;
using Caisse.WPFApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse.WPFApp.ViewModels
{
    public class SalesViewModel
    {

        public NewSaleCommand NewSaleCommand { get; set; }
        public ViewProductsCommand ViewProductsCommand { get; set; }

        public SalesViewModel()
        {
            NewSaleCommand = new NewSaleCommand(this);
            ViewProductsCommand = new ViewProductsCommand(this);
        }

        public void ShowProducts()
        {
            ProductsView view = new ProductsView();
            view.ShowDialog();
        }

        public void NewSale()
        {
            NewSaleView view = new NewSaleView();
            view.ShowDialog();
        }
    }
}
