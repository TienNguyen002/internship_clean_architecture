using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.DTO.Items;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;
using TitanWeb.Infrastructure.Extensions;

namespace TitanWeb.Infrastructure.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Find Item By Query User Input
        /// </summary>
        /// <param name="query"> Query By User Input To Get Item (Section Slug) </param>
        /// <returns> Item Get By Query </returns>
        /// <exception cref="ArgumentNullException"></exception>
        private IQueryable<Item> GetItemByQueryable(ItemQuery query)
        {
            IQueryable<Item> itemQuery = _context.Set<Item>()
                .Include(i => i.Sections)
                .Include(i => i.Categories)
                .Include(i => i.Image)
                .Include(i => i.SubItems)
                .Include(i => i.Button);
            if (!string.IsNullOrWhiteSpace(query.SectionSlug))
            {
                itemQuery = itemQuery.Where(i => i.Sections.Any(s => s.UrlSlug.Contains(query.SectionSlug)));
            }
            return itemQuery;
        }

        /// <summary>
        /// Getting List Of Item With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Item (Section Slug) </param>
        /// <param name="pagingParams"> Pagination Filter </param>
        /// <returns> List Of Item Filter By Query With Pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IPagedList<Item>> GetPagedItemAsync(ItemQuery query,
            IPagingParams pagingParams)
        {
            var itemQuery = GetItemByQueryable(query);
            var result = await itemQuery.ToPagedListAsync(pagingParams);
            return result;
        }

        /// <summary>
        /// Get Item By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Item </param>
        /// <returns> Item With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Item> GetItemBySlugAsync(string slug)
        {
            return await _context.Set<Item>()
                .Include(i => i.Sections)
                .Include(i => i.Categories)
                .Include(i => i.Image)
                .Include(i => i.SubItems)
                .Include(i => i.Button)
                .Where(s => s.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get Item By Category Slug
        /// </summary>
        /// <param name="categorySlug"> Slug of Category want to get Items </param>
        /// <param name="language"> Language of category want to get (en, ja) </param>
        /// <returns> A List Of Item By Category Slug filter language </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Item>> GetItemByCategorySlugAsync(string categorySlug, string language)
        {
            return await _context.Set<Item>()
                .Include(i => i.Categories)
                .Include(i => i.Image)
                .Include(i => i.SubItems)
                    .ThenInclude(i => i.Image)
                .Include(i => i.Button)
                .Where(s => s.Categories.Any(c => c.UrlSlug.Contains(categorySlug) && c.Locale == language))
                .ToListAsync();
        }

        /// <summary>
        /// Add Item If Model Has No Id / Update Item If Model Has Id
        /// </summary>
        /// <param name="item"> Model to add/update </param>
        /// <returns> Added/Updated Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditItemAsync(Item item)
        {
            try
            {
                if (item.ItemId > 0)
                {
                    _context.Update(item);
                }
                else
                {
                    _context.Add(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Item By Id
        /// </summary>
        /// <param name="id"> Id Of Item want to delete </param>
        /// <returns> Deleted Item </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteItemAsync(int id)
        {
            var itemToDelete = _context.Set<Item>()
                .Include(i => i.Button)
                .Include(i => i.Image)
                .Include(i => i.SubItems)
                .Include(i => i.Categories)
                .Include(i => i.Sections)
                .Where(i => i.ItemId == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(itemToDelete);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
