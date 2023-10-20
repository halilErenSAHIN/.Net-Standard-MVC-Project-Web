using System.ComponentModel.DataAnnotations;

namespace UI.WEB.Models
{
    public class RegisterViewModel
    {
        const string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        [Required]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-Mail Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        [RegularExpression(pattern, ErrorMessage = "At least 8 characters long\r\nContains at least one lowercase letter\r\nContains at least one uppercase letter\r\nContains at least one digit\r\nContains at least one special character from the set [@$!%*?&]")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [RegularExpression(pattern, ErrorMessage = "At least 8 characters long\r\nContains at least one lowercase letter\r\nContains at least one uppercase letter\r\nContains at least one digit\r\nContains at least one special character from the set [@$!%*?&]")]
        public string ConfirmPassword { get; set; }
    }
}



