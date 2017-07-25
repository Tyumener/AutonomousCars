namespace AutonomousCars
{
    using AutonomousCars.Library;
    using AutonomousCars.WpfLibrary;
    using System.Windows;

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Road road = new Road();

        public MainWindow()
        {
            InitializeComponent();

            this.road.Drive();
        }

        private void SlowCarLane1_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.02f, 1.2f, 1);            
        }

        private void FastCarLane1_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.08f, 2.2f, 1);
        }

        private void SlowTruckLane1_Click(object sender, RoutedEventArgs e)
        {
            AddTruck(0.01f, 1.0f, 1);
        }

        private void FastTruckLane1_Click(object sender, RoutedEventArgs e)
        {
            AddTruck(0.05f, 1.9f, 1);
        }

        private void SlowCarLane2_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.02f, 1.2f, 2);
        }

        private void FastCarLane2_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.08f, 2.2f, 2);
        }

        private void SlowTruckLane2_Click(object sender, RoutedEventArgs e)
        {
            AddTruck(0.01f, 1.0f, 2);
        }

        private void FastTruckLane2_Click(object sender, RoutedEventArgs e)
        {
            AddTruck(0.05f, 1.9f, 2);
        }

        private void SlowCarLane3_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.02f, 1.2f, 3);
        }

        private void FastCarLane3_Click(object sender, RoutedEventArgs e)
        {
            AddCar(0.08f, 2.2f, 3);
        }

        private void SlowTruckLane3_Click(object sender, RoutedEventArgs e)
        {
            AddTruck(0.01f, 1.0f, 3);
        }

        private void FastTruckLane3_Click(object sender, RoutedEventArgs e)
        {
            AddTruck(0.05f, 1.9f, 3);
        }

        private void AddCar(float acceleration, float maxSpeed, int lane)
        {
            ObservablePassengerCar car = new ObservablePassengerCar(acceleration, 0.06f, maxSpeed, road);
            car.Lane = lane;
            car.GasIntensity = 100;
            this.road.Add(car);

            MyGrid.Children.Add(new CarUserControl(car));
        }

        private void AddTruck(float acceleration, float maxSpeed, int lane)
        {
            ObservableTruck truck = new ObservableTruck(acceleration, 0.06f, maxSpeed, road);
            truck.Lane = lane;
            truck.GasIntensity = 100;
            this.road.Add(truck);

            MyGrid.Children.Add(new TruckUserControl(truck));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.road.RoadType = RoadType.Autobahn;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.road.RoadType = RoadType.City;
        }
    }
}
