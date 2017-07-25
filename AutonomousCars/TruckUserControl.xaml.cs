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
