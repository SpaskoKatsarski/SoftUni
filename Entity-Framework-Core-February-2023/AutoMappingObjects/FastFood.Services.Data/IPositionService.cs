namespace FastFood.Services.Data
{
    using Web.ViewModels.Positions;

    public interface IPositionService
    {
        Task CreateAsync(CreatePositionInputModel inputModel);

        Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
    }
}
