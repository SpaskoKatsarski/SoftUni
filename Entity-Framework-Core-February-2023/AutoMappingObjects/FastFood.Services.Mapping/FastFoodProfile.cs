namespace FastFood.Services.Mapping
{
    using AutoMapper;
    
    using Models;
    using Web.ViewModels.Positions;
    using Web.ViewModels.Categories;
    using Web.ViewModels.Items;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            // Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name));

            // Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            // Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
