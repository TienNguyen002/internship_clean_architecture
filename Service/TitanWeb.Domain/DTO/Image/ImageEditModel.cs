using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Image
{
    public class ImageEditModel
    {   
        [DisplayName(ValidateManagements.ImageFile)]
        [Required(ErrorMessage = ValidateManagements.FileRequiredMsg)]
        public IFormFile ImageFile { get; set; }

        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.HyperlinkMaxLengthMsg)]
        public string? Hyperlink { get; set; }

        [DisplayName(ValidateManagements.IsLogo)]
        [Required(ErrorMessage = ValidateManagements.IsLogoRequiredMsg)]
        public bool IsLogo { get; set; } = false;
    }
}
