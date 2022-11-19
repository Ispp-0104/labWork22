using labWork22.Data;
using labWork22.Models;
using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;

namespace labWork22
{
    /// <summary>
    /// Логика взаимодействия для Task1Window.xaml
    /// </summary>
    public partial class Task1Window : Window
    {
        private FileInfo _fileData;
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
            File.Copy(_fileData.FullName, @$"C:\Temp\ispp01\mdk1101\labWork22\labWork22\bin\Debug\net6.0-windows\Logos\{_fileData.Name}");
            using var context = new Ispp0104Context();
            var game = gameDataGrid.SelectedItem as Lw22Game;
            if (game == null)
            {
                MessageBox.Show("Игра не выбрана!");
                return;
            }
            game.LogoFile = _fileData.Name;
            context.Update(game);
            context.SaveChanges();
            MessageBox.Show("Успешно сохранено!");
        }

        private void CheckAndSaveButton_Click(object sender, RoutedEventArgs e)
        {
            GetFileData();
            currentImage.Content = _fileData.Name;
        }

        private void GetFileData()
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
                _fileData = new FileInfo(fileDialog.FileName);
        }
    }
}
