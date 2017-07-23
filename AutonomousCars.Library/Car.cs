using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCars.Library
{
    public class Car : IComparable<Car>
    {
        public Road Road { get; set; }

        /// <summary>
        /// How often are the values recalculated. 1 second here to be consistent with the other units of measurement
        /// </summary>
        private int delay = 1;

        private float position;

        /// <summary>
        /// Position
        /// </summary>
        public virtual float Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value < 0) this.position = 0;
                else this.position = value;
            }
        }

        private int lane;

        /// <summary>
        /// Lane number, where 1 is the right lane and greater values - lanes to the left
        /// </summary>
        public int Lane
        {
            get
            {
                return this.lane;
            }
            set
            {
                if (value < 0) this.lane = 0;
                else this.lane = value;
            }
        }

        private float acceleration;

        /// <summary>
        /// Acceleration speed in meters per second
        /// </summary>
        public float Acceleration
        {
            get
            {
                return this.acceleration;
            }
            private set
            {
                if (value < 0) this.acceleration = 0;
                else this.acceleration = value;
            }
        }

        private float braking;

        /// <summary>
        /// Breaking speed in meters per socond
        /// </summary>
        public float Braking
        {
            get
            {
                return this.braking;
            }
            private set
            {
                if (value < 0) this.braking = 0;
                else this.braking = value;
            }
        }

        private float maxSpeed;

        /// <summary>
        /// Maximum speed in meters per second
        /// </summary>
        public float MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
            private set
            {
                if (value < 0) this.maxSpeed = 0;
                else this.maxSpeed = value;
            }
        }

        private float speed;

        /// <summary>
        /// Current speed in meters per second
        /// </summary>
        public virtual float Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                if (value < 0) this.speed = 0;
                else if (value > this.maxSpeed) this.speed = this.maxSpeed;
                else this.speed = value;
            }
        }

        private float desiredSpeed;

        /// <summary>
        /// Desired speed in meters per second
        /// </summary>
        public float DesiredSpeed
        {
            get
            {
                return this.desiredSpeed;
            }
            set
            {
                if (value < 0) this.desiredSpeed = 0;
                else if (value > this.maxSpeed) this.desiredSpeed = this.maxSpeed;
                else this.desiredSpeed = value;
            }
        }

        private int gasIntensity;

        /// <summary>
        /// 0 to 100%
        /// </summary>
        public int GasIntensity {
            get
            {
                return this.gasIntensity;
            }
            set
            {
                if (value < 0) this.gasIntensity = 0;
                else if (value > 100) this.gasIntensity = 100;
                else this.gasIntensity = value;
            }
        }

        private int brakeIntensity;

        /// <summary>
        /// 0 to 100%
        /// </summary>
        public int BrakeIntensity
        {
            get
            {
                return this.brakeIntensity;
            }
            set
            {
                if (value < 0) this.brakeIntensity = 0;
                else if (value > 100) this.brakeIntensity = 100;
                else this.brakeIntensity = value;
            }
        }

        public Car() : this(0, 0, 0, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class
        /// </summary>
        /// <param name="acceleration"></param>
        /// <param name="breaking"></param>
        /// <param name="maxSpeed"></param>
        public Car(float acceleration, float breaking, float maxSpeed) : this(acceleration, breaking, maxSpeed, null)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class
        /// </summary>
        /// <param name="acceleration"></param>
        /// <param name="breaking"></param>
        /// <param name="maxSpeed"></param>
        public Car(float acceleration, float breaking, float maxSpeed, Road road)
        {
            this.Acceleration = acceleration;
            this.Braking = breaking;
            this.MaxSpeed = maxSpeed;

            this.Road = road;
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

        private float prevDistance;

        private async Task ChangeSpeed()
        {
            var forwardCar = this.Road.Where(c => c.Lane == this.Lane).Where(c => c.Position > this.Position).Min();
            float speedChange = 0;
            if (forwardCar != null)
            {
                // Make it dependent of speed
                var safeDistance = 60;
                var currentDistance = forwardCar.Position - this.Position;
                if (currentDistance < safeDistance)
                {
                    if (this.GasIntensity > 0)
                    {
                        this.GasIntensity -= 25;
                    }
                    else
                    {
                        this.BrakeIntensity += 25;
                    }
                    this.prevDistance = currentDistance;
                }
                else
                {
                    this.GasIntensity = 100;
                    this.BrakeIntensity = 0;
                }
            }
            speedChange = (this.Acceleration * this.GasIntensity / 100) - (this.Braking * this.BrakeIntensity / 100);
            this.Speed += speedChange;
        }

        public int CompareTo(Car that)
        {
            return this.Position.CompareTo(that.Position);
        }
    }
}
