namespace AutonomousCars.Library
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutonomousCars.Library.Cars;

    /// <summary>
    /// Class that represents a road
    /// </summary>
    public class Road : List<Car>
    {
        /// <summary>
        /// How often the values are recalculated.
        /// </summary>
        private int delay = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Road"/> class
        /// </summary>
        public Road()
        {
            this.RoadType = RoadType.Autobahn;
        }

        /// <summary>
        /// Gets or sets the maximum position for the road
        /// </summary>
        public float MaxPosition { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the maximum number of lines of the road
        /// </summary>
        public int MaxLanes { get; set; } = 3;

        /// <summary>
        /// Gets or sets the road type
        /// </summary>
        public RoadType RoadType { get; set; }

        /// <summary>
        /// Start the usage of the road
        /// </summary>
        public async void Drive()
        {
            while (true)
            {
                var carsToRemove = new List<Car>();
                this.ForEach(car => car.Move());
                this.RemoveAll(c => c.Position >= this.MaxPosition);
                await Task.Delay(this.delay);
            }
        }
    }
}