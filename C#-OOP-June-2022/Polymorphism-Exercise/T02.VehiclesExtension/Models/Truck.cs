using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoeffiecient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double FuelConsumptionModifier
            => TruckFuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += liters * RefuelCoeffiecient;
            }
        }
    }
}
