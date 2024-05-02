using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class ItemEditModel
    {
        [DisplayName(ValidateManagements.ItemId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.ItemTitle)]
        [Required(ErrorMessage = ValidateManagements.TitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.ItemSlug)]
        [Required(ErrorMessage = ValidateManagements.UrlSlugRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.UrlSlugMaxLength)]
        [RegularExpression(ValidateManagements.SlugPattern)]
        public string UrlSlug { get; set; }
        
        [DisplayName(ValidateManagements.ItemSubTitle)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemSubTitleMaxLength)]
        public string SubTitle { get; set; }
        
        [DisplayName(ValidateManagements.ItemDescription)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.DescriptionMaxLength)]
        public string Description { get; set; }

        [DisplayName(ValidateManagements.SectionSlug)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.UrlSlugMaxLength)]
        [RegularExpression(ValidateManagements.SlugPattern)]
        public string SectionSlug { get; set; }

        [DisplayName(ValidateManagements.ItemImage)]
        public IFormFile ImageFile { get; set; }
    }
}