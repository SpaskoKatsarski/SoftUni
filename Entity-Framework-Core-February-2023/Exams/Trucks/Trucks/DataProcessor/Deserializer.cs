namespace Trucks.DataProcessor
{
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Truck.Utilities;
    using Data.Models;
    using DataProcessor.ImportDto;
    using Trucks.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private static XmlHelper? xmlHelper;

        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            xmlHelper = new XmlHelper();
            ImportDespatcherDto[] despatcherDtos = xmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };

                    despatcher.Trucks.Add(truck);
                }

                validDespatchers.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            ICollection<Client> validClients = new HashSet<Client>();

            List<int> validTruckIds = context.Trucks
                .Select(t => t.Id)
                .ToList();

            foreach (var clientDto in clientDtos)
            {
                //Distinct truck ids
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.TruckIds.Distinct())
                {
                    if (!validTruckIds.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = context.Trucks
                        .Find(truckId);

                    client.ClientsTrucks.Add(new ClientTruck() { Client = client, Truck = truck });
                }

                validClients.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
            context.SaveChangesAsync();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}