
using labWork22.Data;
using labWork22.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

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
        private static List<BitmapImage> GetLogos(string path)
        {
            var info = new DirectoryInfo(@$"{path}").EnumerateFiles();
            List<BitmapImage> images = new();
            foreach (var item in info)
            {
                images.Add(new BitmapImage(new Uri(@$"{item.Name}", UriKind.Relative)));
            }
            return images;
        }

        private void GetImagePathButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logoComboBox.ItemsSource = GetLogos(pathTextBox.Text);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
