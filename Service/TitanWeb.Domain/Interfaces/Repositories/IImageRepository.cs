using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<bool> DeleteImageByIdAsync(int id);
        Task<IList<Image>> GetAllLogos();
        Task<Image> GetByItemIdAsync(int itemId);
    }
}
