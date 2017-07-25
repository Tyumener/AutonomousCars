using AutonomousCars.WpfLibrary;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutonomousCars
{
    /// <summary>
    /// Interaction logic for TruckUserControl.xaml
    /// </summary>
    public partial class TruckUserControl : UserControl
    {
        private Random r = new Random();

        public ObservableTruck Truck { get; set; }

        public TruckUserControl(ObservableTruck truck)
        {
            InitializeComponent();

            this.MyRect.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

            this.Truck = truck;
            this.DataContext = this.Truck;

            System.Threading.Thread.Sleep(100);
        }
    }
}
