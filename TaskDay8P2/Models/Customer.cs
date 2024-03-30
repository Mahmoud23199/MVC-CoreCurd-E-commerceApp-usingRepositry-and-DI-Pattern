using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TaskDay8P2.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format"), Required]
        public string Email { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format"), Required]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }

        [RegularExpression("^(010|011|012)\\d{8}$", ErrorMessage = "phone number must start with 010,011 or 012"), Required]
        public string Phone { get; set; }

        public virtual ICollection<Product>? Orders { get; set; } = new List<Product>();
    }
    public enum Gender
    {
        Male=1 ,Female
    }
}
