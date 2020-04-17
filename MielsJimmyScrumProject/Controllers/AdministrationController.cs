using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MielsJimmyScrumProject.ViewModels.AdministrationViewModels;
using MielsJimmyScrumProjectDAL.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MielsJimmyScrumProject.Controllers
{
    // [Authorize(Roles = "SuperAdmin,Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //  [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        //  [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityRole = new IdentityRole()
                {
                    Name = model.RoleName
                };

                var result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListUsersAsync()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var users = new List<ApplicationUser>();
       
            if (User.IsInRole("Admin"))
            {
               users = _userManager.Users.Where(x => x.CompanyId == user.CompanyId && x.IsDeleted == false).ToList();
            }
            else
            {
               users = _userManager.Users.ToList();
            }
                      
            return View(users);
        }
        // [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles.ToList();

            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found!";
                return View("NotFound");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
           
           
            var model = new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = userRoles,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserAsync(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found!";
                    return View("NotFound");
                }

                user.Email = model.Email;
                user.UserName = model.UserName;
             
                var identityResult = await _userManager.UpdateAsync(user);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("ListUsers", "Administration");
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found!";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            var listUser = _userManager.Users.ToList();

            foreach (var user in listUser)
            {
                var userRoleViewModel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    
                };

                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);

                userRoleViewModel.IsSelected = isInRole;

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserInRoleAsync(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found!";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);

                IdentityResult result = null;

                if (model[i].IsSelected && !isInRole)
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && isInRole)
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found!";
                return View("NotFound");
            }

            var model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name,
            };

            var listUser = _userManager.Users.ToList();

            foreach (var user in listUser)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);

                if (isInRole)
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);

                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found!";
                    return View("NotFound");
                }

                role.Name = model.RoleName;

                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found!";
                return View("NotFound");
            }

            user.IsDeleted = true;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = User.Identity.Name;

            // delete related record in boarduser

            var identityResult = await _userManager.UpdateAsync(user);

            if (identityResult.Succeeded)
            {
                return RedirectToAction("ListUsers", "Administration");
            }

            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction("ListUsers", "Administration");
        }

    }
}
