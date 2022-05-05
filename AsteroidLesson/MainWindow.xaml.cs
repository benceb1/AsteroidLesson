using AsteroidLesson.Logic;
using Common;
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
using System.Windows.Threading;

namespace AsteroidLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AsteroidLogic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new AsteroidLogic();
            display.SetupModel(logic);

           /* DispatcherTimer dt = new DispatcherTimer();

            dt.Interval = TimeSpan.FromMilliseconds(100);

            dt.Tick += Dt_Tick;

            dt.Start();*/
        }

        /*private void Dt_Tick(object? sender, EventArgs e)
        {
            logic.TimeStep();
        }*/

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupClient();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                logic.Control(Controls.Left);
            }
            else if (e.Key == Key.Right)
            {
                logic.Control(Controls.Right);

            }
            else if (e.Key == Key.Space)
            {
                logic.Control(Controls.Shoot);
            }
            else if (e.Key == Key.Up)
            {
                logic.Control(Controls.Forward);
            }
        }
    }
}
