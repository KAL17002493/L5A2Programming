using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L5A2Programming.Data;
using L5A2Programming.Models;

namespace OnlineShop2022.Areas.Admin
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class InstitutionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstitutionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Institution
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institutions.ToListAsync());
        }

        // GET: Admin/Institution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionsModel = await _context.Institutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutionsModel == null)
            {
                return NotFound();
            }

            return View(institutionsModel);
        }

        // GET: Admin/Institution/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Institution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] InstitutionModel institutionsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionsModel);
        }

        // GET: Admin/Institution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionsModel = await _context.Institutions.FindAsync(id);
            if (institutionsModel == null)
            {
                return NotFound();
            }
            return View(institutionsModel);
        }

        // POST: Admin/Indsitution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] InstitutionModel institutionsModel)
        {
            if (id != institutionsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionModelExists(institutionsModel.Id))
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
            return View(institutionsModel);
        }

        // GET: Admin/Institution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionsModel = await _context.Institutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutionsModel == null)
            {
                return NotFound();
            }

            return View(institutionsModel);
        }

        // POST: Admin/Institution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institutionsModel = await _context.Institutions.FindAsync(id);
            _context.Institutions.Remove(institutionsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionModelExists(int id)
        {
            return _context.Institutions.Any(e => e.Id == id);
        }
    }
}
