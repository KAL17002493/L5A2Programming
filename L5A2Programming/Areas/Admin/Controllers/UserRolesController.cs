using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L5A2Programming.Areas.Admin.Models;
using L5A2Programming.Models;
using L5A2Programming.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L5A2Programming.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUserModel> _userManager;
        private readonly ApplicationDbContext _db;
        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<CustomUserModel> userManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index(string search)
        {
            var users = await _userManager.Users.Include("Institution").ToListAsync();
            var VMlist = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var currentVM = new UserRolesViewModel()
                {
                    User = user,
                    Roles = new List<string>(await _userManager.GetRolesAsync(user))
                };
                VMlist.Add(currentVM);
            }

            if (search != null)
            {
                VMlist = VMlist.Where(u => u.User.Email.ToLower().Contains(search.ToLower())).ToList();
            }

            ViewData["search"] = search;
            return View(VMlist.ToList());
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }

        //GET
        public async Task<IActionResult> Manage(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var viewModels = new List<ManageUserRoleViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var vm = new ManageUserRoleViewModel();
                vm.User = user;
                vm.Role = role;
                vm.IsInRole = await _userManager.IsInRoleAsync(user, role.Name);
                viewModels.Add(vm);
            }

            return View(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRoleViewModel> model)
        {
            if (model != null && model.Count >= 1)
            {
                var user = await _userManager.FindByIdAsync(model[0].User.Id);

                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var result = await _userManager.RemoveFromRolesAsync(user, roles);

                    if (!result.Succeeded)
                    {

                        ModelState.AddModelError("1", "Error Removing Roles.");
                        return View(model);
                    }
                    result = await _userManager.AddToRolesAsync(user, model.Where(x => x.IsInRole).Select(y => y.Role.Name));

                    if (!result.Succeeded)
                    {

                        ModelState.AddModelError("3", "Error Adding Roles.");
                        return View(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("2", "User Not Found.");
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Manage");
            }
           
        }

        //Get
        public async Task<IActionResult> ManageInstitution(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var institution = await _db.Institutions.ToListAsync();

            if (user == null)
            {
                return RedirectToAction("Index");
            }
            ManageInstitutionViewModel viewModel = new ManageInstitutionViewModel()
            {
                User = user,
                Institution = _db.Institutions.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            
            return View(viewModel);
    }

        [HttpPost]
        public async Task<IActionResult> ManageInstitution(ManageInstitutionViewModel model)
        {
            
            if (model != null)
            {
                var user = await _userManager.FindByIdAsync(model.User.Id);
            
                if(user != null)
                {
                    user.InstitutionId = model.User.InstitutionId;
                    _db.Users.Update(user);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }



    }
}
