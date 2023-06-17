using Homies.Data;
using Homies.ViewModels.Type;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class TypeService : ITypeService
    {
        private readonly HomiesDbContext context;

        public TypeService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TypeOptionViewModel>> AllAsync()
        {
            var types = await this.context.Types
                .Select(t => new TypeOptionViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return types;
        }
    }
}
