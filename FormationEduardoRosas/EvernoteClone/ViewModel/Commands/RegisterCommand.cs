using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            User user = parameter as User;

            if (user == null) return false;

            if (string.IsNullOrEmpty(user.Email) || 
                string.IsNullOrEmpty(user.Password) || 
                string.IsNullOrEmpty(user.ConfirmPassword) || 
                string.IsNullOrEmpty(user.Lastname) || 
                string.IsNullOrEmpty(user.Name)) return false;

            if (user.ConfirmPassword != user.Password) return false;

            return true;
        }

        public void Execute(object? parameter)
        {
            VM.Register();
        }
    }
}
