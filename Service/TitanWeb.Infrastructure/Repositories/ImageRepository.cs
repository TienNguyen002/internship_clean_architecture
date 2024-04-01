using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Delete Image By Id
        /// </summary>
        /// <param name="id"> Id of Image Want To Delete </param>
        /// <returns> Deleted Image </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteImageByIdAsync(int id)
        {
            var imageToDelete = await _context.Set<Image>()
                .Include(i => i.Items)
                .Include(i => i.Sections)
                .Include(i => i.SubItems)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(imageToDelete);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get All Logo Image
        /// </summary>
        /// <returns> A List Of Logos </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Image>> GetAllLogos()
        {
            return await _context.Set<Image>()
                .Where(i => i.IsLogo)
                .ToListAsync();
        }
    }
}
