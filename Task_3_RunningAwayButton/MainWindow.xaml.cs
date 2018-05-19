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

namespace Task_3_RunningAwayButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double clientRectWidth;
        private double clientRectHeight;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
            Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
        }

        private double GetPointVerticalForCenteringButton()
        {
            return (this.canvas.ActualHeight / 2) - (this.fieldAround.ActualHeight / 2);
        }

        private double GetPointHorizontForCenteringButton()
        {
            return (this.canvas.ActualWidth / 2) - (this.fieldAround.ActualWidth / 2);
        }

        private void fieldAround_MouseEnter(object sender, MouseEventArgs e)
        {
            //Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) + 1);
        }

        private void fieldAround_MouseMove(object sender, MouseEventArgs e)
        {
            // e.MouseDevice.GetPosition(sender as Canvas).

            Rect rect = new Rect(
                Canvas.GetLeft(this.fieldAround),
                Canvas.GetTop(this.fieldAround),
                this.fieldAround.ActualWidth,
                this.fieldAround.ActualHeight
                );
            rect.Height = (sender as Canvas).ActualHeight;
            rect.Width = (sender as Canvas).ActualWidth;
            if (rect.Contains(e.MouseDevice.GetPosition(this.fieldAround)) == true)
            {
                Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) + 10);
            }
        }
    }
}
