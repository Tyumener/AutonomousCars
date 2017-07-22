using System;
using System.Collections.Generic;

namespace AutonomousCars.Library
{
    public class Road<T> : List<T> where T: Car 
    {
        public event EventHandler<CarAddedEventArgs> CarAdded;

        public Road()
        {
            
        }                            

        public new void Add(T car)
        {
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