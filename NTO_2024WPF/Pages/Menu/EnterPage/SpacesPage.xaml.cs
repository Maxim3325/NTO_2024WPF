using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NTO_2024WPF.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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
using static NTO_2024WPF.Classes.Helper;

namespace NTO_2024WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpacesPage.xaml
    /// </summary>
    public partial class SpacesPage : Page
    {
        private string file_name;

        public SpacesPage()
        {
            InitializeComponent();
            LoadData();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Dio = new OpenFileDialog();
            Dio.Filter = "*.xls|*.xls";
            Dio.Multiselect = false;
            int count_first = 0;
            if (Dio.ShowDialog() == true)
            {
                file_name = Dio.FileName;
            }

            using (var item = File.Open(file_name, FileMode.Open))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(item))
                {
                    var result = reader.AsDataSet();

                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        try
                        {
                            if (count_first != 0)
                            {
                                Db.Spaces.Load();
                                var created_Spaces = new Space();

                                created_Spaces.Name = row[0].ToString();
                                created_Spaces.Deskription = row[2].ToString();
                                created_Spaces.Сapacity = int.Parse(row[1].ToString());
                                 
                                if (Db.Spaces.FirstOrDefault(el => el.Name == created_Spaces.Name && el.Deskription == created_Spaces.Deskription) != null)
                                {
                                    continue;
                                }
                                else
                                {
                                    Db.Spaces.Add(created_Spaces);
                                    Db.SaveChanges();
                                }
                                LoadData();
                            }
                            else
                            {
                                count_first++;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Таблица не подходит по формату", "Ошибка", MessageBoxButton.OK);
                            break;
                        }

                    }
                }
            }
            Db.Spaces.Load();
            SpaceDG.ItemsSource = Db.Spaces.ToList();
        }

        private void LoadData()
        {
            Db.Spaces.Load();
        }
    }
}
