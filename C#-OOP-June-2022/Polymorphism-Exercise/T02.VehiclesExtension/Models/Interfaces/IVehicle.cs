using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double liters);
    }
}
