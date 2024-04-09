using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using TitanWeb.Application.Media;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class CloudinaryService : ICloundinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudConfiguration> config)
        {
            _cloudinary = new Cloudinary(new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret));
        }

        public async Task<string> UploadImageAsync(Stream imageStream, string fileName)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, imageStream),
                Transformation = new Transformation().Width(200).Height(200).Crop("fill")
            };
            uploadParams.Folder = QueryManagements.ImageFolder;
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.Url.ToString();
        }
    }
}
