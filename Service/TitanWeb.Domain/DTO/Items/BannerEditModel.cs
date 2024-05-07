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
        public string? BoldTitle { get; set; }

        [DisplayName(ValidateManagements.BannerJapaneseBoldTitle)]
        public string? JapaneseBoldTitle { get; set; }

        [DisplayName(ValidateManagements.BannerTitle)]
        [Required(ErrorMessage = ValidateManagements.BannerTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BannerTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.BannerJapaneseTitle)]
        [Required(ErrorMessage = ValidateManagements.BannerJapaneseTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BannerJapaneseTitleMaxLength)]
        public string JapaneseTitle { get; set; }

        [DisplayName(ValidateManagements.BannerDescription)]
        [Required(ErrorMessage = ValidateManagements.BannerDescriptionRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.BannerDescriptionMaxLength)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.BannerJapaneseDescription)]
        [Required(ErrorMessage = ValidateManagements.BannerJapaneseDescriptionRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.BannerJapaneseDescriptionMaxLength)]
        public string JapaneseDescription { get; set; }

        [DisplayName(ValidateManagements.BannerBackgroundImage)]
        public IFormFile? BackgroundImage { get; set; }
    }
}
