using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCars.Library
{
    public class Car
    {
        /// <summary>
        /// How often are the values recalculated. 1 second here to be consistent with the other units of measurement
        /// </summary>
        private int delay = 10;

        /// <summary>
        /// Position
        /// </summary>
        public virtual float Position { get; set; }

        /// <summary>
        /// Lane number, where 1 is the right lane and greater values - lanes to the left
        /// </summary>
        public int Lane { get; set; }

        /// <summary>
        /// Acceleration speed in meters per second
        /// </summary>
        public float Acceleration { get; private set; }

        /// <summary>
        /// Breaking speed in meters per socond
        /// </summary>
        public float Braking { get; private set; }

        /// <summary>
        /// Maximum speed in meters per second
        /// </summary>
        public float MaxSpeed { get; private set; }

        /// <summary>
        /// Current speed in meters per second
        /// </summary>
        public virtual float Speed { get; set; }

        /// <summary>
        /// Desired speed in meters per second
        /// </summary>
        public float DesiredSpeed { get; set; }

        /// <summary>
        /// 0 to 100%
        /// </summary>
        public int GasIntensity { get; set; }

        /// <summary>
        /// 0 to 100%
        /// </summary>
        public int BrakeIntensity { get; set; }

        public Car()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class
        /// </summary>
        /// <param name="acceleration"></param>
        /// <param name="breaking"></param>
        /// <param name="maxSpeed"></param>
        public Car(float acceleration, float breaking, float maxSpeed)
        {
            this.Acceleration = acceleration;
            this.Braking = breaking;
            this.MaxSpeed = maxSpeed;        
        }

        public async void Drive()
        {
            while (true)
            {
                await ChangeSpeed();
                this.Position += this.Speed;

                await Task.Delay(this.delay);
            }            
        }

        private async Task ChangeSpeed()
        {
            var speedChange = (this.Acceleration * this.GasIntensity / 100) - (this.Braking * this.BrakeIntensity / 100);
            this.Speed += speedChange;            
        }
    }
}
