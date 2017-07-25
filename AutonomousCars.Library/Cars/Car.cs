namespace AutonomousCars.Library.Cars
{
    using System;
    using AutonomousCars.Library.Sonars;

    /// <summary>
    /// Abstract class that represents an autonomous car
    /// </summary>
    public abstract class Car : IComparable<Car>
    {
        /// <summary>
        /// Position of the car
        /// </summary>
        private float position;

        /// <summary>
        /// Lane of the road the car uses
        /// </summary>
        private int lane;

        /// <summary>
        /// The ability of the car to gain speed. Measured in pixels per iteration
        /// </summary>
        private float acceleration;

        /// <summary>
        /// The ability of the car to brake. Measured in pixels per iteration
        /// </summary>
        private float braking;

        /// <summary>
        /// Maximum speed of the car
        /// </summary>
        private float maxSpeed;

        /// <summary>
        /// Speed of the car
        /// </summary>
        private float speed;

        /// <summary>
        /// Desired speed of the car
        /// </summary>
        private float desiredSpeed;

        /// <summary>
        /// Representation of the gas pedal
        /// </summary>
        private int gasIntensity;

        /// <summary>
        /// Representation of the brake pedal
        /// </summary>
        private int brakeIntensity;

        /// <summary>
        /// A flag indicating that the line was changed on the current iteration
        /// </summary>
        private bool laneWasChanged = false;

        /// <summary>
        /// Distance to the front car on the previous iteration
        /// </summary>
        private float prevDistance;

        // TODO: Sonars need to be implemented as properties in order to cover the logic with Unit Tests

        /// <summary>
        /// Front sonar
        /// </summary>
        private Sonar frontSonar;

        /// <summary>
        /// Left sonar
        /// </summary>
        private Sonar leftSonar;

        /// <summary>
        /// Right sonar
        /// </summary>
        private Sonar rightSonar;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class
        /// </summary>
        /// <param name="acceleration">The ability of the car to gain speed. Measured in pixels per iteration</param>
        /// <param name="braking">The ability of the car to brake. Measured in pixels per iteration</param>
        /// <param name="maxSpeed">Maximum speed of the car</param>
        /// <param name="road">The road object, that is aware of all the other cars</param>
        public Car(float acceleration, float braking, float maxSpeed, Road road)
        {
            this.Acceleration = acceleration;
            this.Braking = braking;
            this.MaxSpeed = maxSpeed;
            this.Road = road;
            this.frontSonar = new FrontSonar(this);
            this.leftSonar = new LeftSonar(this);
            this.rightSonar = new RightSonar(this);
        }

        /// <summary>
        /// Gets or sets the road object, that is aware of all the other cars
        /// </summary>
        public Road Road { get; set; }

        /// <summary>
        /// Gets or sets the car's position. Measured in points
        /// </summary>
        public virtual float Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value < 0)
                {
                    this.position = 0;
                }
                else
                {
                    this.position = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the lane number, where 1 is the right lane and greater values - lanes to the left
        /// </summary>
        public virtual int Lane
        {
            get
            {
                return this.lane;
            }

            set
            {
                if (value < 0)
                {
                    this.lane = 0;
                }
                else
                {
                    this.lane = value;
                }
            }
        }

        /// <summary>
        /// Gets the car's ability to accelerate. The ability of the car to gain speed. Measured in pixels per iteration
        /// </summary>
        public float Acceleration
        {
            get
            {
                return this.acceleration;
            }

            private set
            {
                if (value < 0)
                {
                    this.acceleration = 0;
                }
                else
                {
                    this.acceleration = value;
                }
            }
        }

        /// <summary>
        /// Gets the car's ability to brake. Measured in pixels per iteration
        /// </summary>
        public float Braking
        {
            get
            {
                return this.braking;
            }

            private set
            {
                if (value < 0)
                {
                    this.braking = 0;
                }
                else
                {
                    this.braking = value;
                }
            }
        }


        /// <summary>
        /// Gets the car's maximum speed. Measured in pixels per iteration
        /// </summary>
        public float MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }

            private set
            {
                if (value < 0)
                {
                    this.maxSpeed = 0;
                }
                else
                {
                    this.maxSpeed = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the car's speed. Measured in pixels per iteration
        /// </summary>
        public virtual float Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                if (value < 0)
                {
                    this.speed = 0;
                }
                else if (value > this.maxSpeed)
                {
                    this.speed = this.maxSpeed;
                }
                else
                {
                    this.speed = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the car's desired speed. Measured in pixels per iteration
        /// </summary>
        public float DesiredSpeed
        {
            get
            {
                return this.desiredSpeed;
            }

            set
            {
                if (value < 0)
                {
                    this.desiredSpeed = 0;
                }
                else if (value > this.maxSpeed)
                {
                    this.desiredSpeed = this.maxSpeed;
                }
                else
                {
                    this.desiredSpeed = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the position of the car's gas pedal. Measured in % from 0 to 100
        /// </summary>
        public int GasIntensity
        {
            get
            {
                return this.gasIntensity;
            }

            set
            {
                if (value < 0)
                {
                    this.gasIntensity = 0;
                }
                else if (value > 100)
                {
                    this.gasIntensity = 100;
                }
                else
                {
                    this.gasIntensity = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the position of the car's brake pedal. Measured in % from 0 to 100
        /// </summary>
        public int BrakeIntensity
        {
            get
            {
                return this.brakeIntensity;
            }

            set
            {
                if (value < 0)
                {
                    this.brakeIntensity = 0;
                }
                else if (value > 100)
                {
                    this.brakeIntensity = 100;
                }
                else
                {
                    this.brakeIntensity = value;
                }
            }
        }

        /// <summary>
        /// Gets the distance between cars that is considered to be safe
        /// </summary>
        public int SafeDistance { get; } = 60;

        /// <summary>
        /// Gets the car's length
        /// </summary>
        public virtual int Length { get; }

        /// <summary>
        /// Gets a value indicating whether the car can overtake other cars
        /// </summary>
        public virtual bool CanOvertake { get; }

        /// <summary>
        /// Compare cars
        /// </summary>
        /// <param name="that">That car</param>
        /// <returns>An integer indicating whether an object is less, greater or equal to the given object</returns>
        public int CompareTo(Car that)
        {
            return this.Position.CompareTo(that.Position);
        }

        /// <summary>
        /// Move through the iteration
        /// </summary>
        public void Move()
        {
            var distanceToFrontCar = this.frontSonar.MeasureDistance();
            var distanceToLeftCar = this.leftSonar.MeasureDistance();
            var distanceToRightCar = this.rightSonar.MeasureDistance();

            if (distanceToFrontCar != null && distanceToFrontCar < this.SafeDistance)
            {
                if (this.CanOvertake && distanceToLeftCar == null && this.Lane < this.Road.MaxLanes)
                {
                    this.Lane += 1;
                    this.laneWasChanged = true;
                }
                else
                {
                    if (this.prevDistance != 0)
                    {
                        var forwardCarSpeed = this.Speed - (this.prevDistance - distanceToFrontCar.Value);

                        this.BrakeIntensity = (int)Math.Ceiling((this.Speed - forwardCarSpeed) / this.Braking) * 100;
                        this.GasIntensity = 0;
                    }

                    this.prevDistance = distanceToFrontCar.Value;
                }
            }
            else
            {
                this.GasIntensity = 100;
                this.BrakeIntensity = 0;
            }

            if (this.Road.RoadType == RoadType.Autobahn && this.Lane > 1 && !this.laneWasChanged)
            {
                if (distanceToRightCar == null)
                {
                    this.Lane -= 1;
                }
            }

            this.Speed += (this.Acceleration * this.GasIntensity / 100) - (this.Braking * this.BrakeIntensity / 100);

            this.Position += this.Speed;

            this.laneWasChanged = false;
        }
    }
}
