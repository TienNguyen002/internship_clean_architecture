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

        [DisplayName(ValidateManagements.NewsSlug)]
        [Required(ErrorMessage = ValidateManagements.NewsSlugRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.NewsSlugMaxLength)]
        public string UrlSlug { get; set; }

        [DisplayName(ValidateManagements.NewsShortDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsShortDescriptionRequiredMsg)]
        public string ShortDescription { get; set; }

        [DisplayName(ValidateManagements.NewsDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsDescriptionRequiredMsg)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.NewsImage)]
        public IFormFile? ImageFile { get; set; }
    }
}
