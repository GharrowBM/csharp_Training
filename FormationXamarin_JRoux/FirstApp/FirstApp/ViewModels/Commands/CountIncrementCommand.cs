using System;
using System.Windows.Input;

namespace FirstApp.ViewModels.Commands
{
    public class CountIncrementCommand : ICommand
    {
        private CountViewModel _vm;

        public CountIncrementCommand(CountViewModel vm)
        {
            _vm = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.IncrementCount();
        }

        public event EventHandler CanExecuteChanged;
    }
}