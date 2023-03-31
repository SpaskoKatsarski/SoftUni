namespace Trucks.DataProcessor
{
    using Newtonsoft.Json;

    using Data;
    using Truck.Utilities;
    using DataProcessor.ExportDto;

    public class Serializer
    {
        private static XmlHelper? xmlHelper;

        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            xmlHelper = new XmlHelper();

            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Count >= 1)
                .ToArray()
                .Select(d => new ExportDespatcherDto()
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                    .Select(t => new ExportTruckDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            return xmlHelper.Serialize(despatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var trucks = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                    .Where(ct => ct.Truck.TankCapacity >= capacity)
                    .Select(ct => new
                    {
                        TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                        ct.Truck.VinNumber,
                        ct.Truck.TankCapacity,
                        ct.Truck.CargoCapacity,
                        CategoryType = ct.Truck.CategoryType.ToString(),
                        MakeType = ct.Truck.MakeType.ToString()
                    })
                    .OrderBy(t => t.MakeType)
                    .ThenByDescending(t => t.CargoCapacity)
                    .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            string result = JsonConvert.SerializeObject(trucks, Formatting.Indented);

            return result;
        }
    }
}
