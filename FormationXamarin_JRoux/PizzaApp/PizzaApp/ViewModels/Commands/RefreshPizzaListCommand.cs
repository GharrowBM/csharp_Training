using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PizzaApp.ViewModels.Commands
{
    public class RefreshPizzaListCommand : ICommand
    {
        private MainVM mainVM;

        public event EventHandler CanExecuteChanged;

        public RefreshPizzaListCommand(MainVM mainVM)
        {
            this.mainVM = mainVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainVM.RefreshPizzasFromDrive();
        }
    }
}
