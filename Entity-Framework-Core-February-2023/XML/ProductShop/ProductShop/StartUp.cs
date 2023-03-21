namespace ProductShop
{
    using System.Xml.Serialization;

    using Data;
    using Utilities;
    using DTOs.Import;
    using ProductShop.Models;
    using AutoMapper;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string input = File.ReadAllText("../../../Datasets/products.xml");

            Console.WriteLine(ImportProducts(context, input));
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var productDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in productDtos)
            {
                Product product = mapper.Map<Product>(productDto);
                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}