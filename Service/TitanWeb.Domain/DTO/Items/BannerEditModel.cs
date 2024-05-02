using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class BannerEditModel
    {
        [DisplayName(ValidateManagements.BannerId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.BannerBoldTitle)]
        public string BoldTitle { get; set; }

        [DisplayName(ValidateManagements.BannerTitle)]
        [Required(ErrorMessage = ValidateManagements.BannerTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BannerTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.BannerSlug)]
        [Required(ErrorMessage = ValidateManagements.BannerSlugRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BannerSlugMaxLength)]
        public string UrlSlug { get; set; }

        [DisplayName(ValidateManagements.BannerDescription)]
        [Required(ErrorMessage = ValidateManagements.BannerDescriptionRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.BannerDescriptionMaxLength)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.BannerBackgroundImage)]
        public IFormFile? BackgroundImage { get; set; }

        [DisplayName(ValidateManagements.Locale)]
        [Required(ErrorMessage = ValidateManagements.LocaleRequiredMsg)]
        public string Locale { get; set; }
    }
}
