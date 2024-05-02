using System.ComponentModel;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.RequestForm
{
    public class RequestFormQuery
    {
        [DisplayName(ValidateManagements.Keyword)]
        public string? Keyword { get; set; } = null;
    }
}
