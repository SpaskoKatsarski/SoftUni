namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using FastFood.Data;
    using Web.ViewModels.Items;

    public class ItemService : IItemService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public ItemService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreateItemInputModel inputModel)
        {
            Item item = this.mapper.Map<Item>(inputModel);

            await this.context.Items.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemsAllViewModel>> GetAllAsync()
            => await this.context.Items
            .ProjectTo<ItemsAllViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();

        public async Task<IEnumerable<CreateItemViewModel>> GetAllAvailibleCategoriesAsync()
            => await this.context.Categories
            .ProjectTo<CreateItemViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();
    }
}
