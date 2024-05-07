using System.Linq;
using System.Windows;
using System.Windows.Input;
using web_marketplase_TRiZBD.Models;  // Убедитесь, что пространство имен моделей правильное
using web_marketplase_TRiZBD.Views;

namespace web_marketplase_TRiZBD.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private bool _isLoginAttemptFailed;
        private Window LoginView;

        public LoginViewModel(Window LoginView)
        {
            this.LoginView = LoginView;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

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
            using (var context = new MarketplaceContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (user != null)
                {
                    MessageBox.Show("Login successful!");
                    IsLoginAttemptFailed = false;
                    // Здесь код для перехода на страницу товаров
                    OpenProductsView();
                }
                else
                {
                    MessageBox.Show("Login failed. Check your username and password.");
                    IsLoginAttemptFailed = true;
                    Password = ""; // Сброс пароля после неудачной попытки
                }
            }
        }

        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void OpenProductsView()
        {
            var productsView = new ProductsView();
            productsView.Show();
            this.LoginView.Close(); // Закрыть окно логина
        }

    }
}
