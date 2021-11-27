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
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ITParkApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User(textBox.Text, textBox1.Text, textBox2.Text);

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Matchmaker");
            var collection = database.GetCollection<User>("Users").AsQueryable<User>();

            User.AddToDatabase(user1);
            listBox.Items.Add(user1.Login);

        }

        public void UpdateList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Matchmaker");
            var collection = database.GetCollection<User>("Users").AsQueryable<User>();
            
            foreach(var item in collection)
            {
                listBox.Items.Add(item.Login);
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Team.AddToTeam(listBox.SelectedItem.ToString(), listBox1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Team.CreateTeam(listBox1, textBox3);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Team.DeleteFromTeam(listBox1);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            textBox3.Text = null;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            string[] users = new string[listBox.Items.Count];
            for(int i = 0; i < listBox.Items.Count; i++)
            {
                users[i] = listBox.Items[i].ToString();
            }
            for(int i = 0; i < 5; i++)
            {
                int rnd = new Random().Next(0, listBox.Items.Count);

                if (!listBox1.Items.Contains(users[rnd])) listBox1.Items.Add(users[rnd]);
                else i--;
            }
        }


    }
}
