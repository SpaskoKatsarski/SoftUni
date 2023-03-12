namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using FastFood.Data;
    using Models;
    using Web.ViewModels.Positions;

    public class PositionService : IPositionService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public PositionService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task CreateAsync(CreatePositionInputModel inputModel)
        {
            Position position = this.mapper.Map<Position>(inputModel);

            await context.Positions.AddAsync(position);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionsAllViewModel>> GetAllAsync()
            => await this.context.Positions
            .ProjectTo<PositionsAllViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();
    }
}