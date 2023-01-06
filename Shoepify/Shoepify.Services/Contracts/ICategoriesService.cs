using Shoepify.Domain;

namespace Shoepify.Services.Contracts
{
    public interface ICategoriesService
    {
        Task<Category?> CreateAsync(Category category);

        Task<Category?> GetByIdAsync(int id);

        Task<Category?> GetByNameAsync(string name);

        Task<List<Category>> GetAllAsync();
    }
}
