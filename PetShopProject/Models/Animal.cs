using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [StringLength(50, ErrorMessage = "Animal Name cannot be longer than 50 characters.")]
        public string Name { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Age must be at least 1.")]
        public int Age { get; set; }
        public byte[] PictureName { get; set; } = Array.Empty<byte>();
        [StringLength(10000, ErrorMessage = "Description cannot be longer than 10,000 characters.")]
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
