using Homies.ViewModels.Type;

namespace Homies.Services.Contracts
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeOptionViewModel>> AllAsync();
    }
}
