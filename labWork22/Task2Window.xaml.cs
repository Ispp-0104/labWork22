using labWork22.Data;
using Microsoft.Data.SqlClient;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Net.Mime.MediaTypeNames.Image;

namespace labWork22
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2Window : Window
    {
        public Task2Window()
        {
            InitializeComponent();
            using var context = new Ispp0104Context();
            listGame.ItemsSource = context.Lw22Games.ToList().Select(x => x.Name);
            listLogo.ItemsSource = GetLogos($"C:\\Users\\0109\\Source\\Repos\\labWork22\\labWork22\\games\\logos");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var objectOperation = new PhotosLoadDb(listGame.SelectedItem.ToString(), listLogo.SelectedItem.ToString());
            MessageBox.Show(objectOperation.stateOperation ? "Операция успешна!" : "Операция провалена!");
            LogoGame.Source = new BitmapImage(new Uri(objectOperation.image));
        }
    }
}
