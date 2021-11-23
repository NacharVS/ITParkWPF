using MongoDB.Driver;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITParkApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<User> listUser = new List<User>();
        //List<Team> listTeam = new List<Team>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            //Team team = new Team();
            //Team.AddToDatabaseTeam(team);
            //listBox1.Items.Add(team.User1);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(textBox.Text, Convert.ToInt32(textBox1.Text));
            User.AddToDatabaseUser(user);
            listBox.Items.Add(user.Login);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users").AsQueryable<User>();
            foreach (var item in collection)
            {
                if (listBox.SelectedItem.ToString() == item.Login)
                    listBox1.Items.Add(item.Login);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User.ListBoxUpdate(listBox);
        }
    }
}
