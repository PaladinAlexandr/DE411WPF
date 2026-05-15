using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
                InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            var DB = new YaChepContext();
            var result = DB.Users.Include(x=>x.RoleNavigation).Where(x => x.Login == LoginUserTextBox.Text &&
            x.Password == PasswordUserBox.Password).FirstOrDefault();
            if (result != null)
            {
                UserSingleton.GetUser = result;
                new ListProductWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            new ListProductWindow().Show();
            Close();
        }
    }
}