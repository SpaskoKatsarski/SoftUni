using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionIncrement = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        protected override double FuelConsumptionModifier
            => BusFuelConsumptionIncrement;

        public string BusStateDrive { get; set; }

        public string DriveEmpty(double distance)
        {
            if (base.FuelQuantity - (base.FuelConsumption - BusFuelConsumptionIncrement) * distance > 0)
            {
                this.FuelQuantity -= (base.FuelConsumption - BusFuelConsumptionIncrement) * distance;
                return $"{nameof(Bus)} travelled {distance} km";
            }
            else
            {
                return $"{nameof(Bus)} needs refueling";
            }
        }
    }
}
