using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;

namespace TitanWeb.Infrastructure.Repositories
{
    public class ButtonRepository : GenericRepository<Button>, IButtonRepository
    {
        public ButtonRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Change status button
        /// </summary>
        /// <param name="button"> Button want to change status </param>
        /// <returns> Change Status Button </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangeButtonStatus(Button button)
        {
            try
            {
                _context.Update(button);
                return true;
            }
            catch (Exception){
                return false;
            }
        }

        /// <summary>
        /// Get All Sections By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get All Sections </param>
        /// <returns> List Of Sections With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<Button>> GetAllButtonsAsync(string slug)
        {
            return await _context.Set<Button>()
                .Where(s => s.UrlSlug.Contains(slug))
                .ToListAsync();
        }
    }
}
