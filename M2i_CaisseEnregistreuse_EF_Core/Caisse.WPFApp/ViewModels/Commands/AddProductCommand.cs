using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caisse.WPFApp.ViewModels.Commands
{
    internal class AddProductCommand : ICommand
    {
        private ProductsViewModel _vm;

        public event EventHandler? CanExecuteChanged;

        public AddProductCommand(ProductsViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.AddProduct();
        }
    }
}
