using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Section
{
    public class SectionEditModel
    {
        [DisplayName(ValidateManagements.SectionId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.SectionName)]
        [Required(ErrorMessage = ValidateManagements.SectionNameRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.SectionNameMaxLength)]
        public string Name { get; set; }

        [DisplayName(ValidateManagements.SectionTitle)]
        [Required(ErrorMessage = ValidateManagements.SectionTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.SectionTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.SectionJapaneseTitle)]
        [Required(ErrorMessage = ValidateManagements.SectionJapaneseTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.SectionJapaneseTitleMaxLength)]
        public string JapaneseTitle { get; set; }

        [DisplayName(ValidateManagements.SectionDescription)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.SectionDescriptionMaxLength)]
        public string? Description { get; set; }

        [DisplayName(ValidateManagements.SectionJapaneseDescription)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.SectionJapaneseDescriptionMaxLength)]
        public string? JapaneseDescription { get; set; }

        [DisplayName(ValidateManagements.SectionBackgroundImage)]
        public IFormFile? BackgroundImage { get; set; }
    }
}
