using TitanWeb.Application.DTO.Section;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IList<SectionDTO>> GetAllSectionAsync(string language);
        Task<SectionDTO> GetSectionBySlugAsync(string slug);
    }
}
