using MapsterMapper;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class SectionService : ISectionService
    {

        private readonly ISectionRepository _repository;
        private readonly IMapper _mapper;
        public SectionService(ISectionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Section By Language
        /// </summary>
        /// <param name="language"> Language want to get Section (en, ja) </param>
        /// <returns> List Of Sections With Language </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<SectionDTO>> GetAllSectionAsync(string language)
        {
            var sections = await _repository.GetSectionsAsync(language);
            return _mapper.Map<IList<SectionDTO>>(sections);
        }

        /// <summary>
        /// Get Section By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Section </param>
        /// <returns> Section With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SectionDTO> GetSectionBySlugAsync(string slug)
        {
            var section = await _repository.GetSectionBySlugAsync(slug);
            return _mapper.Map<SectionDTO>(section);
        }

        /// <summary>
        /// Get All Sections By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get all Sections </param>
        /// <returns> A List Of Sections With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<SectionDTO>> GetAllSectionBySlugAsync(string slug)
        {
            var section = await _repository.GetAllSectionBySlugAsync(slug);
            return _mapper.Map<IList<SectionDTO>>(section);
        }
    }
}