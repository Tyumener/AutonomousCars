namespace AutonomousCars.WpfLibrary
{
    using System.ComponentModel;
    using AutonomousCars.Library;
    using AutonomousCars.Library.Cars;

    public class ObservableCar : Car, INotifyPropertyChanged
    {
        public ObservableCar(float acceleration, float braking, float maxSpeed, Road road) : base(acceleration, braking, maxSpeed, road)
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

        public override int Lane
        {
            get
            {
                return base.Lane;
            }
            set
            {
                base.Lane = value;
                OnPropertyChanged("Lane");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
