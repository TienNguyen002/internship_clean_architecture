using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.SubItem
{
    public class SubItemEditModel
    {
        [DisplayName(ValidateManagements.SubItemId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.SubItemText)]
        [Required(ErrorMessage = ValidateManagements.SubItemTextRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.SubItemTextMaxLength)]
        public string TextItem { get; set; }

        [DisplayName(ValidateManagements.SubItemImage)]
        public IFormFile? ImageFile { get; set; }

        [DisplayName(ValidateManagements.ItemSlug)]
        [Required(ErrorMessage = ValidateManagements.ItemSlugRequiredMsg)]
        public string ItemSlug { get; set; }
    }
}
