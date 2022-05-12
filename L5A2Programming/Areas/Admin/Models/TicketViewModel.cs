using Microsoft.AspNetCore.Mvc.Rendering;

namespace L5A2Programming.Models
{
    public class TicketViewModel
    {
        public TicketModel Ticket { get; set; }
        public IEnumerable<SelectListItem> Institution { get; set; }
        public IEnumerable<SelectListItem> Room { get; set; }
        public IEnumerable<SelectListItem> Asset { get; set; }

    }
}
