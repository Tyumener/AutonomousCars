using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCars.Library
{
    public class CarAddedEventArgs : EventArgs
    {
        public Car Car { get; set; }

        public CarAddedEventArgs(Car car)
        {
            this.Car = car;
        }
    }
}
