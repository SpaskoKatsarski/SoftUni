namespace ProductShop
{
    using AutoMapper;

    using Models;
    using DTOs.Import;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Users
            this.CreateMap<ImportUserDto, User>();

            // Products
            this.CreateMap<ImportProductDto, Product>();
        }
    }
}
