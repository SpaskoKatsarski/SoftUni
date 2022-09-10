using System;
using System.Collections.Generic;
using System.Text;

namespace T02.VehiclesExtension
{
    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Bus bus;

        public Engine(Vehicle car, Vehicle truck, Bus bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split();
                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double cmdParam = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType.Contains("Drive"))
                    {
                        if (vehicleType == "Car" && cmdType == "Drive")
                        {
                            Console.WriteLine(this.car.Drive(cmdParam));
                        }
                        else if (vehicleType == "Truck" && cmdType == "Drive")
                        {
                            Console.WriteLine(this.truck.Drive(cmdParam));
                        }
                        else if (vehicleType == "Bus")
                        {
                            if (cmdType.ToLower() == "driveempty")
                            {
                                Console.WriteLine(this.bus.DriveEmpty(cmdParam));
                            }
                            else if (cmdType == "Drive")
                            {
                                Console.WriteLine(this.bus.Drive(cmdParam));
                            }
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.car.Refuel(cmdParam);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.truck.Refuel(cmdParam);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.bus.Refuel(cmdParam);
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(bus);
        }
    }
}
