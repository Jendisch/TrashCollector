using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [StringLength(255)]
        [Display(Name = "First Name")]
        [Required]
        [RegularExpression("^[a-zA-Z''-'\\s]{1,40}$", ErrorMessage = "Please enter your name.")]
        public string FirstName { get; set; }

        [StringLength(255)]
        [Display(Name = "Last Name")]
        [Required]
        [RegularExpression("^[a-zA-Z''-'\\s]{1,40}$", ErrorMessage = "Please enter your name.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[01]?[- .]?(\\([2-9]\\d{2}\\)|[2-9]\\d{2})[- .]?\\d{3}[- .]?\\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Address Line One")]
        public string Line1Address { get; set; }

        [StringLength(255)]
        [Display(Name = "Address Line Two (optional)")]
        public string Line2Address { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "State")]
        [RegularExpression("^[a-zA-Z]{2}", ErrorMessage = "Please enter a valid two letter state abbreviation.")]
             
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression("^(\\d{5}-\\d{4}|\\d{5}|\\d{9})$|^([a-zA-Z]\\d[a-zA-Z] \\d[a-zA-Z]\\d)$", ErrorMessage = "Please enter a valid zip code.")]
        public string ZipCode { get; set; }

        [Display(Name = "Set Weekly Pickup Day")]
        [Required]
        public string StartDate { get; set; }

        [Display(Name = "Payment Type")]
        [Required]
        [StringLength(100)]
        public string PaymentType { get; set; }

        [Display(Name = "Card Number")]
        [Required]
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "Please enter a 16 digit card number.")]
        public double CardNumber { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
