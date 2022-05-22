using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L5A2Programming.Data;
using L5A2Programming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace L5A2Programming.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<CustomUserModel> _userManager;

        public TicketController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, UserManager<CustomUserModel> userManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin, Estate Staff")]
        // GET: Admin/Ticket
        public async Task<IActionResult> Index(string search)
        {
            var tickets = _db.Tickets.Where(t => t.Resolved == false).Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);

            if (search != null)
            {
                tickets = _db.Tickets.Where(t => t.Asset.AssetName.ToLower().Contains(search.ToLower())).Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);
            }


            ViewData["search"] = search;
            return View(await tickets.ToListAsync());

            //var applicationDbContext = _db.Tickets.Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);
            //return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> UserIndex(string search)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var tickets = _db.Tickets.Where(t => t.Resolved == false && t.InstitutionId == currentUser.InstitutionId).Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);

            if (search != null)
            {
                tickets = _db.Tickets.Where(t => t.Asset.AssetName.ToLower().Contains(search.ToLower()) && t.InstitutionId == currentUser.InstitutionId ).Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);
            }


            ViewData["search"] = search;
            return View(await tickets.ToListAsync());
        }

        // GET: Admin/Ticket/Create
        public IActionResult Create()
        {
                TicketViewModel ticketViewModel = new TicketViewModel()
                {
                    Asset = _db.Assets.Select(i => new SelectListItem
                    {
                        Text = i.AssetName,
                        Value = i.Id.ToString()
                    }),

                    Institution = _db.Institutions.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    Room = _db.Rooms.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
                };
                return View(ticketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketViewModel ticketViewModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            ticketViewModel.Ticket.dateTime = DateTime.Now;
            ticketViewModel.Ticket.EmailAddress = User.Identity.Name;
            ticketViewModel.Ticket.Resolved = false;
            ticketViewModel.Ticket.Type = "Maintenance";

            if (User.IsInRole("Institution Manager") || User.IsInRole("Institution manager") || User.IsInRole("Other") || User.IsInRole("Receptionist"))
            {
                ticketViewModel.Ticket.InstitutionId = currentUser.InstitutionId;
            }

            await _db.Tickets.AddAsync(ticketViewModel.Ticket);
            await _db.SaveChangesAsync();

            if(User.IsInRole("Admin") || User.IsInRole("Estate Staff"))
            { 
            return RedirectToAction(nameof(Index));
            }
            else if (User.IsInRole("Institution Manager") || User.IsInRole("Institution manager"))
            {
                return RedirectToAction(nameof(UserIndex));
            }
            return RedirectToAction("Index", "Home", new { area = "Home" });
        }


        // GET: Admin/Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Tickets == null)
            {
                return NotFound();
            }

            var ticketModel = await _db.Tickets.FindAsync(id);
            if (ticketModel == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_db.Assets, "Id", "AssetName", ticketModel.AssetId);
            ViewData["InstitutionId"] = new SelectList(_db.Institutions, "Id", "Name", ticketModel.InstitutionId);
            ViewData["RoomId"] = new SelectList(_db.Rooms, "Id", "Name", ticketModel.RoomId);
            return View(ticketModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _db.Tickets == null)
            {
                return NotFound();
            }

            var ticketModel = await _db.Tickets.Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room).FirstOrDefaultAsync(m => m.Id == id);
            ticketModel.Comments = await _db.Comments.Where(t => t.TicketId == ticketModel.Id).Include("User").OrderByDescending(t => t.dateTime).ToListAsync();

            if (ticketModel == null)
            {
                return NotFound();
            }

            return View(ticketModel);
        }




        public async Task<IActionResult> Delete(int id, TicketModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            TicketModel ticketModelDelete = await _db.Tickets.FindAsync(id);

            if(ticketModelDelete == null)
            {
                return NotFound();
            }

            _db.Tickets.Remove(ticketModelDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketModelExists(int id)
        {
          return (_db.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string comment, int id)
        {

            var ticket = await _db.Tickets.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (comment != null)
            {
                ticket.Comments.Add(new CommentModel
                {
                    Comment = comment,
                    TicketId = id,
                    dateTime = DateTime.Now,
                    User = await _userManager.FindByEmailAsync(User.Identity.Name)
                });
            }
            else
            {
                return RedirectToAction(nameof(Details), new { id = ticket.Id });
            }

            _db.Tickets.Update(ticket);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new {id = ticket.Id});
        }





        [HttpPost]
        public async Task<IActionResult> isResolved(string comment, int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _db.Tickets.Where(t => t.Id == id).FirstOrDefaultAsync(x => x.Id == id);

            if (model != null)
            {
                model.Comments.Add(new CommentModel
                {
                    Comment = comment,
                    TicketId = id,
                    dateTime = DateTime.Now,
                    User = await _userManager.FindByEmailAsync(User.Identity.Name)
                });
            }
            else
            {
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            model.Resolved = true;
            _db.Tickets.Update(model);
            await _db.SaveChangesAsync();

            if (User.IsInRole("Admin") || User.IsInRole("Estate Staff"))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(UserIndex));
        }
    }
}
