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
                .Where(s => s.UrlSlug.Contains(slug))
                .ToListAsync();
        }

        /// <summary>
        /// Add Section If Model Has No Id / Update Item If Model Has Id
        /// </summary>
        /// <param name="item"> Model to add/update </param>
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

        /// <summary>
        /// Get Section by UrlSlug With Language
        /// </summary>
        /// <param name="slug"> UrlSlug of Section want to get</param>
        /// <param name="language"> Language of Section want to get (like: en, ja) </param>
        /// <returns> Section Has Slug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Section> GetSectionBySlugWithLanguageAsync(string slug, string language)
        {
            return await _context.Set<Section>()
                .Where(s => s.UrlSlug.Contains(slug) && s.Locale == language)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Change Section Order
        /// </summary>
        /// <param name="currentOrder">Current Section Order</param>
        /// <param name="destinationOrder">Destination Order want to move to </param>
        /// <example>
        ///     A has order 1, B has order 2, C has order 3
        ///     This will have 2 case:
        ///     Case 1: A move to B => B will has order 1, A will has order 2, C no change
        ///     Case 2: C move to A => C will has order 1, A will has order 2 and B will increase 1 so that has order 3
        /// </example>
        /// <returns>Section Order changed</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> MoveSection(int currentOrder, int destinationOrder)
        {
            try
            {
                if (destinationOrder < currentOrder)
                {
                    _context.Sections.Where(s => s.SectionOrder >= destinationOrder && s.SectionOrder < currentOrder)
                        .OrderBy(s => s.SectionOrder)
                        .ToList()
                        .ForEach(s => s.SectionOrder++);
                }
                else if (destinationOrder > currentOrder)
                {
                    _context.Sections.Where(s => s.SectionOrder > currentOrder && s.SectionOrder <= destinationOrder)
                       .OrderByDescending(s => s.SectionOrder)
                       .ToList()
                       .ForEach(s => s.SectionOrder--);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
