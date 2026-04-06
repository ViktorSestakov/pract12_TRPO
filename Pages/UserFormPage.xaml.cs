using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pract12_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        private UsersService _service = new();
        private bool isEdit = false;
        private User _user;

        public UserFormPage(User user = null)
        {
            InitializeComponent();

            if (user != null)
            {
                _user = user;
                isEdit = true;
            }
            else
            {
                _user = new User();
            }

            DataContext = _user;
        }

        private bool IsValid()
        {
            if (!string.IsNullOrEmpty(_user[nameof(_user.Login)]))
                return false;

            if (!string.IsNullOrEmpty(_user[nameof(_user.Email)]))
                return false;

            if (!string.IsNullOrEmpty(_user[nameof(_user.Password)]))
                return false;

            if (!string.IsNullOrEmpty(_user[nameof(_user.CreatedAt)]))
                return false;

            return true;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (!IsValid())
            {
                MessageBox.Show("Исправьте ошибки перед сохранением");
                return;
            }

            try
            {
                if (isEdit)
                    _service.Commit();
                else
                    _service.Add(_user);

                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
