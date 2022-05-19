using Microsoft.AspNetCore.Mvc.Rendering;

namespace L5A2Programming.Models
{
    public class RoomViewModel
    {
        public RoomModel Room { get; set; }
        public IEnumerable<SelectListItem> Institution { get; set; }
    }
}
