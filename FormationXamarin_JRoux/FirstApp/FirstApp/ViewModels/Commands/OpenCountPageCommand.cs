using System;
using System.Windows.Input;

namespace FirstApp.ViewModels.Commands
{   
    public class OpenCountPageCommand : ICommand
    {
        private MenuViewModel _vm;

        public OpenCountPageCommand(MenuViewModel vm)
        {
            _vm = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.OpenCountPage();
        }

        public event EventHandler CanExecuteChanged;
    }
}