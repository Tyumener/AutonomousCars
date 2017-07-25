namespace AutonomousCars.Library
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutonomousCars.Library.Cars;

    public class Road : List<Car>
    {
        /// <summary>
        /// How often are the values recalculated. 1 second here to be consistent with the other units of measurement
        /// </summary>
        private int delay = 10;

        public float MaxPosition { get; set; } = 1000;

        public int MaxLanes { get; set; } = 3;

        public RoadType RoadType { get; set; }

        public Road()
        {
            this.RoadType = RoadType.Autobahn;
        }

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