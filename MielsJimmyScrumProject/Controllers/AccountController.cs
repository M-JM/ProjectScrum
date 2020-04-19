using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MielsJimmyScrumProject.ViewModels.AccountViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MielsJimmyScrumProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICompanyRepository _companyRepository;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICompanyRepository companyRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _companyRepository = companyRepository;
        }
      
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminRegister(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    var admin = await _userManager.FindByEmailAsync(User.Identity.Name);
                    var company = _companyRepository.GetById(admin.CompanyId);
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        CreatedBy = model.Email,
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,
                        Company = company,
                        
                    };
               
                var result = await _userManager.CreateAsync(user, model.Password);
                var receivedUser = await _userManager.FindByEmailAsync(model.Email);
                    await _userManager.AddToRoleAsync(receivedUser, "User");
                // If user is successfully created
                if (result.Succeeded)
                {
                  return RedirectToAction("ListUsers","Administration");
                }
                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
                return View("Register",model);
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               // Create a new Identity user with form received from RegisterViewModel
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    CreatedBy = model.Email,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,                          
                };

                // Create the entry in the User Table ( Db)
                var result = await _userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to HomePage
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                
                if (signInResult.Succeeded )
                {
                    if (string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    var currentuser = await _userManager.FindByEmailAsync(model.Email);

                    //if (User.IsInRole("Admin"))
                    if (await _userManager.IsInRoleAsync(currentuser, "Admin"))
                    {
                        return RedirectToAction("AdminIndex", "Home");
                    }
                    else if (await _userManager.IsInRoleAsync(currentuser, "User"))
                    {
                        return RedirectToAction("UserIndex", "Home");
                    }
                    else if (await _userManager.IsInRoleAsync(currentuser, "SuperAdmin"))
                    {
                        return RedirectToAction("SuperAdminIndex","Home");
                    }

                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
