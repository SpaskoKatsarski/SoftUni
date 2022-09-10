using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double CarFuelConsumptionIncrement = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => CarFuelConsumptionIncrement;
    }
}
