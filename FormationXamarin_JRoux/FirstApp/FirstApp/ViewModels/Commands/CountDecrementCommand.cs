using System;
using System.Windows.Input;

namespace FirstApp.ViewModels.Commands
{
    public class CountDecrementCommand : ICommand
    {
        private CountViewModel _vm;

        public CountDecrementCommand(CountViewModel vm)
        {
            _vm = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.DecrementCount();
        }

        public event EventHandler CanExecuteChanged;
    }
}