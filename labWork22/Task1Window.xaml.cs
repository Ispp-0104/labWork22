using labWork22_WPF_.Data;
using labWork22_WPF_.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace labWork22
{
    /// <summary>
    /// Логика взаимодействия для Task1Window.xaml
    /// </summary>
    public partial class Task1Window : Window
    {
        public Task1Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using var context = new Ispp0104Context();
            gameDataGrid.ItemsSource = context.Lw22Games.ToList();
            logoComboBox.ItemsSource = GetLogos();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new Ispp0104Context();
                var game = gameDataGrid.SelectedItem as Lw22Game;
                if (game == null)
                {
                    MessageBox.Show("Продукт не выбран!");
                    return;
                }
                game.LogoFile = logoComboBox.SelectedItem.ToString();
                context.Update(game);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Название логотипа добалвено!");
        }
        private static List<BitmapImage> GetLogos()
        {
            var info = new DirectoryInfo(@"C:\Temp\ispp01\mdk1101\labWork22\labWork22\games\logos\").EnumerateFiles();
            List<BitmapImage> images = new();
            foreach (var item in info)
            {
                images.Add(new BitmapImage(new Uri(@$"{item.Name}", UriKind.Relative)));
            }
            return images;
        }
    }
}
