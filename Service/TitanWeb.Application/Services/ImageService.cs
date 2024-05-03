using MapsterMapper;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.DTO.Image;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloundinaryService _cloundinaryService;
        public ImageService(IImageRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ICloundinaryService cloundinaryService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloundinaryService = cloundinaryService;
        }

        /// <summary>
        /// Get All Image In DB
        /// </summary>
        /// <returns> List Of Image </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<ImageDTO>> GetAllImagesAsync()
        {
            var images = await _repository.GetAll();
            return _mapper.Map<IList<ImageDTO>>(images);
        }

        /// <summary>
        /// Get Image By Id
        /// </summary>
        /// <param name="id"> Id of Image Want To Get </param>
        /// <returns> Image By Id want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ImageDTO> GetImageByIdAsync(int id)
        {
            var image = await _repository.GetById(id);
            return _mapper.Map<ImageDTO>(image);
        }

        /// <summary>
        /// Add New Image
        /// </summary>
        /// <param name="model"> Model Of Image To Add </param>
        /// <returns> Added Image </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddImageAsync(ImageEditModel model)
        {
            var image = new Image()
            {
                Hyperlink = model.Hyperlink,
                ImageUrl = await _cloundinaryService.UploadImageAsync(model.ImageFile.OpenReadStream(), model.ImageFile.FileName, QueryManagements.LogoFolder),
                IsLogo = model.IsLogo,
            };
            await _repository.Add(image);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Image By Id
        /// </summary>
        /// <param name="id"> Id of Image Want To Delete </param>
        /// <returns> Deleted Image </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteImageAsync(int id)
        {
            await _repository.DeleteImageByIdAsync(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get All Logo Image
        /// </summary>
        /// <returns> A List Of Logos </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<ImageDTO>> GetAllLogos()
        {
            var images = await _repository.GetAllLogos();
            return _mapper.Map<IList<ImageDTO>>(images);
        }
    }
}
