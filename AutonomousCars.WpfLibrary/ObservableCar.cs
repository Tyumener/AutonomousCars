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
        public ObservableCar() : base()
        {
        }

        public ObservableCar(float acceleration, float breaking, float maxSpeed) : base(acceleration, breaking, maxSpeed)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override float Speed
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

        public override float Position
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
