using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caisse.WPFApp.ViewModels.Commands
{
    internal class NewSaleCommand : ICommand
    {
        private SalesViewModel _vm;

        public event EventHandler? CanExecuteChanged;

        public NewSaleCommand(SalesViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.NewSale();
        }
    }
}
