using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Constants;
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
        /// Retrieves an IQueryable of Item based on the provided ItemQuery.
        /// </summary>
        /// <param name="query"> ItemQuery used to filter the result</param>
        /// <returns>An IQueryable of Item.</returns>
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
        /// Get a paged list of Items based on the provided query and paging parameters
        /// </summary>
        /// <param name="query"> Query to filter the Item (by Section Slug). </param>
        /// <param name="pagingParams"> Pagination Parameters. </param>
        /// <returns>A paged list Of Items filtered By Query.</returns>
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
        /// <param name="slug"> UrlSlug of the Item. </param>
        /// <returns> Item with matching UrlSlug </returns>
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
        /// Get All Item By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get All Item </param>
        /// <returns> A List Item With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Item>> GetAllItemBySlugAsync(string slug)
        {
            return await _context.Set<Item>()
                .Where(s => s.UrlSlug.Contains(slug))
                .ToListAsync();
        }

        /// <summary>
        /// Get a List of Items based on category slug and language
        /// </summary>
        /// <param name="categorySlug"> UrlSlug of the Category. </param>
        /// <param name="language"> Language of the category (en, ja) </param>
        /// <returns> A list of items filtered by category slug and language. </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Item>> GetItemByCategorySlugAsync(string categorySlug, string language)
        {
            return await _context.Set<Item>()
                .Include(i => i.Categories)
                .Include(i => i.Image)
                .Include(i => i.SubItems)
                .Include(i => i.Button)
                .Where(s => s.Categories.Any(c => c.UrlSlug.Contains(categorySlug) && c.Locale == language))
                .ToListAsync();
        }

        /// <summary>
        /// Get All Items By Section Slug
        /// </summary>
        /// <param name="sectionSlug"> Slug of Section want to get Items </param>
        /// <param name="urlSlug"> Url Slug of Item not take </param>
        /// <returns> A List Of Item By Section Slug except item with url slug</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Item>> GetAllItemsBySectionSlugAsync(string sectionSlug, string urlSlug)
        {
            return await _context.Set<Item>()
                .Include(i => i.Sections)
                .Include(i => i.Image)
                .Where(i => i.Sections.Any(c => c.UrlSlug.Contains(sectionSlug) && i.UrlSlug != urlSlug))
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
                if (item.Id > 0)
                {
                    _context.Update(item);
                }
                else
                {
                    _context.Add(item);
                }
                return true;
            }
            catch (Exception)
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
            var itemToDelete = await _context.Set<Item>()
                .Include(i => i.Button)
                .Include(i => i.Image)
                .Include(i => i.SubItems)
                .Include(i => i.Categories)
                .Include(i => i.Sections)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(itemToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Change Image For Item
        /// </summary>
        /// <param name="imageId"> Id Of Image want to change for Item </param>
        /// <returns> Image Item Changed </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangeLogoImage(int imageId)
        {
            var image = await _context.Set<Image>()
                .Where(i => i.Id == imageId).FirstOrDefaultAsync();
            var itemsToUpdate = await _context.Set<Item>()
                .Include(i => i.Image)
                .Where(i => i.UrlSlug.Contains(QueryManagements.NavbarSlug))
                .ToListAsync();
            try
            {
                foreach (var item in itemsToUpdate)
                {
                    item.Image = image;
                    _context.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// This method checks if a slug already exists in the database
        /// </summary>
        /// <param name="id"> Id Of Item want to find </param>
        /// <param name="slug"> Slug Of Item want to check </param>
        /// <returns> Image Item Changed </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> IsItemSlugExitedAsync(int id, string slug)
        {
            return await _context.Set<Item>()
                .AnyAsync(t => t.Id != id && t.UrlSlug == slug);
        }
    }
}
