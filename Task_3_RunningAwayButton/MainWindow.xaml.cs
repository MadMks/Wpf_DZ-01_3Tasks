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
        private const int MARGIN_FORM = 10;
        private const int STEP_SIZE = 25;

        private Random rand;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Running away button";

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

        private void fieldAround_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseCloseToTheButton(e.MouseDevice.GetPosition(null)) == true)
            {

                switch (rand.Next(4) + 1)
                {
                    case 1:
                        Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) - STEP_SIZE);
                        break;
                    case 2:
                        Canvas.SetTop(this.fieldAround, Canvas.GetTop(this.fieldAround) - STEP_SIZE);
                        break;
                    case 3:
                        Canvas.SetLeft(this.fieldAround, Canvas.GetLeft(this.fieldAround) + STEP_SIZE);
                        break;
                    case 4:
                        Canvas.SetTop(this.fieldAround, Canvas.GetTop(this.fieldAround) + STEP_SIZE);
                        break;
                    default:
                        MessageBox.Show("Error switch");
                        break;
                }
            }

            if (this.IsButtonFieldNextToTheShapeBorder())
            {
                Canvas.SetLeft(this.fieldAround, this.GetPointHorizontForCenteringButton());
                Canvas.SetTop(this.fieldAround, this.GetPointVerticalForCenteringButton());
            }
        }

        private bool IsButtonFieldNextToTheShapeBorder()
        {
            if (Canvas.GetLeft(this.fieldAround) < MARGIN_FORM
                || Canvas.GetTop(this.fieldAround) < MARGIN_FORM
                || Canvas.GetLeft(this.fieldAround) + this.fieldAround.ActualWidth
                    > ((this.Content as Grid).RenderSize.Width - MARGIN_FORM) 
                || Canvas.GetTop(this.fieldAround) + this.fieldAround.ActualHeight
                    > ((this.Content as Grid).RenderSize.Height - MARGIN_FORM))
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

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Win!");
        }
    }
}
