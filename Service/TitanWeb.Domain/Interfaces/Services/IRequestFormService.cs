using TitanWeb.Domain.Collections;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.RequestForm;

namespace TitanWeb.Domain.Interfaces.Services
{
    public interface IRequestFormService
    {
        Task<PaginationResult<RequestFormDTO>> GetPagedRequestFormAsync(RequestFormQuery query, PagingModel pagingModel);

        Task<bool> CreateRequestFormAsync(RequestFormEditModel model);
    }
}
