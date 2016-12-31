using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.ComponentModel;

namespace knihaJizd.Models
{
    public class IndexViewModel
    {
        public string Id { get; set; }
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }

        [DisplayName("Telefoní číslo")]
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }

        [DisplayName("Jméno")]
        public string Name { get; set; }

        [DisplayName("Příjmení")]
        public string Surname { get; set; }

        [DisplayName("Adresa")]
        public string Address { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DisplayName("Č. Řidičského průkazu")]
        public string DrivingLicenceId { get; set; }
        public bool? Admin { get; set; }
    }

    public class Edit
    {
        [DisplayName("Telefoní číslo")]
        public string PhoneNumber { get; set; }

        [DisplayName("Jméno")]
        public string Name { get; set; }

        [DisplayName("Příjmení")]
        public string Surname { get; set; }

        [DisplayName("Adresa")]
        public string Address { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DisplayName("Č. Řidičského průkazu")]
        public string DrivingLicenceId { get; set; }

        [DisplayName("Administrátor")]
        public bool? Admin { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Staré heslo")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} Musí být minimílně {2} dlouhé.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Znovu nové heslo")]
        [Compare("NewPassword", ErrorMessage = "Nové hesla se neshodují.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}