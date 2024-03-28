using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<IList<Section>> GetSectionsAsync(string language);
        Task<Section> GetSectionBySlugAsync(string slug);
    }
}
