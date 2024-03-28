﻿using Microsoft.AspNetCore.Http;

namespace TitanWeb.Api.Media
{
    public interface IMediaManager
    {
        Task<string> SaveImgFileAsync(
            Stream buffer,
            string originalFileName,
            string contentType,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteFileAsync(
            string filePath,
            CancellationToken cancellationToken = default);
    }
}
