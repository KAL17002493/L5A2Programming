using L5A2Programming.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L5A2Programming.Areas.Admin.Models
{
    public class ManageInstitutionViewModel
    {
        public CustomUserModel User { get; set; }
        public IEnumerable<SelectListItem> Institution { get; set; }
    }
}
