using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EvernoteClone.ViewModel
{
    public  class LoginVM : INotifyPropertyChanged
    {
        private User user;
        private string _email;
        private string _name;
        private string _lastname;
        private string _password;
        private string _confirmPassword;
        private bool isShowingRegister = false;
        private Visibility loginVisibility;

        private Visibility registerVisibility;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public string Email
        {
            get { return _email; }
            set 
            {
                _email = value;
                User = new User()
                {
                    Email = _email,
                    Lastname = _lastname,
                    Name = _name,
                    Password = _password,
                    ConfirmPassword = _confirmPassword,
                };
                OnPropertyChanged("Email");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                User = new User()
                {
                    Email = _email,
                    Lastname = _lastname,
                    Name = _name,
                    Password = _password,
                    ConfirmPassword = _confirmPassword,
                };
                OnPropertyChanged("Name");
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                User = new User()
                {
                    Email = _email,
                    Lastname = _lastname,
                    Name = _name,
                    Password = _password,
                    ConfirmPassword = _confirmPassword,
                };
                OnPropertyChanged("Lastname");
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                User = new User()
                {
                    Email = _email,
                    Lastname = _lastname,
                    Name = _name,
                    Password = _password,
                    ConfirmPassword = _confirmPassword,
                };
                OnPropertyChanged("Password");
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                User = new User()
                {
                    Email = _email,
                    Lastname = _lastname,
                    Name = _name,
                    Password = _password,
                    ConfirmPassword = _confirmPassword,
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public Visibility RegisterVisibility
        {
            get { return registerVisibility; }
            set 
            { 
                registerVisibility = value;
                OnPropertyChanged("RegisterVisibility");
            }
        }

        public Visibility LoginVisibility
        {
            get { return loginVisibility; }
            set 
            { 
                loginVisibility = value;
                OnPropertyChanged("LoginVisibility");
            }
        }
        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public ShowRegisterCommand ShowRegisterCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler Authenticated;

        public LoginVM()
        {
            LoginVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;

            User = new User();

            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            ShowRegisterCommand = new ShowRegisterCommand(this);

        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public async void Login()
        {
            bool result = await FirebaseAuthHelper.Login(User);

            if (result)
            {
                Authenticated?.Invoke(this, new EventArgs());
            }
        }

        public async void Register()
        {
            bool result = await FirebaseAuthHelper.Register(User);

            if (result)
            {
                Authenticated?.Invoke(this, new EventArgs());
            }
        }

        public void SwitchViews()
        {
            isShowingRegister = !isShowingRegister;

            if (isShowingRegister)
            {
                RegisterVisibility = Visibility.Visible;
                LoginVisibility = Visibility.Collapsed;
            }
            else
            {
                RegisterVisibility = Visibility.Collapsed;
                LoginVisibility = Visibility.Visible;
            }
        }
    }
}
