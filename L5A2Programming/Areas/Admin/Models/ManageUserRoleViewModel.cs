//Manage user's Roles
using Microsoft.AspNetCore.Identity;
using L5A2Programming.Models;

namespace L5A2Programming.Areas.Admin.Models
{
    public class ManageUserRoleViewModel
    {
        public CustomUserModel User { get; set; }

        public IdentityRole Role { get; set; }

        public bool IsInRole { get; set; }
    }
}
