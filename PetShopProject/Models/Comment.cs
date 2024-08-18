using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PetShopProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [StringLength(1000, ErrorMessage = "Comment cannot be longer than 10,000 characters.")]
        public string CommentText { get; set; } = string.Empty;
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
    }
}
