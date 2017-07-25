namespace AutonomousCars.Library.Sonars
{
    using System;
    using AutonomousCars.Library.Cars;

    /// <summary>
    /// Class that represents a left sonar
    /// </summary>
    public class LeftSonar : Sonar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeftSonar"/> class
        /// </summary>
        /// <param name="car">Car object</param>
        public LeftSonar(Car car)
            : base(car)
        {
        }

        /// <summary>
        /// Gets a predicate used to filter other cars
        /// </summary>
        protected override Func<Car, bool> Predicate => thatCar =>
            thatCar.Lane == this.car.Lane + 1 &&
            Math.Abs(this.car.Position - thatCar.Position) < this.car.SafeDistance;
    }
}
