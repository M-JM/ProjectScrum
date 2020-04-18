using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MielsJimmyScrumProject.Models;
using MielsJimmyScrumProject.ViewModels.CompaniesViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MielsJimmyScrumProject.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CompaniesController : Controller
    {
     
        private readonly ICompanyRepository _companyRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompaniesController(ICompanyRepository companyRepository,
            IBoardRepository boardRepository,
            IWebHostEnvironment webHostEnvironment,
            ITaskRepository taskRepository,
            UserManager<ApplicationUser> userManager)
        {
            _companyRepository = companyRepository;
            _boardRepository = boardRepository;
            _webHostEnvironment = webHostEnvironment;
            _taskRepository = taskRepository;
            _userManager = userManager;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult CompanyList()
        {
            var companyList = _companyRepository.GetAllCompanies();
            return View(companyList);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = User.Identity.Name; 
                    model.PhotoPath = ProcessUploadFile(model);
                }

                var response = _companyRepository.Create(model);

                if (response != null && response.Id != 0)
                {
                    return RedirectToAction("CompanyList");
                }
            }

            return View(model);

            //TODO Implement error model.
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {

            var company = _companyRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var IsSuperAdmin = User.IsInRole("SuperAdmin");
            
            if (company == null || company.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("CompanyNotFound", id);
            }
           else if ( IsSuperAdmin || company.Id == currentuser.CompanyId)
            { 
       
            CompanyDetailViewModel detailViewModel = new CompanyDetailViewModel()
            {
                Company = company
                               
        };
                return View(detailViewModel);
            }

       
            return View("NotAuthorized");
        }

        //[HttpGet]
        //public IActionResult Details(CompanyDetailViewModel detailModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Board board = new Board
        //        {
        //            Name = detailModel.Name,
        //            Description = detailModel.Description,
        //            CreatedBy = User.Identity.Name,
        //            CreatedDate = DateTime.Now,
        //            CompanyId = detailModel.CompanyID
        //        };
        //        _boardRepository.Create(board);
        //    }

        //    return View(detailModel);
        //}
        //TODO check if this is necessary, normally it's not
        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var company = _companyRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var IsSuperAdmin = User.IsInRole("SuperAdmin");
            
            if (company == null || company.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("CompanyNotFound", id);
            }
            else if (IsSuperAdmin || company.Id == currentuser.CompanyId)
            {   

            var companyEditViewModel = new CompanyEditViewModel
            {
                Id = company.Id,       
                Name = company.Name,
                ExistingPhotoPath = company.PhotoPath
            };

            return View(companyEditViewModel);
            }

            return View("NotAuthorized"); 
                    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CompanyEditViewModel editModel)
        {
         
            if(ModelState.IsValid)
            {
                var company = _companyRepository.GetById(editModel.Id);

                company.Name = editModel.Name;
                company.UpdatedDate = DateTime.Now;
                company.UpdatedBy = User.Identity.Name;
                
                if(editModel.ExistingPhotoPath != null)
                {
                    DeleteImage(editModel.ExistingPhotoPath);
                    company.PhotoPath = ProcessUploadFile(editModel);
                }
                var response = _companyRepository.Update(company);
                
                if(response != null & response.Id != 0)
                {
                    return RedirectToAction("Details", new { id = editModel.Id });
                }
            }

            return View();

          
        }
        //TODO implement error view
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var company = _companyRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var IsSuperAdmin = User.IsInRole("SuperAdmin");

            if (company == null || company.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("CompanyNotFound", id);
            }
            else if (IsSuperAdmin || company.Id == currentuser.CompanyId)
            {
            return View(company);
            }
            return View("Error");
        }

       
        public IActionResult DeleteSure(int id)
        {
            var company = _companyRepository.GetById(id);

            company.IsDeleted = true;
            company.UpdatedBy = User.Identity.Name;
            company.UpdatedDate = DateTime.Now;

            var response = _companyRepository.Delete(company);

            if (response != null && response.Id != 0)
            {
                var BoardsInDeletedCompany = _boardRepository.GetAllBoardsfromcompany(id).ToList();

                foreach (var board in BoardsInDeletedCompany)
                {
                    var listoftasksinboard = board.BoardTasks.ToList();
                    board.IsDeleted = true;
                    board.UpdatedBy = User.Identity.Name;
                    board.UpdatedDate = DateTime.Now;

                    foreach (var task in listoftasksinboard)
                    {
                        task.IsDeleted = true;
                        task.UpdatedBy = User.Identity.Name;
                        task.UpdatedDate = DateTime.Now;
                        _taskRepository.Delete(task);
                    }
                        _boardRepository.Delete(board);
                   
                }


                return RedirectToAction("CompanyList");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AssignEmployees(int companyId)
        {
            ViewBag.companyId = companyId;

            var company = _companyRepository.GetById(companyId);

            if (company == null || company.IsDeleted == true )
            {
                Response.StatusCode = 404;
                return View("CompanyNotFound", companyId);
            }

            var model = new List<AssignEmployeesViewModel>();
            var userList = _companyRepository.GetAllUsersfromCompany(companyId);
            
            foreach (var user in userList)
            {
                var AssignEmployeesModel = new AssignEmployeesViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                                                
                };

                if (user.CompanyId != null)
                {
                    AssignEmployeesModel.IsSelected = true; 
                }
                else
                {
                    AssignEmployeesModel.IsSelected = false;
                }
                


                model.Add(AssignEmployeesModel);

             }
            return View(model);
        }
        //TODO Admin of a company should be able to delete a user( soft delete) SuperAdmin can assign users who register from outside the company as admin

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignEmployeesAsync(List<AssignEmployeesViewModel> model, int companyId)
        {
            var company = _companyRepository.GetById(companyId);

            if (company == null || company.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("CompanyNotFound", companyId);
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);
                IdentityResult result = null;

                if (model[i].IsSelected)
                {
                    user.CompanyId = companyId;
                    result = await _userManager.UpdateAsync(user);
                    
                }
                else if (!model[i].IsSelected)
                {
                    user.CompanyId = null;
                    result = await _userManager.UpdateAsync(user);
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
                        return RedirectToAction("Details", new { id = companyId });
                    }
                }
            }

            return RedirectToAction("Details", new { id = companyId });
      
        }
        //TODO change this return to not authorized

        private void DeleteImage(string photoPath)
        {
            if (photoPath != null)
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", photoPath);
                System.IO.File.Delete(filePath);
            }
        }

        private string ProcessUploadFile(CompanyCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                model.Photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
