using L5A2Programming.Data;
using L5A2Programming.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L5A2Programming.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<CustomUserModel> _userManager;

        public HomeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, UserManager<CustomUserModel> userManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            //Redirects user to login page if they are not logged in
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            //creates variable which checks if ticket has been resolved and if the ticket was created by current user
            var tickets = _db.Tickets.Where(t => t.Resolved == false && t.EmailAddress == currentUser.Email).Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);

            //outputs all tickets but only displays the ones creates by current user
            return View(await tickets.ToListAsync());
        }

    }
}