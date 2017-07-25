namespace AutonomousCars.Library.Sonars
{
    using System;
    using AutonomousCars.Library.Cars;

    public class LeftSonar : Sonar
    {
        public LeftSonar(Car car)
            : base(car)
        {
        }

        protected override Func<Car, bool> Predicate => thatCar =>
            thatCar.Lane == this.car.Lane + 1 &&
            Math.Abs(this.car.Position - thatCar.Position) < this.car.SafeDistance;
    }
}
