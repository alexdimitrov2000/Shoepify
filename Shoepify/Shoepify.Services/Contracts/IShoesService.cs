using Shoepify.Domain;

namespace Shoepify.Services.Contracts
{
    public interface IShoesService
    {
        Task<Shoe?> CreateAsync(Shoe shoe);

        Task<Shoe?> GetByIdAsync(int id);

        Task<List<Shoe>> GetAllAsync();

        Task<Shoe?> AddSizesAsync(Shoe shoe, List<Size?> sizesToAdd);

        Task<Shoe?> AddColorsAsync(Shoe shoe, List<Color?> colorToAdd);
    }
}
