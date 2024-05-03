using Microsoft.EntityFrameworkCore;
using TitanWeb.Domain.Constants;
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
        /// Get Button By Item Slug
        /// </summary>
        /// <param name="itemSlug"> Slug of Item want to find to change button status </param>
        /// <returns> List Of Button </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Button> GetButtonByItemSlugAsync(string itemSlug)
        {
            return await _context.Set<Button>()
                .Where(b => b.Items.Any(i => i.UrlSlug == itemSlug))
                .FirstOrDefaultAsync();
        }
    }
}
