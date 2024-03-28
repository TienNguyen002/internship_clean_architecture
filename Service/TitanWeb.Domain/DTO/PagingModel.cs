using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;
using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.DTO
{
    public class PagingModel : IPagingParams
    {
        [DisplayName(ValidateManagements.PageSize)]
        [Required(ErrorMessage = ValidateManagements.PageSizeEmptyMsg)]
        public int PageSize { get; set; }

        [DisplayName(ValidateManagements.PageNumber)]
        [Required(ErrorMessage = ValidateManagements.PageNumberEmptyMsg)]
        public int PageNumber { get; set; }
        //public string? SortColumn { get; set; }
        //public string? SortOrder { get; set; }
    }
}
