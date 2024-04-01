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

namespace NTO_2024WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpacesPage());
        }

        private void EducationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnterPage());
        }

        private void CultureBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CulturePage());
        }
    }
}
