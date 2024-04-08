using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.DTO.Section;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IList<SectionDTO>> GetAllSectionAsync(string language);
        Task<SectionDTO> GetSectionBySlugAsync(string slug);
        Task<IList<SectionDTO>> GetAllSectionBySlugAsync(string slug);
        Task<bool> EditSectionAsync(SectionEditModel model);
        Task<bool> DeleteSectionAsync(int id);
        Task<bool> MoveSection(string sourceSection, string destinationSection);
    }
}
