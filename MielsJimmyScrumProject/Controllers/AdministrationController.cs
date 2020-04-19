﻿using System;
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
               users = _userManager.Users.Where(x => x.IsDeleted == false).ToList();
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
            
            var allRoles = _roleManager.Roles.ToList();
            var AdminRoles = _roleManager.Roles.Skip(1).ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            if (User.IsInRole("SuperAdmin")) { 
            
            var model = new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = userRoles,
                AllRoles = allRoles,
                              
            };
                return View(model);
            }
            else if (User.IsInRole("Admin"))
            {
                var model = new EditUserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = userRoles,
                    AllRoles = AdminRoles
                    

                };
                return View(model);
            }
            return View("NotAuthorized");
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserAsync(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                var currentrole = await _userManager.GetRolesAsync(user);
                

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found!";
                    return View("NotFound");
                }

                else if (currentrole.Count == 0)
                {
                    await _userManager.AddToRoleAsync(user, model.NewRole);
                    return RedirectToAction("ListUsers", "Administration");
                }
                await _userManager.RemoveFromRoleAsync(user, currentrole.First());
                await _userManager.AddToRoleAsync(user, model.NewRole);
                
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
       

        [HttpPost]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found!";
                return View("NotFound");
            }

            user.IsDeleted = true;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = User.Identity.Name;
          
            foreach(var role in roles) { 
            await _userManager.RemoveFromRoleAsync(user, role);
            }
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
