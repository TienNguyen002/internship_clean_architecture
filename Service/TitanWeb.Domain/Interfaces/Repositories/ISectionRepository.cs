using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<IList<Section>> GetSectionsAsync();
        Task<Section> GetSectionBySlugAsync(string slug);
        Task<IList<Section>> GetAllSectionBySlugAsync(string slug);
        Task<bool> EditSectionAsync(Section section);
        Task<bool> IsSectionSlugExitedAsync(int id, string slug);
        Task<bool> DeleteSectionAsync(int id);
        Task<int> CountSection();
    }
}
