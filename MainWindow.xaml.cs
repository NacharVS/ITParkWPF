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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITParkApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            ImageClass image1 = new ImageClass(File.ReadAllBytes("C:/Users/01/Desktop/cats.jpg"));
            ImageClass.database(image1);
            //image.Source = new BitmapImage(new Uri($"C:/Users/01/Desktop/cats.jpg"));
        }

        private void sorcerer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rogue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void warrior_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
