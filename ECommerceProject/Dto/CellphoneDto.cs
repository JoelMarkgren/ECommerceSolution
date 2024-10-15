using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Dto
{
    public class CellphoneDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string? Image { get; set; }
    }
}
