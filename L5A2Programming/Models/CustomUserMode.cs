using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5A2Programming.Models
{
    public class CustomUserModel : IdentityUser
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string SName { get; set; }


        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public InstitutionModel Institution { get; set; }
    }
}
