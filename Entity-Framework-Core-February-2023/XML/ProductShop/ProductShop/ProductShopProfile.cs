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

            // Products
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Buyer, opt => opt.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            // Categories
            this.CreateMap<ImportCategoryDto, Category>();

            // CategoriesProducts
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
