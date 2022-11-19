using labWork22.Data;
using labWork22.Models;
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
    /// Логика взаимодействия для Task3Page.xaml
    /// </summary>
    public partial class Task3Page : Window
    {
        public Task3Page()
        {
            InitializeComponent();
        }

        private void InmortButton_Click(object sender, RoutedEventArgs e)
        {
            var file = File.ReadAllLines(@"C:\Temp\ispp01\mdk1101\labWork22\labWork22\users.csv");
            foreach (var line in file)
            {
                if (line.Split(";").First() == "id")
                    continue;
                var splitedUser = line.Split(";");
                var user = new Lw22User();
                user.Ip = splitedUser[0];
                user.Name = splitedUser[1];
                user.Login = splitedUser[2];
                user.Password = splitedUser[3];
                user.Ip = splitedUser[4];
                user.LastEnter = ParsData(splitedUser[5]);
                using var contexet = new Ispp0104Context();
                contexet.Lw22Users.Add(user);
                contexet.SaveChanges();
            }
        }
        private DateTime ParsData(string dataString)
        {
            if (dataString.Contains("/"))
            {
                var firstTime = dataString.Split("/").First();
                var secondTime = dataString.Split("/")[1];
                var yearTime = dataString.Split("/").Last();
                return DateTime.Parse($"{secondTime}.{firstTime}.{yearTime}");
            }
            return DateTime.Parse(dataString);
        }
    }
}
