using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Get Category by UrlSlug
        /// </summary>
        /// <param name="slug"> UrlSlug of Category want to get </param>
        /// <param name="language"> Language of Category want to get (like: en, ja) </param>
        /// <returns> Category Has Slug want to get with language </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Category> GetCategoryBySlugAsync(string slug, string language)
        {
            return await _context.Set<Category>()
                .Include(c => c.Items)
                    .ThenInclude(i => i.Button)
                .Include(c => c.Items)
                    .ThenInclude(i => i.Image)
                .Include(c => c.Items)
                    .ThenInclude(i => i.SubItems)
                .Where(c => c.UrlSlug.Contains(slug) && c.Locale == language)
                .FirstOrDefaultAsync();
        }
    }
}
