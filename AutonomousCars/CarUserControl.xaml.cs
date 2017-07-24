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
    /// Interaktionslogik für Car.xaml
    /// </summary>
    public partial class CarUserControl : UserControl
    {
        private Random r = new Random();

        public ObservableCar CarObject { get; set; } = new ObservableCar();

        public CarUserControl(ObservableCar car)
        {
            InitializeComponent();

            this.MyRect.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 233)));


            this.CarObject = car;
            this.DataContext = this.CarObject;

            System.Threading.Thread.Sleep(100);
        }        
    }
}
