using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
