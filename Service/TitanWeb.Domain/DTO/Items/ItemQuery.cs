using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class ItemQuery
    {
        [DisplayName(ValidateManagements.SectionSlug)]
        public string SectionSlug { get; set; }
    }
}
