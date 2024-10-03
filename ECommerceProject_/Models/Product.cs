using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
    }
}
