using L5A2Programming.Data;
using L5A2Programming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L5A2Programming.Areas.Admin
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rooms.ToListAsync());
        }

        // GET: Admin/Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RoomsModel = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (RoomsModel == null)
            {
                return NotFound();
            }

            return View(RoomsModel);
        }

        // GET: Admin/Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RoomModel RoomsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(RoomsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(RoomsModel);
        }

        // GET: Admin/Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RoomsModel = await _context.Rooms.FindAsync(id);
            if (RoomsModel == null)
            {
                return NotFound();
            }
            return View(RoomsModel);
        }

        // POST: Admin/Indsitution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RoomModel RoomsModel)
        {
            if (id != RoomsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(RoomsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomModelExists(RoomsModel.Id))
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
            return View(RoomsModel);
        }

        // GET: Admin/Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RoomsModel = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (RoomsModel == null)
            {
                return NotFound();
            }

            return View(RoomsModel);
        }

        // POST: Admin/Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var RoomsModel = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(RoomsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomModelExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
