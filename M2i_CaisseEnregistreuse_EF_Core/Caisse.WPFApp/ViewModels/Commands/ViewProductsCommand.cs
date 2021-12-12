using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caisse.WPFApp.ViewModels.Commands
{
    public class ViewProductsCommand : ICommand
    {
        private SalesViewModel _salesViewModel;

        public event EventHandler? CanExecuteChanged;

        public ViewProductsCommand(SalesViewModel vm)
        {
            _salesViewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _salesViewModel.ShowProducts();
        }
    }
}
