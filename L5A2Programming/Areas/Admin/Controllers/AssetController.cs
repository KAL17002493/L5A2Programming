using L5A2Programming.Data;
using L5A2Programming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace L5A2Programming.Areas.Admin
{
    [Area("Admin")]
    public class AssetController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<CustomUserModel> _userManager;

        public AssetController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, UserManager<CustomUserModel> userManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string search)
        {
            
            List<AssetModel> assets;
            
            if (search != null)
            {
                //creates a list of itmes matching the search term
                assets = await _db.Assets.Where(a => a.AssetName.ToLower().Contains(search.ToLower())).Include("Category").Include("Institution").Include("Room").ToListAsync();
            }
            else 
            {
                //creates a list of all assets in database 
                assets = await _db.Assets.Include("Category").Include("Institution").Include("Room").ToListAsync();
            }

            ViewData["search"] = search;
            return View(assets);

        }
        [Authorize(Roles = "Admin, Institution Manager, Institution manager, Other, Receptionist, Estate Staff")]
        public async Task<IActionResult> UserIndex(string search)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            List<AssetModel> assets;

            if (search != null)
            {
                //creates a list of itmes matching the search term but also checks looks for tickets only created by the current user
                assets = await _db.Assets.Where(a => a.AssetName.ToLower().Contains(search.ToLower()) && a.InstitutionId == currentUser.InstitutionId).Include("Category").Include("Institution").Include("Room").ToListAsync();
            }
            else
            {
                //creates a list of all assets in database created by the current user
                assets = await _db.Assets.Where(a => a.InstitutionId == currentUser.InstitutionId).Include("Category").Include("Institution").Include("Room").ToListAsync();
            }

            ViewData["search"] = search;
            return View(assets);
        }

        public IActionResult Create()
        {
            //Retrives SelecLists when clicking on create button
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

        //Posts data to database
        [HttpPost]
        public async Task<IActionResult> Create(AssetViewModel assetViewModel)
        {
                await _db.Assets.AddAsync(assetViewModel.Asset);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }


        //Retrieves all information by the current assets Id
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

        //GET DOES NOT WORK
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


        //Deletes asset
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
