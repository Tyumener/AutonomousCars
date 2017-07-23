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
        Road road = new Road();

        public MainWindow()
        {
            InitializeComponent();

            //this.road.ForEach(c => { MyGrid.Children.Add(new Car((ObservableCar)c)); });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.02f, 1.2f, 1);            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddCar(0.04f, 1.8f, 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddCar(0.08f, 2.2f, 1);            
        }

        private void AddCar(float acceleration, float maxSpeed, int lane)
        {
            var car = new ObservableCar(acceleration, 0.06f, maxSpeed);
            car.Lane = lane;
            car.GasIntensity = 100;
            this.road.Add(car);

            MyGrid.Children.Add(new Car((ObservableCar)car));

            car.Drive();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddCar(0.02f, 1.2f, 2);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AddCar(0.04f, 1.8f, 2);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AddCar(0.08f, 2.2f, 2);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            AddCar(0.02f, 1.2f, 3);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            AddCar(0.04f, 1.8f, 3);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            AddCar(0.08f, 2.2f, 3);
        }
    }
}
