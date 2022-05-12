using System.ComponentModel.DataAnnotations;

namespace L5A2Programming.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }
        public DateTime dateTime { get; set; }
        public CustomUserModel customUser { get; set; }
    }
}
