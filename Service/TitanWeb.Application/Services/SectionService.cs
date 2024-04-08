using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TitanWeb.Api.Media;
using TitanWeb.Application.DTO.Section;
using TitanWeb.Domain.DTO.Section;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Application.Services
{
    public class SectionService : ISectionService
    {

        private readonly ISectionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaManager _mediaManager;
        private readonly TitanWebContext _context;
        public SectionService(ISectionRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IMediaManager mediaManager, TitanWebContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediaManager = mediaManager;
            _context = context;
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
                section = new Section {  };
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
                    ImageUrl = await _mediaManager.SaveImgFileAsync(model.BackgroundImage.OpenReadStream(),
                                                                     model.BackgroundImage.FileName,
                                                                     model.BackgroundImage.ContentType),
                };
            }
            section.Locale = model.Locale;
            var sectionCount = await _repository.CountSectionByLanguage(model.Locale);
            if (sectionCount > 0)
            {
                section.SectionOrder = sectionCount + 1;
            }
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
        /// Move Section 
        /// </summary>
        /// <param name="sourceSection">Current Section</param>
        /// <param name="destinationSection">Destination Section want to move to </param>
        /// <example>
        ///     A has order 1, B has order 2, C has order 3
        ///     This will have 2 case:
        ///     Case 1: A move to B => B will has order 1, A will has order 2, C no change
        ///     Case 2: C move to A => C will has order 1, A will has order 2 andconf remo B will increase 1 so that has order 3
        /// </example>
        /// <returns>Section Order changed</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> MoveSection(string sourceSection, string destinationSection)
        {
            var sourceSections = await _repository.GetAllSectionBySlugAsync(sourceSection);
            var destinationSections = await _repository.GetAllSectionBySlugAsync(destinationSection);

            var currentOrder = sourceSections.Min(s => s.SectionOrder);
            var destinationOrder = destinationSections.Min(s => s.SectionOrder);
            foreach (var section in sourceSections)
            {
                section.SectionOrder = destinationOrder;
            }
            await _repository.MoveSection(currentOrder, destinationOrder);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}