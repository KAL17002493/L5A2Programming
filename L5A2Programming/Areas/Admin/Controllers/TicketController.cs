using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L5A2Programming.Data;
using L5A2Programming.Models;
using Microsoft.AspNetCore.Authorization;

namespace L5A2Programming.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        public TicketController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        // GET: Admin/Ticket
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _db.Tickets.Include(t => t.Asset).Include(t => t.Institution).Include(t => t.Room);
            return View(await applicationDbContext.ToListAsync());
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
            ticketViewModel.Ticket.dateTime = DateTime.Now;
            ticketViewModel.Ticket.EmailAddress = User.Identity.Name;
            ticketViewModel.Ticket.Resolved = false;


            await _db.Tickets.AddAsync(ticketViewModel.Ticket);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

        // POST: Admin/Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmailAddress,dateTime,Resolved,InstitutionId,RoomId,AssetId,Type")] TicketModel ticketModel)
        {
            if (id != ticketModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(ticketModel);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketModelExists(ticketModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_db.Assets, "Id", "AssetName", ticketModel.AssetId);
            ViewData["InstitutionId"] = new SelectList(_db.Institutions, "Id", "Name", ticketModel.InstitutionId);
            ViewData["RoomId"] = new SelectList(_db.Rooms, "Id", "Name", ticketModel.RoomId);
            return View(ticketModel);
        }

        // GET: Admin/Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Tickets == null)
            {
                return NotFound();
            }

            var ticketModel = await _db.Tickets
                .Include(t => t.Asset)
                .Include(t => t.Institution)
                .Include(t => t.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketModel == null)
            {
                return NotFound();
            }

            return View(ticketModel);
        }

        // POST: Admin/Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Tickets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tickets'  is null.");
            }
            var ticketModel = await _db.Tickets.FindAsync(id);
            if (ticketModel != null)
            {
                _db.Tickets.Remove(ticketModel);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketModelExists(int id)
        {
          return (_db.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
