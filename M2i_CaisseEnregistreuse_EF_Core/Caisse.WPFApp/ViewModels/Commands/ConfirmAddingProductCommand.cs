using Caisse.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caisse.WPFApp.ViewModels.Commands
{
    public class ConfirmAddingProductCommand : ICommand
    {
        private NewProductViewModel _vm;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ConfirmAddingProductCommand(NewProductViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            Product p = parameter as Product;
            if (p != null)
            {
                if (!string.IsNullOrEmpty(p.Name) && !string.IsNullOrEmpty(p.Description) && p.Price != 0 && p.Stock != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            _vm.AddProduct();
        }
    }
}
