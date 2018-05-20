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
        private Random rand;
        //private int route;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.rand = new Random();

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

            //Rect rect = new Rect(
            //    Canvas.GetLeft(this.fieldAround),
            //    Canvas.GetTop(this.fieldAround),
            //    this.fieldAround.ActualWidth,
            //    this.fieldAround.ActualHeight
            //    );
            //rect.Height = (sender as Canvas).ActualHeight;
            //rect.Width = (sender as Canvas).ActualWidth;
            //if (rect.Contains(e.MouseDevice.GetPosition(null)) == true)
            //{
            //    //Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) + 10);
            //    this.fieldAround.Background = Brushes.DarkRed;
            //}

            if (this.IsMouseCloseToTheButton(e.MouseDevice.GetPosition(null)) == true)
            {
                this.fieldAround.Background = Brushes.DarkRed;

                //Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) + 10);

                switch (rand.Next(4) + 1)
                {
                    case 1:
                        Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) - 10);
                        //this.fieldAround.Background = Brushes.Red;
                        break;
                    case 2:
                        Canvas.SetTop(this.fieldAround, Canvas.GetTop(this.fieldAround) - 10);
                        //this.fieldAround.Background = Brushes.Black;
                        break;
                    case 3:
                        Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) + 10);
                        //this.fieldAround.Background = Brushes.Green;
                        break;
                    case 4:
                        Canvas.SetTop(this.fieldAround, Canvas.GetTop(this.fieldAround) + 10);
                        //this.fieldAround.Background = Brushes.Yellow;
                        break;
                    default:
                        MessageBox.Show("Error switch");
                        break;
                }
            }

            if (this.IsButtonFieldNextToTheShapeBorder())
            {
                this.fieldAround.Background = Brushes.Black;
                //switch (rand.Next(4) + 1)
                //{
                //    case 1:
                //        Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
                //        Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
                //        break;
                //    case 2:
                //        Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
                //        Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
                //        break;
                //    case 3:
                //        Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
                //        Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
                //        break;
                //    case 4:
                //        Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
                //        Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
                //        break;
                //    default:
                //        MessageBox.Show("Error switch");
                //        break;
                //}
                Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
                Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
            }

            this.Title = e.MouseDevice.GetPosition(null).X.ToString()
                + " " + e.MouseDevice.GetPosition(null).Y.ToString()
                + " " 
                + (this.ActualWidth
                    - this.fieldAround.ActualWidth
                    - Canvas.GetLeft(this.fieldAround)).ToString();
        }

        private bool IsButtonFieldNextToTheShapeBorder()
        {
            if (Canvas.GetLeft(this.fieldAround) < 10
                || Canvas.GetTop(this.fieldAround) < 10
                || Canvas.GetLeft(this.fieldAround) + this.fieldAround.ActualWidth > (this.ActualWidth - 10)
                || Canvas.GetTop(this.fieldAround) + this.fieldAround.ActualHeight > (this.ActualHeight - 10))
            {
                return true;
            }
            return false;
        }

        private bool IsMouseCloseToTheButton(Point pointMouse)
        {
            if (pointMouse.X > Canvas.GetLeft(this.fieldAround)
                && pointMouse.X < (Canvas.GetLeft(this.fieldAround) + this.fieldAround.ActualWidth))
            {
                return true;
            }
            return false;
        }
    }
}
