namespace AutonomousCars.Library.Sonars
{
    using System;
    using AutonomousCars.Library.Cars;

    public class RightSonar : Sonar
    {
        public RightSonar(Car car)
            : base(car)
        {
        }

        protected override Func<Car, bool> Predicate => thatCar =>
            thatCar.Lane == this.car.Lane - 1 &&
            this.car.Position - thatCar.Position - thatCar.Length < this.car.SafeDistance;
    }
}
