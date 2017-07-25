namespace AutonomousCars.Library.Sonars
{
    using System;
    using AutonomousCars.Library.Cars;

    /// <summary>
    /// Class that represents a right sonar
    /// </summary>
    public class RightSonar : Sonar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightSonar"/> class
        /// </summary>
        /// <param name="car">Car object</param>
        public RightSonar(Car car)
            : base(car)
        {
        }

        /// <summary>
        /// Gets a predicate used to filter other cars
        /// </summary>
        protected override Func<Car, bool> Predicate => thatCar =>
            thatCar.Lane == this.car.Lane - 1 &&
            this.car.Position - thatCar.Position - thatCar.Length < this.car.SafeDistance;
    }
}
