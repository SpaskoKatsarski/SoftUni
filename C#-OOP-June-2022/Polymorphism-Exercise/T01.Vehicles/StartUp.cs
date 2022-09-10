using System;
using System.Linq;

namespace T01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            try
            {
                string[] carInfo = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] truckInfo = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] busInfo = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
                Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
                Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

                int n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] cmdArgs = reader.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string action = cmdArgs[0];

                    if (action.Contains("Drive"))
                    {
                        if (cmdArgs[1] == "Car")
                        {
                            car.Drive(double.Parse(cmdArgs[2]));
                        }
                        else if (cmdArgs[1] == "Truck")
                        {
                            truck.Drive(double.Parse(cmdArgs[2]));
                        }
                        else if (cmdArgs[1] == "Bus")
                        {
                            bus.Drive(double.Parse(cmdArgs[2]), action);
                        }
                    }
                    else if (action == "Refuel")
                    {
                        if (cmdArgs[1] == "Car")
                        {
                            car.Refuel(double.Parse(cmdArgs[2]));
                        }
                        else if (cmdArgs[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(cmdArgs[2]));
                        }
                        else if ((cmdArgs[1] == "Bus"))
                        {
                            bus.Refuel(double.Parse(cmdArgs[2]));
                        }
                    }
                }

                writer.WriteLine($"Car: {car.FuelQuantity:f2}");
                writer.WriteLine($"Truck: {truck.FuelQuantity:f2}");
                writer.WriteLine($"Bus: {bus.FuelQuantity:f2}");
            }
            catch (ArgumentException ae)
            {
                writer.WriteLine(ae.Message);
            }

        }
    }
}
