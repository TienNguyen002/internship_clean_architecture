using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Get Section By Language
        /// </summary>
        /// <param name="language"> Language want to get Section (en, ja) </param>
        /// <returns> List Of Sections With Language </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Section>> GetSectionsAsync(string language)
        {
            IQueryable<Section> sections = _context.Set<Section>()
                .Include(s => s.Items)
                    .ThenInclude(i => i.Image)
                .Include(s => s.Items)
                    .ThenInclude(i => i.Button)
                .Include(s => s.Items)
                    .ThenInclude(i => i.SubItems)
                        .ThenInclude(s => s.Image)
                .Include(s => s.Image)
                .Where(s => s.Locale == language);
            return await sections
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Get Section By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Section </param>
        /// <returns> Section With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Section> GetSectionBySlugAsync(string slug)
        {
            return await _context.Set<Section>()
                .Include(s => s.Items)
                    .ThenInclude(i => i.Image)
                .Include(s => s.Items)
                    .ThenInclude(i => i.Button)
                .Include(s => s.Items)
                    .ThenInclude(i => i.SubItems)
                        .ThenInclude(s => s.Image)
                .Include(s => s.Image)
                .Where(s => s.UrlSlug.Contains(slug))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get All Sections By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get All Sections </param>
        /// <returns> List Of Sections With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Section>> GetAllSectionBySlugAsync(string slug)
        {
            return await _context.Set<Section>()
                .Include(s => s.Items)
                    .ThenInclude(i => i.Image)
                .Include(s => s.Items)
                    .ThenInclude(i => i.Button)
                .Include(s => s.Items)
                    .ThenInclude(i => i.SubItems)
                        .ThenInclude(s => s.Image)
                .Include(s => s.Image)
                .Where(s => s.UrlSlug.Contains(slug))
                .ToListAsync();
        }
    }
}
