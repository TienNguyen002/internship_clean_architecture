using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.Items
{
    public class FooterEditModel
    {
        [DisplayName(ValidateManagements.FooterItemId)]
        public int Id { get; set; }

        [DisplayName(ValidateManagements.FooterItemTitle)]
        [Required(ErrorMessage = ValidateManagements.FooterItemTitleRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength100, ErrorMessage = ValidateManagements.FooterItemTitleMaxLength)]
        public string Title { get; set; }

        [DisplayName(ValidateManagements.FooterItemAddress)]
        public string? Address { get; set; }

        [DisplayName(ValidateManagements.FooterItemTelNumber)]
        public string? TelNumber { get; set; }

        [DisplayName(ValidateManagements.FooterItemDescription)]
        public string? Description { get; set; }

        [DisplayName(ValidateManagements.FooterItem1stGmail)]
        public string? InfoGmail { get; set; }

        [DisplayName(ValidateManagements.FooterItem2ndGmail)]
        public string? InfoGmail2 { get; set; }

        [DisplayName(ValidateManagements.FooterItemSkype)]
        public string? Skype { get; set; }

        [DisplayName(ValidateManagements.FooterItemFacebook)]
        public string? Facebook { get; set; }

        [DisplayName(ValidateManagements.FooterItemTwitter)]
        public string? Twitter { get; set; }

        [DisplayName(ValidateManagements.FooterItemLinkedin)]
        public string? Linkedin { get; set; }

        [DisplayName(ValidateManagements.FooterItemYoutube)]
        public string? Youtube { get; set; }
    }
}
