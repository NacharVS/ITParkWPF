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

using System.IO;
using System.Threading;

namespace ITParkApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string userNewTeam1;
        public static string userNewTeam2;
        public static string userNewTeam3;
        public static string userNewTeam4;
        public static string userNewTeam5;


        public MainWindow()
        {
            InitializeComponent();
            //File.Create("C:/Users/01/Desktop/ITParkWPF/text.txt");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.Items.Count == 5)
            {
                userNewTeam1 = listBox1.Items[0].ToString();
                userNewTeam2 = listBox1.Items[1].ToString();
                userNewTeam3 = listBox1.Items[2].ToString();
                userNewTeam4 = listBox1.Items[3].ToString();
                userNewTeam5 = listBox1.Items[4].ToString();
                Window1 window = new Window1();
                window.Show();
            }
            else
                MessageBox.Show("Choose 5 members to create a new team");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(textBox.Text, Convert.ToInt32(textBox1.Text));
            User.AddToDatabaseUser(user);
            listBox.Items.Add(user.Login);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            var users = collection.Find(filter => filter.Login == listBox.SelectedItem.ToString()).ToList();
            foreach (var item in users)
            {
                if (listBox.SelectedItem.ToString() != null)
                    MessageBox.Show($"Login: {item.Login} \nPassword {item.Password}");
                else
                    MessageBox.Show("Choose someone");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            byte[] imgArray = File.ReadAllBytes("C:/Users/01/Desktop/ITParkWPF/resize_on_the_fly.jpg");
            using (FileStream fs = new FileStream("C:/Users/01/Desktop/ITParkWPF/testImgArray.txt", FileMode.OpenOrCreate))
            {
                fs.Write(imgArray);
            }

            Passport passport = new Passport(imgArray);
            Passport.AddToDatabasePicture(passport);
            Passport.GetFromDatabasePicture();

            //using (FileStream fs = new FileStream("C:/Users/01/Desktop/ITParkWPF/resize_on_the_fly2222.png", FileMode.OpenOrCreate))
            //{
            //    fs.Write(passport.Picture, 0, passport.Picture.Length);
            //}
            
            image.Source = new BitmapImage(new Uri($"C:/Users/01/Desktop/ITParkWPF/{passport._id}.png"));

            //using (StreamWriter sw = new StreamWriter("C:/Users/01/Desktop/ITParkWPF/text.txt", true))
            //{
            //    string st = listBox.SelectedItem.ToString();
            //    sw.WriteLine(st);
            //}
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var conectionString = "mongodb://localhost";
            var client = new MongoClient(conectionString);
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users").AsQueryable<User>();
            foreach (var item in collection)
            {
                if (listBox.SelectedItem.ToString() == item.Login && !listBox1.Items.Contains(item.Login))
                    listBox1.Items.Add(item.Login);
                if (listBox1.Items.Count == 5)
                {
                    MessageBox.Show("Create a new team");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User.ListBoxUpdate(listBox);
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
