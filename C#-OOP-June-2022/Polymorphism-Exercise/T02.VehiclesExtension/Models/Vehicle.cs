using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        private Vehicle()
        {
            this.FuelConsumptionModifier = 0;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : this()
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        //Full property -> Open to extension, easy can add validation
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value + this.FuelConsumptionModifier;
            }
        }

        public double TankCapacity 
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                this.tankCapacity = value;
            } 
        }

        protected virtual double FuelConsumptionModifier { get; }

        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                //Not enough fuel
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
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
                this.FuelQuantity += liters;
            }
        } 

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
