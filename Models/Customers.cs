using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Customers
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email is missing!")]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string Email { get; set; }


        // Example for a strong password regex
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }


        [Required(ErrorMessage = "A phone number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
       
      
    }
}
