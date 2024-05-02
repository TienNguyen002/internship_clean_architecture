using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.DTO.RequestForm;
using TitanWeb.Domain.Entities;

namespace TitanWeb.Domain.Interfaces.Repositories
{
    public interface IRequestFormRepository : IGenericRepository<RequestForm>
    {
        Task<IPagedList<RequestForm>> GetPagedRequestFormAsync(RequestFormQuery query,
            IPagingParams pagingParams);

        Task<bool> DeleteRequestFormAsync(int id);
    }
}
