using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskDay8P2.Models
{
    public class Product
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
