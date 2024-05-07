using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class ItemEditModel
    {
        [DisplayName(ValidateManagements.ItemId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.ItemTitle)]
        [Required(ErrorMessage = ValidateManagements.ItemTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.ItemJapaneseTitle)]
        [Required(ErrorMessage = ValidateManagements.ItemJapaneseTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemJapaneseTitleMaxLength)]
        public string JapaneseTitle { get; set; }

        [DisplayName(ValidateManagements.ItemSubTitle)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemSubTitleMaxLength)]
        public string? SubTitle { get; set; }

        [DisplayName(ValidateManagements.ItemJapaneseSubTitle)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemJapaneseSubTitleMaxLength)]
        public string? JapaneseSubTitle { get; set; }

        [DisplayName(ValidateManagements.ItemDescription)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.ItemDescriptionMaxLength)]
        public string? Description { get; set; }

        [DisplayName(ValidateManagements.ItemJapaneseDescription)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.ItemJapaneseDescriptionMaxLength)]
        public string? JapaneseDescription { get; set; }

        [DisplayName(ValidateManagements.ItemJapaneseDescription)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemButtonLabelMaxLength)]
        public string? ButtonLabel { get; set; }

        [DisplayName(ValidateManagements.ItemJapaneseDescription)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.ItemJapaneseButtonLabelMaxLength)]
        public string? JapaneseButtonLabel { get; set; }

        [DisplayName(ValidateManagements.SectionSlug)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.UrlSlugMaxLength)]
        public string? SectionSlug { get; set; }

        [DisplayName(ValidateManagements.CategorySlug)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.UrlSlugMaxLength)]
        public string? CategorySlug { get; set; }

        [DisplayName(ValidateManagements.ItemImage)]
        public IFormFile? ImageFile { get; set; }
    }
}