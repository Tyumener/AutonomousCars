namespace AutonomousCars.Library.Sonars
{
    using System;
    using AutonomousCars.Library.Cars;

    /// <summary>
    /// Class that represents a front sonar
    /// </summary>
    public class FrontSonar : Sonar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrontSonar"/> class
        /// </summary>
        /// <param name="car">Car object</param>
        public FrontSonar(Car car)
            : base(car)
        {
        }

        /// <summary>
        /// Gets a predicate used to filter other cars
        /// </summary>
        protected override Func<Car, bool> Predicate => thatCar =>
            thatCar.Lane == this.car.Lane && thatCar.Position > this.car.Position;
    }
}
