using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FirstApp.ViewModels.Commands
{
    public class OpenTabsPageCommand : ICommand
    {
        private MenuViewModel _menuViewModel;

        public event EventHandler CanExecuteChanged;

        public OpenTabsPageCommand(MenuViewModel menuViewModel)
        {
            _menuViewModel = menuViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _menuViewModel.OpenTabsPage();
        }
    }
}
