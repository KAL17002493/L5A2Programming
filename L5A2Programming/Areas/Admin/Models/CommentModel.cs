using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5A2Programming.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        public int TicketId { get; set; }

        public string Comment { get; set; }
        public DateTime dateTime { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUserModel User { get; set; }
    }
}
