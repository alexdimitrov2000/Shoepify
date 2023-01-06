using Shoepify.Domain;

namespace Shoepify.Services.Contracts
{
    public interface IColorsService
    {
        Task<Color?> CreateAsync(Color color);

        Task<Color?> GetByIdAsync(int id);

        Task<Color?> GetByNameAsync(string name);

        Task<List<Color>> GetAllAsync();
    }
}
