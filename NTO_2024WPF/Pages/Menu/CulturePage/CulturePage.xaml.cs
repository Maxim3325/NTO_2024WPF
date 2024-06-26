﻿using System;
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
    /// Логика взаимодействия для CulturePage.xaml
    /// </summary>
    public partial class CulturePage : Page
    {
        public CulturePage()
        {
            InitializeComponent();
        }

        private void ExhibitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExhibitPage());
        }
    }
}
