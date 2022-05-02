using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace L5A2Programming.Models
{
    public class CustomUserModel : IdentityUser
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string SName { get; set; }

    }
}
