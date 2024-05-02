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
                .Include(s => s.Image)
                .Where(s => s.Locale == language);
            return await sections
                .OrderBy(s => s.SectionOrder)
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
                .Where(s => s.UrlSlug.Contains(slug))
                .ToListAsync();
        }

        /// <summary>
        /// Add Section If Model Has No Id / Update Item If Model Has Id
        /// </summary>
        /// <param name="section"> Model to add/update </param>
        /// <returns> Added/Updated Section </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditSectionAsync(Section section)
        {
            try
            {
                if (section.Id > 0)
                {
                    _context.Update(section);
                }
                else
                {
                    _context.Add(section);
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
        /// <param name="id"> Id Of Section want to find </param>
        /// <param name="slug"> Slug Of Section want to check </param>
        /// <returns> Section Slug Existed (true, false) </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> IsSectionSlugExitedAsync(int id, string slug)
        {
            return await _context.Set<Section>()
                .AnyAsync(t => t.Id != id && t.UrlSlug == slug);
        }

        /// <summary>
        /// Delete Section By Id
        /// </summary>
        /// <param name="id"> Id Of Section want to delete </param>
        /// <returns> Deleted Section </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteSectionAsync(int id)
        {
            var sectionToDelete = await _context.Set<Section>()
                .Include(i => i.Image)
                .Include(i => i.Items)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(sectionToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Count all Section in DB with language (en, ja)
        /// </summary>
        /// <param name="language">Language Section want to count</param>
        /// <returns>Number of section with language in DB</returns>
        /// <exception cref="Exception"></exception>
        public Task<int> CountSectionByLanguage(string language)
        {
            return _context.Set<Section>().Where(c => c.Locale == language).CountAsync();
        }
    }
}
