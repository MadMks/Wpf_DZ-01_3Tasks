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

namespace Task_2_ColorScheme
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

        private void rbtnJohn_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.BlueViolet;
        }

        private void btnChangeLogin_Click(object sender, RoutedEventArgs e)
        {
            this.gridForLogin.Visibility = Visibility.Visible;
        }

        private void rbtnDavid_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Cornsilk;
        }

        private void rbtnKevin_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Gainsboro;
        }
        private void rbtn_Click(object sender, RoutedEventArgs e)
        {
            this.gridForLogin.Visibility = Visibility.Hidden;
        }

    }
}
