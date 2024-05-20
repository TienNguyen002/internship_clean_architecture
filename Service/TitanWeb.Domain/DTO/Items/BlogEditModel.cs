using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class BlogEditModel
    {
        [DisplayName(ValidateManagements.BlogId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.BlogTitle)]
        [Required(ErrorMessage = ValidateManagements.BlogTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BlogTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.BlogJapaneseTitle)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BlogJapaneseTitleMaxLength)]
        public string? JapaneseTitle { get; set; }

        [DisplayName(ValidateManagements.BlogSubTitle)]
        [Required(ErrorMessage = ValidateManagements.BlogSubTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BlogSubTitleMaxLength)]
        public string SubTitle { get; set; }

        [DisplayName(ValidateManagements.BlogShortDescription)]
        [Required(ErrorMessage = ValidateManagements.BlogShortDescriptionRequiredMsg)]
        public string ShortDescription { get; set; }

        [DisplayName(ValidateManagements.BlogJapaneseShortDescriptionRequiredMsg)]
        [Required(ErrorMessage = ValidateManagements.BlogJapaneseShortDescriptionMaxLength)]
        public string JapaneseShortDescription { get; set; }

        [DisplayName(ValidateManagements.BlogDescription)]
        [Required(ErrorMessage = ValidateManagements.BlogDescriptionRequiredMsg)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.BlogJapaneseDescriptionRequiredMsg)]
        [Required(ErrorMessage = ValidateManagements.BlogJapaneseDescriptionMaxLength)]
        public string JapaneseDescription { get; set; }

        [DisplayName(ValidateManagements.BlogImage)]
        public IFormFile? ImageFile { get; set; }
    }
}
