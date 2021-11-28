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
using System.Windows.Shapes;

namespace ITParkApp {
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //ListBox listBox1 = new ListBox();
            //Team.CreateNewTeam(listBox1);
            //var userNewTeam1 = listBox1.SelectedItem.ToString();
            //var userNewTeam2 = listBox1.Items[1].ToString();
            //var userNewTeam3 = listBox1.Items[2].ToString();
            //var userNewTeam4 = listBox1.Items[3].ToString();
            //var userNewTeam5 = listBox1.Items[4].ToString();

            var userNameNewTeam = textBox2.Text;
            Team team = new Team(userNameNewTeam, MainWindow.userNewTeam1, MainWindow.userNewTeam2, MainWindow.userNewTeam3, MainWindow.userNewTeam4, MainWindow.userNewTeam5);
            Team.AddToDatabaseTeam(team);
            MessageBox.Show("New team was created");
            Window1 window1 = new Window1();
            window1.Close();
        }
    }
}
