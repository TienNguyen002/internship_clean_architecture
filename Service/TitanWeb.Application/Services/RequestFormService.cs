using MapsterMapper;
using TitanWeb.Domain.Collections;
using TitanWeb.Domain.DTO;
using TitanWeb.Domain.DTO.RequestForm;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Domain.Interfaces.Services;

namespace TitanWeb.Application.Services
{
    public class RequestFormService : IRequestFormService
    {
        private readonly IRequestFormRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestFormService(IRequestFormRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Getting List Of Request Forms With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Request Form </param>
        /// <param name="pagingModel"> Model Pagination Filter </param>
        /// <returns> List Of Request Forms Filter By Query With Pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PaginationResult<RequestFormDTO>> GetPagedRequestFormAsync(RequestFormQuery query,
            PagingModel pagingModel)
        {
            var result = await _repository.GetPagedRequestFormAsync(query, pagingModel);
            var RequestForms = _mapper.Map<List<RequestForm>, List<RequestFormDTO>>(result.ToList());
            var paginationResult = new PaginationResult<RequestFormDTO>(new PagedList<RequestFormDTO>(RequestForms, result.PageNumber, result.PageSize, result.TotalItemCount));
            return paginationResult;
        }

        /// <summary>
        /// Create New Request Forms
        /// </summary>
        /// <param name="model"> Model to create </param>
        /// <returns> Create Request Form </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> CreateRequestFormAsync(RequestFormEditModel model)
        {
            var requestForm = new RequestForm
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Subject = model.Subject,
                Message = model.Message,
                CreatedDate = DateTime.Now,
            };
            await _repository.Add(requestForm);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Request Form By Id
        /// </summary>
        /// <param name="id"> Id Of Request Form want to delete </param>
        /// <returns> Deleted Request Form </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteRequestFormAsync(int id)
        {
            await _repository.DeleteRequestFormAsync(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
