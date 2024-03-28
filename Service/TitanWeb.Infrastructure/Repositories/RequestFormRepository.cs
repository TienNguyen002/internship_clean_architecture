using TitanWeb.Domain.Contracts;
using TitanWeb.Domain.DTO.RequestForm;
using TitanWeb.Domain.Entities;
using TitanWeb.Domain.Interfaces.Repositories;
using TitanWeb.Infrastructure.Contexts;
using TitanWeb.Infrastructure.Extensions;

namespace TitanWeb.Infrastructure.Repositories
{
    public class RequestFormRepository : GenericRepository<RequestForm>, IRequestFormRepository
    {
        public RequestFormRepository(TitanWebContext context) : base(context) { }

        /// <summary>
        /// Getting List Of Request Forms With Pagination
        /// </summary>
        /// <param name="query"> Query By User Input To Get Request Form </param>
        /// <param name="pagingParams"> Pagination Filter </param>
        /// <returns> List Of Request Forms Filter By Query With Pagination </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IPagedList<RequestForm>> GetPagedRequestFormAsync(RequestFormQuery query, 
            IPagingParams pagingParams)
        {
            var requestQuery = GetRequestFormByQueryable(query);
            var result = await requestQuery.ToPagedListAsync(pagingParams);
            return result;
        }

        /// <summary>
        /// Find Request Form By Query User Input
        /// </summary>
        /// <param name="query"> Query By User Input To Get Request Form </param>
        /// <returns> Request Form Get By Query </returns>
        /// <exception cref="ArgumentNullException"></exception>
        private IQueryable<RequestForm> GetRequestFormByQueryable(RequestFormQuery query)
        {
            IQueryable<RequestForm> requestQuery = _context.Set<RequestForm>();
            if(!string.IsNullOrWhiteSpace(query.Keyword))
            {
                requestQuery = requestQuery.Where(r => r.Name.Contains(query.Keyword)
                || r.Email.Contains(query.Keyword)
                || r.Phone.Contains(query.Keyword)
                || r.Subject.Contains(query.Keyword));
            }
            return requestQuery;
        }
    }
}
