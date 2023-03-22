namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using Utilities;
    using DTOs.Import;
    using DTOs.Export;
    using Microsoft.EntityFrameworkCore;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string input = File.ReadAllText("../../../Datasets/categories-products.xml");

            Console.WriteLine(GetSoldProducts(context));
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

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                if (String.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        // Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryProductDto[] categoryProductDtos = xmlHelper
                .Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts")
                .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId) &&
                            context.Products.Any(p => p.Id == cp.ProductId))
                .ToArray();

            ICollection<CategoryProduct> validCategoriesProducts = new HashSet<CategoryProduct>();

            foreach (var cpDto in categoryProductDtos)
            {
                CategoryProduct cp = mapper.Map<CategoryProduct>(cpDto);
                validCategoriesProducts.Add(cp);
            }

            context.CategoryProducts.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
        }

        // Problem 05 ?
        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Take(10)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            string productsAsXml = xmlHelper.Serialize<ExportProductDto[]>(products, "Products");

            return productsAsXml;
        }

        // Problem 06 ?
        public static string GetSoldProducts(ProductShopContext context)
        {
            var mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportUserDto[]>(users, "Users");
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