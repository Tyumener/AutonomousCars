namespace AutonomousCars.Library.Sonars
{
    using System;
    using System.Linq;
    using AutonomousCars.Library.Cars;

    /// <summary>
    /// Abstract class that represents a sonar
    /// </summary>
    public abstract class Sonar
    {
        /// <summary>
        /// Car object
        /// </summary>
        protected Car car;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sonar"/> class
        /// </summary>
        /// <param name="car">car object</param>
        public Sonar(Car car)
        {
            this.car = car;
        }

        /// <summary>
        /// Gets a predicate used to filter other cars
        /// </summary>
        protected virtual Func<Car, bool> Predicate { get; }

        /// <summary>
        /// Measure a distance to the car filtered by the predicate
        /// </summary>
        /// <returns>Distance in pixels</returns>
        public float? MeasureDistance()
        {
            var thatCar = this.car.Road.Where(this.Predicate).Min();
            return thatCar?.Position - thatCar?.Length - this.car.Position;
        }
    }
}
