using L5A2Programming.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5A2Programming.Models
{
    public class GeneralTicketModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public DateTime dateTime { get; set; }

        public string Type { get; set; }

        public bool Resolved { get; set; }

        [Required]
        public string Message { get; set; }

        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }
    }
}
