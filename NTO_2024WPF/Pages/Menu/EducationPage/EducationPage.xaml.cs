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
    /// Логика взаимодействия для EducationPage.xaml
    /// </summary>
    public partial class EducationPage : Page
    {
        public EducationPage()
        {
            InitializeComponent();
        }

        private void StudiosBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudiosPage());
        }

        private void TeacherBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherPage());
        }
    }
}
