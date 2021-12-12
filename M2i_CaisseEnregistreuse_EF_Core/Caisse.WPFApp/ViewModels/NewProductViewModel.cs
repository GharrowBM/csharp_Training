using Caisse.Classes;
using Caisse.WPFApp.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse.WPFApp.ViewModels
{
    public class NewProductViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private decimal _price;
        private int _stock;
        private Product _product;

        public string Name 
        { 
            get => _name; 
            set 
            { 
                _name = value; 
                OnPropertyChanged("Name");
                Product = new Product { Name = _name, Description = _description, Price = _price, Stock = _stock }; 
            } 
        }

        public string Description 
        { 
            get => _description; 
            set 
            { 
                _description = value; 
                OnPropertyChanged("Description");
                Product = new Product { Name = _name, Description = _description, Price = _price, Stock = _stock }; 
            } 
        }
        
        public decimal Price 
        { 
            get => _price; 
            set 
            { 
                _price = value; 
                OnPropertyChanged("Price");
                Product = new Product { Name = _name, Description = _description, Price = _price, Stock = _stock }; 
            } 
        }
        
        public int Stock 
        { 
            get => _stock; 
            set 
            { 
                _stock = value; 
                OnPropertyChanged("Stock");
                Product = new Product { Name = _name, Description = _description, Price = _price, Stock = _stock }; 
            } 
        } 
        
        public Product Product { get => _product; set { _product = value; OnPropertyChanged("Product"); } }

        public ConfirmAddingProductCommand ConfirmCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public NewProductViewModel()
        {
            ConfirmCommand = new ConfirmAddingProductCommand(this);
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void AddProduct()
        {

        }
    }
}
