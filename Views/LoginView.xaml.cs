using System.Windows;
using web_marketplase_TRiZBD.ViewModels;


namespace web_marketplase_TRiZBD.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            DataContext = new LoginViewModel(this);
        }
    }
}
