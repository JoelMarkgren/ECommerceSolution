using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerceMVC.Models
{
    public class Cellphone
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
    }
}
