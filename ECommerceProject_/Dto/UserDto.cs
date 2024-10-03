using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Dto
{
    public class UserDto : LoginUserDto
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
