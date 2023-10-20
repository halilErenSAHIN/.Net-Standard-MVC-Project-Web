using Core.Concrates.Enums;
using System.ComponentModel.DataAnnotations;

namespace UI.WEB.Models
{
    public class ContactFormViewModel
    {
        [Required]
        [Display(Name = "Firstname", Prompt = "Firstname")]
        [MinLength(3), MaxLength(25)]
        [RegularExpression("^[a-zA-ZçÇğĞıİöÖşŞüÜ]{3,25}$")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Lastname", Prompt = "Lastname")]
        [MinLength(3), MaxLength(25)]
        [RegularExpression("^[a-zA-ZçÇğĞıİöÖşŞüÜ]{3,25}$")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "E-Mail Address", Prompt = "E-Mail Address")]
        [EmailAddress]
        [RegularExpression(@"^[\w\.-]+@[\w-]+(\.[\w-]{2,})+$")]
        public string EMail { get; set; }

        [Display(Name = "Message Type", Prompt = "Message Type")]
        [Required]
        public MessageType Type { get; set; }

        [Required]
        [MinLength(3), MaxLength(150)]
        [Display(Name = "Subject", Prompt = "Subject")]
        public string Subject { get; set; }

        [Required]
        [MinLength(3), MaxLength(500)]
        [Display(Name = "Your Message", Prompt = "Your Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}