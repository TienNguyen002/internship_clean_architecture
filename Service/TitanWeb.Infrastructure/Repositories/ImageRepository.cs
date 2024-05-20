using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Constants;
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
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(imageToDelete);
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Button)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            proposedValues[property] = proposedValue ?? databaseValue;
                        }

                        entry.OriginalValues.SetValues(databaseValues);
                    }
                    else
                    {
                        throw new NotSupportedException(
                            ResponseManagements.ConcurrencyConflicts
                            + entry.Metadata.Name);
                    }
                }
                return true;
            }
            catch (Exception)
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

        /// <summary>
        /// Get Image By Item Id
        /// </summary>
        /// <param name="itemId"> Id Of Item want to find </param>
        /// <returns> Image By Item Id </returns>
        /// <exception cref="Exception"></exception>
        public async Task<Image> GetByItemIdAsync(int itemId)
        {
            return await _context.Set<Image>()
                .Include(s => s.Items)
                .Where(s => s.Items.Any(i => i.Id == itemId))
                .FirstOrDefaultAsync();
        }
    }
}
