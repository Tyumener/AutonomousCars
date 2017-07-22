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
        ObservableCar car;
        ObservableCar car2;

        Road<ObservableCar> road = new Road<ObservableCar>();

        public MainWindow()
        {
            this.car = new ObservableCar(4, 1, 120);
            this.car.GasIntensity = 50;
            this.car.BrakeIntensity = 0;

            InitializeComponent();

            this.DataContext = car;

            var slowCar = new ObservableCar(2, 4, 15);
            slowCar.Lane = 1;
            slowCar.GasIntensity = 100;

            var fastCar = new ObservableCar(4, 5, 20);
            fastCar.Lane = 2;
            fastCar.GasIntensity = 100;

            var muscleCar = new ObservableCar(6, 6, 25);
            muscleCar.Lane = 3;
            muscleCar.GasIntensity = 100;

            this.road.Add(slowCar);
            this.road.Add(fastCar);
            this.road.Add(muscleCar);            

            this.road.ForEach(c => { MyGrid.Children.Add(new Car(c)); });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.car.Drive();
            //this.car2.Drive();
            this.road.ForEach(c => c.Drive());
        }
    }
}
