namespace TitanWeb.Domain.Interfaces.Services
{
    public interface ISubItemService
    {
        Task<bool> DeleteSubItemAsync(int id);
    }
}
