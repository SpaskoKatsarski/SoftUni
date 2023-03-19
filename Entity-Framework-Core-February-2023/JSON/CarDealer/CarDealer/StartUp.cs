namespace CarDealer
{
    using Newtonsoft.Json;
    using AutoMapper;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models;
    using DTOs.Import;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //string input = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // Problem 02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var part in parts)
            {
                if (context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        // Problem 03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var existingPartsId = context.Parts.Select(x => x.Id).ToHashSet();

            var validCars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var car = mapper.Map<Car>(carDto);

                foreach (var part in carDto.PartsId.Distinct())
                {
                    if (existingPartsId.Contains(part))
                    {
                        var currentCarPart = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part
                        };

                        car.PartsCars.Add(currentCarPart);
                    }
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        // Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // Problem 05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // Problem 06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            pc.Part.Name,
                            Price = pc.Part.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .AsNoTracking()
                .ToArray();

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}