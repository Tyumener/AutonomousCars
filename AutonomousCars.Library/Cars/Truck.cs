namespace AutonomousCars.Library.Cars
{
    public class Truck : Car
    {
        public Truck(float acceleration, float braking, float maxSpeed, Road road) : base(acceleration, braking, maxSpeed, road)
        {
        }

        public override bool CanOvertake => false;

        public override int Length => 80;
    }
}
