using AutonomousCars.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCars.WpfLibrary
{
    public class ObservableCar : Car, INotifyPropertyChanged
    {
        public ObservableCar(int acceleration, int breaking, int maxSpeed) : base(acceleration, breaking, maxSpeed)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override int Speed
        {
            get
            {
                return base.Speed;
            }
            set
            {
                base.Speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public override int Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                OnPropertyChanged("Position");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
