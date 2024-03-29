using TitanWeb.Domain.DTO.Image;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IImageService
    {
        Task<IList<ImageDTO>> GetAllImagesAsync();
        Task<ImageDTO> GetImageByIdAsync(int id);
        Task<bool> AddImageAsync(ImageEditModel model);
        Task<bool> DeleteImageAsync(int id);
        Task<IList<ImageDTO>> GetAllLogos();
    }
}
