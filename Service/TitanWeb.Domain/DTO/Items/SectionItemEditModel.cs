using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class SectionItemEditModel
    {
        [DisplayName(ValidateManagements.SectionItemId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.SectionItemTitle)]
        [Required(ErrorMessage = ValidateManagements.SectionItemTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.SectionItemTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.SectionItemSubTitle)]
        public string SubTitle { get; set; }

        [DisplayName(ValidateManagements.SectionItemSlug)]
        [Required(ErrorMessage = ValidateManagements.SectionItemSlugRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.SectionItemSlugMaxLength)]
        public string UrlSlug { get; set; }

        [DisplayName(ValidateManagements.SectionItemDescription)]
        [Required(ErrorMessage = ValidateManagements.SectionItemDescriptionRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.SectionItemDescriptionMaxLength)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.SectionItemImage)]
        public IFormFile ImageFile { get; set; }

        [DisplayName(ValidateManagements.ButtonLabel)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ButtonLabelMaxLength)]
        public string ButtonLabel { get; set; }

        [DisplayName(ValidateManagements.SectionSlug)]
        [Required(ErrorMessage = ValidateManagements.SectionSlugRequiredMsg)]
        public string SectionSlug { get; set; }

        [DisplayName(ValidateManagements.Locale)]
        [Required(ErrorMessage = ValidateManagements.LocaleRequiredMsg)]
        public string Locale { get; set; }
    }
}
