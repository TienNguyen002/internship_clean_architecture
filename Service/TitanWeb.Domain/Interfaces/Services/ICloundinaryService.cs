using Microsoft.AspNetCore.Http;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ICloundinaryService
    {
        Task<string> UploadImageAsync(Stream imageStream, string fileName);
    }
}
