using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class SubItemRepository : GenericRepository<SubItem>, ISubItemRepository
    {
        public SubItemRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Delete Sub Item By Id
        /// </summary>
        /// <param name="id"> Id Of Sub Item want to delete </param>
        /// <returns> Deleted Sub Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteSubItemAsync(int id)
        {
            var subItemToDelete = await _context.Set<SubItem>()
                .Include(i => i.Item)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(subItemToDelete);
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is SubItem)
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
        /// Add Sub Item If Model Has No Id / Update Sub Item If Model Has Id
        /// </summary>
        /// <param name="subItem"> Model to add/update </param>
        /// <returns> Added/Updated Sub Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditSubItemAsync(SubItem subItem)
        {
            try
            {
                if (subItem.Id > 0)
                {
                    _context.Update(subItem);
                }
                else
                {
                    _context.Add(subItem);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Find Sub-Item By Item Id
        /// </summary>
        /// <param name="itemId"> Id Of Item want to find </param>
        /// <returns> Sub Item By Item Id </returns>
        /// <exception cref="Exception"></exception>
        public async Task<SubItem> GetByItemIdAsync(int itemId)
        {
            return await _context.Set<SubItem>()
                .Include(s => s.Item)
                .Where(s => s.Item.Id == itemId)
                .FirstOrDefaultAsync();
        }
    }
}
