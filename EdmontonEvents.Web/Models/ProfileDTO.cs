using EdmontonEvents.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace EdmontonEvents.Web.Models
{
    public class ProfileDTO
    {
        public ProfileDTO()
        {
            FormResult = new FormResult();
        }

        public ProfileDTO(UserAccount user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber ?? "";
            PostalCode = user.PostalCode ?? "";
            FormResult = new FormResult();
        }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [StringLength(7, ErrorMessage = "Postal code must be in the form XXX-XXX")]
        [MinLength(7, ErrorMessage = "Postal code must be in the form XXX-XXX")]
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        public FormResult FormResult { get; set; }

    }
}
