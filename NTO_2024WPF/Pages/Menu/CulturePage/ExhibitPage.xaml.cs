using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NTO_2024WPF.data;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ExhibitPage.xaml
    /// </summary>
    public partial class ExhibitPage : Page
    {
        private string file_name;

        public ExhibitPage()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            Db.Exhibits.Load();
            Db.Studios.Load();
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
                                Db.Studios.Load();
                                var created_Exhibit = new Exhibit();

                                created_Exhibit.Name = row[0].ToString();
                                var searched_Studio = Db.Studios.FirstOrDefault(el => el.Name == row[1].ToString());

                                if (searched_Studio != null)
                                {
                                    created_Exhibit.Studios = searched_Studio;
                                }
                                else
                                {
                                    created_Exhibit.Studios = new Studio();
                                    created_Exhibit.Studios.Name = row[0].ToString();
                                    created_Exhibit.Studios.Deskription = row[1].ToString();
                                    
                                }

                                if (Db.Exhibits.FirstOrDefault(el => el.Name == created_Exhibit.Name && el.Studios == created_Exhibit.Studios) != null)
                                {
                                    continue;
                                }
                                else
                                {
                                    Db.Exhibits.Add(created_Exhibit);
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
                            MessageBox.Show("Таблица не подходит по формату");
                        }
                   
                    }
                }
            }
            Db.Studios.Load();
            Db.Exhibits.Load();
            ExhibitDG.ItemsSource = Db.Exhibits.ToList();
        }
    }
}
