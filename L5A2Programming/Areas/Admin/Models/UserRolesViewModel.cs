using L5A2Programming.Models;
using System.Collections.Generic;

namespace L5A2Programming.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public CustomUserModel User { get; set; }
        public List<String> Roles { get; set; }
    }
}
