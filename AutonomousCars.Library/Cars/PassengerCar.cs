namespace AutonomousCars.Library.Cars
{
    public class PassengerCar : Car
    {
        public PassengerCar(float acceleration, float braking, float maxSpeed, Road road) : base(acceleration, braking, maxSpeed, road)
        {
        }

        public override bool CanOvertake => true;

        public override int Length => 40;
    }
}
