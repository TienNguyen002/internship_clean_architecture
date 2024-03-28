using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TitanWeb.Domain.Constants;

namespace TitanWeb.Domain.DTO.RequestForm
{
    public class RequestFormEditModel
    {
        [DisplayName(ValidateManagements.RequestFormName)]
        [Required(ErrorMessage = ValidateManagements.RequestFormNameRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength50, ErrorMessage = ValidateManagements.RequestFormNameMaxLengthMsg)]
        public string Name { get; set; }

        [DisplayName(ValidateManagements.RequestFormEmail)]
        [Required(ErrorMessage = ValidateManagements.RequestFormEmailRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength50, ErrorMessage = ValidateManagements.RequestFormEmailMaxLengthMsg)]
        [EmailAddress(ErrorMessage = ValidateManagements.RequestFormEmailValidateErrorMsg)]
        public string Email { get; set; }

        [DisplayName(ValidateManagements.RequestFormPhone)]
        [MaxLength(ValidateManagements.MaxLength20, ErrorMessage = ValidateManagements.RequestFormPhoneMaxLengthMsg)]
        public string? Phone { get; set; }

        [DisplayName(ValidateManagements.RequestFormSubject)]
        [Required(ErrorMessage = ValidateManagements.RequestFormSubjectRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength50, ErrorMessage = ValidateManagements.RequestFormSubjectMaxLengthMsg)]
        public string Subject { get; set; }

        [DisplayName(ValidateManagements.RequestFormMessage)]
        [Required(ErrorMessage = ValidateManagements.RequestFormMessageRequiredMsg)]
        [MaxLength(ValidateManagements.MaxLength500, ErrorMessage = ValidateManagements.RequestFormMessageMaxLengthMsg)]
        public string Message { get; set; }
    }
}
