namespace TitanWeb.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
    }
}
