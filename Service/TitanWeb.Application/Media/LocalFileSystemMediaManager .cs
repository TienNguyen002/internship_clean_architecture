﻿using Microsoft.Extensions.Logging;

namespace TitanWeb.Api.Media
{
    public class LocalFileSystemMediaManager : IMediaManager
    {
        private const string ImagesFolder = "images/{0}{1}";
        private readonly ILogger<LocalFileSystemMediaManager> _logger;
        public LocalFileSystemMediaManager(ILogger<LocalFileSystemMediaManager> logger)
        {
            _logger = logger;
        }

        public async Task<string> SaveImgFileAsync(Stream buffer, string originalFileName, string contentType, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!buffer.CanRead || !buffer.CanSeek || buffer.Length == 0)
                    return null;
                var fileExt = Path.GetExtension(originalFileName).ToLower();
                var returnedFilePath = CreateImgFilePath(fileExt, contentType.ToLower());
                var fullPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", returnedFilePath));
                buffer.Position = 0;
                await using var fileStream = new FileStream(fullPath, FileMode.Create);
                await buffer.CopyToAsync(fileStream, cancellationToken);
                return returnedFilePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Cannot add file '{originalFileName}'.");
                return null;
            }
        }

        public Task<bool> DeleteFileAsync(string filePath, CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    Task.FromResult(true);
                var fullPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", filePath));
                File.Delete(fullPath);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Cannot delete file '{filePath}'.");
                return Task.FromResult(false);
            }
        }

        private string CreateImgFilePath(string fileExt, string contentType = "")
        {
            return string.Format(ImagesFolder, Guid.NewGuid().ToString("N"), fileExt);
        }
    }
}
