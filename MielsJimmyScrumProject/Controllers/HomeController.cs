using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MielsJimmyScrumProject.ViewModels.HomeViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;

namespace MielsJimmyScrumProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ICompanyRepository companyRepository,ITaskRepository taskRepository, IBoardRepository boardRepository, UserManager<ApplicationUser> userManager)
        {
            _companyRepository = companyRepository;
            _taskRepository = taskRepository;
            _boardRepository = boardRepository;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
      
                        
            if(User.IsInRole("Admin"))

            { return RedirectToAction("AdminIndex"); }

            else if (User.IsInRole("User"))
            {
            { return RedirectToAction("UserIndex"); }
            }
            else if (User.IsInRole("SuperAdmin"))
            {
            { return RedirectToAction("SuperAdminIndex"); }
            }
           

            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult SuperAdminIndex()
        {
            var SuperAdminmodel = new SuperAdminIndexViewModel();
            {
                SuperAdminmodel.boards = _boardRepository.GetAllBoards().ToList();
                SuperAdminmodel.Companies = _companyRepository.GetAllCompanies().Where(x => x.IsDeleted== false).ToList();
                SuperAdminmodel.Users = _userManager.Users.Where(x => x.IsDeleted == false).ToList();
                

            }
            return View(SuperAdminmodel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AdminIndexAsync()
        {
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var company = _companyRepository.GetById(currentuser.CompanyId);
            var boards = _boardRepository.GetAllBoardsfromcompany(company.Id);
           

            var AdminIndexView = new AdminIndexViewModel();
            {
                AdminIndexView.company = company;
                AdminIndexView.boards = boards;
             
            }
                       
            return View(AdminIndexView);
        }
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UserIndexAsync()
        {
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var company = _companyRepository.GetById(currentuser.CompanyId);
           // var boards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).ToList();
            var UserBoards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).Where(x => x.BoardUsers.Any(x => x.ApplicationUserId == currentuser.Id && x.IsDeleted == false)).ToList();


            var UserIndexView = new UserIndexViewModel();
            {
                UserIndexView.company = company;
                UserIndexView.boards = UserBoards;

            }

            return View(UserIndexView);
        }


    }
}