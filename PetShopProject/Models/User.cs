
using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Models
{
    public class User 
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
