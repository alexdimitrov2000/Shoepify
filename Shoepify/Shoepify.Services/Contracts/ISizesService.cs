using Shoepify.Domain;

namespace Shoepify.Services.Contracts
{
    public interface ISizesService
    {
        Task<Size?> CreateAsync(Size size);

        Task<Size?> GetByIdAsync(int id);
    }
}
