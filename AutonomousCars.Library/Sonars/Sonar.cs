namespace AutonomousCars.Library.Sonars
{
    using System;
    using System.Linq;
    using AutonomousCars.Library.Cars;

    public abstract class Sonar
    {
        protected Car car;

        protected virtual Func<Car, bool> Predicate { get; }
        
        public Sonar(Car car)
        {
            this.car = car;
        }

        public float? MeasureDistance()
        {
            var thatCar = this.car.Road.Where(this.Predicate).Min();
            return thatCar?.Position - thatCar?.Length - this.car.Position;
        }
    }
}
