using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerceMVC.Models
{
    public class Cellphone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Image { get; set; }
    }
}
