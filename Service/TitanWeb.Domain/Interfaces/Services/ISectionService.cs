using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.Section;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ISectionService
    {
        Task<IList<SectionDTO>> GetAllSectionAsync(LocaleQuery query);
        Task<SectionDetailDTO> GetSectionByIdAsync(int id);
        Task<SectionDTO> GetSectionBySlugAsync(string slug, LocaleQuery query);
        Task<bool> EditSectionAsync(SectionEditModel model);
        Task<bool> DeleteSectionAsync(int id);
    }
}
