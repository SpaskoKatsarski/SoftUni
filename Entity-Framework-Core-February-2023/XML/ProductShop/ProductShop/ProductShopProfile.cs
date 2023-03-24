namespace ProductShop
{
    using AutoMapper;

    using Models;
    using DTOs.Import;
    using DTOs.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Users
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportUserDto>()
                .ForMember(d => d.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold));
            this.CreateMap<User, ExportUserWithProductsDto>()
                .ForMember(d => d.SoldProducts, opt => opt.MapFrom(s => s.ProductsSold));

            // Products
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Price, opt => opt.MapFrom(s => (double)s.Price))
                .ForMember(d => d.Buyer, opt => opt.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            // Categories
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<Category, ExportCategoryByProductsCountDto>()
                .ForMember(d => d.Count, opt => opt.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, opt => opt.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(d => d.TotalRevenue, opt => opt.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));

            // CategoriesProducts
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
