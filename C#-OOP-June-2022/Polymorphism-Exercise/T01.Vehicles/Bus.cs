using System;
using System.Collections.Generic;
using System.Text;

namespace T01.Vehicles
{
    public class Bus
    {
        private const double IncreasedFuelConsumptionWithPeople = 1.4;

        private double fuelQuantity;

        public Bus(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionInLitersPerKm = fuelConsumptionInLitersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumptionInLitersPerKm { private get; set; }

        public double TankCapacity { get; private set; }

        public void Drive(double distance, string busState)
        {
            if (busState.ToLower() == "driveempty")
            {
                if (this.FuelQuantity - this.FuelConsumptionInLitersPerKm * distance > 0)
                {
                    this.FuelQuantity -= this.FuelConsumptionInLitersPerKm * distance;
                    Console.WriteLine($"{nameof(Bus)} travelled {distance} km");
                }
                else
                {
                    Console.WriteLine($"{nameof(Bus)} needs refueling");
                }
            }
            else
            {
                if (this.FuelQuantity - (this.FuelConsumptionInLitersPerKm + IncreasedFuelConsumptionWithPeople) * distance > 0)
                {
                    this.FuelQuantity -= (this.FuelConsumptionInLitersPerKm + IncreasedFuelConsumptionWithPeople) * distance;
                    Console.WriteLine($"{nameof(Bus)} travelled {distance} km");
                }
                else
                {
                    Console.WriteLine($"{nameof(Bus)} needs refueling");
                }
            }
        }

        public void Refuel(double literes)
        {
            if (this.FuelQuantity + literes * 0.95 > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {literes} fuel in the tank");
            }
            else if (literes <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += literes * 0.95;
            }
        }
    }
}
