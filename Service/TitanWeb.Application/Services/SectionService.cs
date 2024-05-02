using MapsterMapper;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class SectionService : ISectionService
    {

        private readonly ISectionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloundinaryService _cloundinaryService;
        public SectionService(ISectionRepository repository, IMapper mapper, IUnitOfWork unitOfWork, ICloundinaryService cloundinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cloundinaryService = cloundinaryService;
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

        /// <summary>
        /// Add/Update By Find Section Id, If Id > 0 Update it by Model, else Create New News By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Section </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditSectionAsync(SectionEditModel model)
        {
            var section = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (section == null)
            {
                section = new Section { };
            }
            if (model.Id == 0)
            {
                var sectionCount = await _repository.CountSectionByLanguage(model.Locale);
                if (sectionCount > 0)
                {
                    section.SectionOrder = sectionCount + 1;
                }
            }

            section.Name = model.Name;
            section.Title = model.Title;
            section.UrlSlug = model.UrlSlug;
            if (await _repository.IsSectionSlugExitedAsync(model.Id, model.UrlSlug))
            {
                int save = await _unitOfWork.Commit();
                return save < 0;
            }
            section.Description = model.Description;
            if (model.BackgroundImage != null)
            {
                section.Image = new Image
                {
                    ImageUrl = await _cloundinaryService.UploadImageAsync(model.BackgroundImage.OpenReadStream(), model.BackgroundImage.FileName, QueryManagements.ImageFolder),
                };
            }
            section.Locale = model.Locale;
            await _repository.EditSectionAsync(section);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Section By Id
        /// </summary>
        /// <param name="id"> Id Of Section want to delete </param>
        /// <returns> Deleted Section </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteSectionAsync(int id)
        {
            await _repository.DeleteSectionAsync(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get Section By Id
        /// </summary>
        /// <param name="id"> Id Of Section want to get </param>
        /// <returns> Get Section By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SectionDTO> GetSectionByIdAsync(int id)
        {
            var section = await _repository.GetByIdWithInclude(id, i => i.Image);
            return _mapper.Map<SectionDTO>(section);
        }
    }
}