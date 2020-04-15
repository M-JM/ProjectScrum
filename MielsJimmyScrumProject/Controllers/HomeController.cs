using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {
            // Check tegen role && signedin
            // En als geen role Index page

            return View();
        }


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

    }
}