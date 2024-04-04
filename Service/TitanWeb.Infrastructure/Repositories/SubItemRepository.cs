using Microsoft.EntityFrameworkCore;
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
                .Include(i => i.Items)
                .Include(i => i.Image)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(subItemToDelete);
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
        /// <param name="item"> Model to add/update </param>
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
    }
}
