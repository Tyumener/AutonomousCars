using AutonomousCars.Library;
using AutonomousCars.WpfLibrary;
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

namespace AutonomousCars
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car car; 

        public MainWindow()
        {
            this.car = new ObservableCar(4, 1, 120);
            this.car.GasIntensity = 50;
            this.car.BrakeIntensity = 0;

            InitializeComponent();

            this.DataContext = car;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.car.Drive();
        }
    }
}
