using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using L5A2Programming.Areas.Admin.Models;
using L5A2Programming.Models;

namespace L5A2Programming.Models
{
    public class TicketModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public DateTime dateTime { get; set; }

        public bool Resolved { get; set; }

        [Required]
        public string Message { get; set; }

        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public RoomModel Room { get; set; }

        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public AssetModel Asset { get; set; }

    }
}
