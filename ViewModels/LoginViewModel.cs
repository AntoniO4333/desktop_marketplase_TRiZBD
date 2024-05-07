using System;
using System.Windows;
using System.Windows.Input;  // Для ICommand

namespace web_marketplase_TRiZBD.ViewModels
{ 
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private bool _isLoginAttemptFailed;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsLoginAttemptFailed
        {
            get => _isLoginAttemptFailed;
            set => SetProperty(ref _isLoginAttemptFailed, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private void ExecuteLogin(object parameter)
        {
            // Здесь должна быть ваша логика проверки данных пользователя.
            // Для примера предположим, что данные проверяются через сервис:
            if (Username == "admin" && Password == "password123")  // Пример проверки
            {
                MessageBox.Show("Login successful!");
                IsLoginAttemptFailed = false;
                // Можете добавить перенаправление на другой ViewModel или View здесь
            }
            else
            {
                MessageBox.Show("Login failed. Check your username and password.");
                IsLoginAttemptFailed = true;
                Password = ""; // Сброс пароля после неудачной попытки
            }
        }

        private bool CanExecuteLogin(object parameter)
        {
            // Возможность выполнения команды входа
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}