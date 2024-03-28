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
    public class NewsEditModel
    {
        [DisplayName(ValidateManagements.NewsId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.NewsTitle)]
        [Required(ErrorMessage = ValidateManagements.NewsTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.NewsTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.NewsDescription)]
        [Required(ErrorMessage = ValidateManagements.NewsDescriptionRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.NewsDescriptionMaxLength)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.NewsDescription)]
        public IFormFile ImageFile { get; set; }

        [DisplayName(ValidateManagements.SectionSlug)]
        [Required(ErrorMessage = ValidateManagements.SectionSlugRequiredMsg)]
        public IList<string> SectionSlug { get; set; }
    }
}
