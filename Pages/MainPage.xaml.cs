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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public UsersService service { get; set; } = new();
        public User selected { get; set; }

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (selected == null) return;
            NavigationService.Navigate(new UserFormPage(selected));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (selected == null) return;
            service.Remove(selected);
        }
    }
}
