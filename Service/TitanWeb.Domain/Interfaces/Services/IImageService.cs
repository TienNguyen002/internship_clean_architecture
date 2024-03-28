using TitanWeb.Domain.DTO.Image;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IImageService
    {
        Task<IList<ImageData>> GetAllImagesAsync();
        Task<ImageDTO> GetImageByIdAsync(int id);
        Task<bool> AddImageAsync(ImageEditModel model);
        Task<bool> DeleteImageAsync(int id);
    }
}
