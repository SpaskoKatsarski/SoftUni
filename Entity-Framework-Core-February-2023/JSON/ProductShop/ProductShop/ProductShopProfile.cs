namespace ProductShop
{
    using AutoMapper;

    using Models;
    using DTOs.Import;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            this.CreateMap<ImportUserDto, User>();

            // Product
            this.CreateMap<ImportProductDto, Product>();

            // Category
            this.CreateMap<ImportCategoryDto, Category>();

            // CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
