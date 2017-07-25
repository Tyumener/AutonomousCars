using AutonomousCars.WpfLibrary;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutonomousCars
{
    /// <summary>
    /// Interaktionslogik für Car.xaml
    /// </summary>
    public partial class CarUserControl : UserControl
    {
        private Random r = new Random();

        public ObservablePassengerCar Car { get; set; }

        public CarUserControl(ObservablePassengerCar car)
        {
            InitializeComponent();

            this.MyRect.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

            this.Car = car;
            this.DataContext = this.Car;

            System.Threading.Thread.Sleep(100);
        }        
    }
}
