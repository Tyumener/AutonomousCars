using System;
using System.Collections.Generic;

namespace AutonomousCars.Library
{
    public class Road : List<Car> 
    {
        public event EventHandler<CarAddedEventArgs> CarAdded;
        
        public Road()
        {
            
        }                            

        public new void Add(Car car)
        {
            car.Road = this;
            base.Add(car);
            OnCarAdded(new CarAddedEventArgs(car));
        }

        protected virtual void OnCarAdded(CarAddedEventArgs e)
        {
            var handler = CarAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}