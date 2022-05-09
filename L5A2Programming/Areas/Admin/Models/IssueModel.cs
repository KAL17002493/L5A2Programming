using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace L5A2Programming.Models
{
    public class IssueModel
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int ItemId { get; set; }
        public DateTime TimeStamp { get; set; }
        public CustomUserModel User { get; set; }
        public string Comment { get; set; }

    }
}
