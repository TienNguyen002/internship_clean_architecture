using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class NewsEditModel
    {
        [DisplayName(ValidateManagements.NewsId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.NewsTitle)]
        [Required(ErrorMessage = ValidateManagements.NewsTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.NewsTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.NewsJapaneseTitle)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.NewsJapaneseTitleMaxLength)]
        public string? JapaneseTitle { get; set; }

        [DisplayName(ValidateManagements.NewsShortDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsShortDescriptionRequiredMsg)]
        public string ShortDescription { get; set; }

        [DisplayName(ValidateManagements.NewsJapaneseShortDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsJapaneseShortDescriptionRequiredMsg)]
        public string JapaneseShortDescription { get; set; }

        [DisplayName(ValidateManagements.NewsDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsDescriptionRequiredMsg)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.NewsJapaneseDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsJapaneseDescriptionRequiredMsg)]
        public string JapaneseDescription { get; set; }

        [DisplayName(ValidateManagements.NewsImage)]
        public IFormFile? ImageFile { get; set; }
    }
}
