namespace AutonomousCars.Library.Cars
{
    /// <summary>
    /// Class that represents a truck
    /// </summary>
    public class Truck : Car
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Truck"/> class
        /// </summary>
        /// <param name="acceleration">The ability of the car to gain speed. Measured in pixels per iteration</param>
        /// <param name="braking">The ability of the car to brake. Measured in pixels per iteration</param>
        /// <param name="maxSpeed">Maximum speed of the car</param>
        /// <param name="road">The road object, that is aware of all the other cars</param>
        public Truck(float acceleration, float braking, float maxSpeed, Road road)
            : base(acceleration, braking, maxSpeed, road)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the car can overtake other cars
        /// </summary>
        public override bool CanOvertake => false;

        /// <summary>
        /// Gets the car's length
        /// </summary>
        public override int Length => 80;
    }
}
