namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IButtonService
    {
        Task<bool> ChangeButtonStatus(string itemSlug);
    }
}
