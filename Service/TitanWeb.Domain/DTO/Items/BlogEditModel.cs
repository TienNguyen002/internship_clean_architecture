using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [DisplayName(ValidateManagements.BlogSlug)]
        [Required(ErrorMessage = ValidateManagements.BlogSlugRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BlogSlugMaxLength)]
        public string UrlSlug { get; set; }

        [DisplayName(ValidateManagements.BlogSubTitle)]
        [Required(ErrorMessage = ValidateManagements.BlogSubTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.BlogSubTitleMaxLength)]
        public string SubTitle { get; set; }

        [DisplayName(ValidateManagements.BlogShortDescription)]
        [Required(ErrorMessage = ValidateManagements.BlogShortDescriptionRequiredMsg)]
        public string ShortDescription { get; set; }

        [DisplayName(ValidateManagements.BlogDescription)]
        [Required(ErrorMessage = ValidateManagements.BlogDescriptionRequiredMsg)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.BlogImage)]
        public IFormFile ImageFile { get; set; }
    }
}
