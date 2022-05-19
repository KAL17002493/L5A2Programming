using L5A2Programming.Data;
using L5A2Programming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L5A2Programming.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AssetController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        public AssetController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public async Task<IActionResult> Index(string search)
        {
            List<AssetModel> assets;

            if (search != null)
            {
                assets = await _db.Assets.Where(a => a.AssetName.ToLower().Contains(search.ToLower())).Include("Category").Include("Institution").Include("Room").ToListAsync();
            }
            else 
            {
                assets = await _db.Assets.Include("Category").Include("Institution").Include("Room").ToListAsync();
            }

            ViewData["search"] = search;
            return View(assets);

        }


        public IActionResult Create()
        {
            AssetViewModel assetViewModel = new AssetViewModel()
            {
                Categories = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
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
            return View(assetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssetViewModel assetViewModel)
        {
                await _db.Assets.AddAsync(assetViewModel.Asset);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }


        //GET
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssetModel currentAsset = await _db.Assets.FindAsync(id);

            if (currentAsset == null)
            {
                return NotFound();
            }

            var assetViewModel = new AssetViewModel()
            {
                Categories = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                Asset = currentAsset
            };

            return View(assetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, AssetViewModel assetViewModel)
        {

            if (id != assetViewModel.Asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _db.Assets.Update(assetViewModel.Asset);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }

            assetViewModel.Categories = _db.Categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(assetViewModel);
        }



        public async Task<IActionResult> Delete(int? id, AssetModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssetModel currentAsset = await _db.Assets.FindAsync(id);

            if (currentAsset == null)
            {
                return NotFound();
            }

            _db.Assets.Remove(currentAsset);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
