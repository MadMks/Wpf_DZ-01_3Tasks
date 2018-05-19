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

namespace Task_1_TextEditor
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

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Cut();
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Copy();
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Paste();
        }
    }
}
