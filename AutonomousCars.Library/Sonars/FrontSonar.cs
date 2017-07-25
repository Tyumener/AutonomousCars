namespace AutonomousCars.Library.Sonars
{
    using System;
    using AutonomousCars.Library.Cars;

    public class FrontSonar : Sonar
    {
        public FrontSonar(Car car)
            : base(car)
        {
        }

        protected override Func<Car, bool> Predicate => thatCar =>
            thatCar.Lane == this.car.Lane && thatCar.Position > this.car.Position;
    }
}
