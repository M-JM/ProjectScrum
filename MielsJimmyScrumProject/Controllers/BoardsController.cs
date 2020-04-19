using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MielsJimmyScrumProject.ViewModels.BoardsViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;


namespace MielsJimmyScrumProject.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,User")]
    public class BoardsController : Controller
    {
        private readonly IBoardRepository _boardRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<BoardsController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public BoardsController(IBoardRepository boardRepository,ICompanyRepository companyRepository, ITaskRepository taskRepository, ILogger<BoardsController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _boardRepository = boardRepository;
            _companyRepository = companyRepository;
            _taskRepository = taskRepository;
            _logger = logger;
            _userManager = userManager;
        }
     
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> CreateAsync(int companyid)
        {
            
            var company = _companyRepository.GetById(companyid);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);

            if (company == null || company.IsDeleted == true) {
                Response.StatusCode = 404;
                return View("../Companies/CompanyNotFound", companyid);
            }
            else if (User.IsInRole("SuperAdmin") ||
              User.IsInRole("Admin") && companyid == currentuser.CompanyId)

            {
                BoardCreateViewModel boardCreateViewModel = new BoardCreateViewModel()
                {

                    Company = company,

                };
                return View(boardCreateViewModel);
            }
          return View("NotAuthorized");
                        
}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> CreateAsync(BoardCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var IsSuperAdmin = User.IsInRole("SuperAdmin");
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                if (IsSuperAdmin || User.IsInRole("Admin") && model.CompanyId == currentuser.CompanyId) { 

                    model.CreatedDate = DateTime.Now;
                    model.CreatedBy = User.Identity.Name;

                    var response = _boardRepository.Create(model);

                    if (response != null && response.Id != 0)
                    {
                        return RedirectToAction("details", new { id = model.Id });
                    }        
                }
                return View("NotAuthorized");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var board = _boardRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var UserBoards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).Where(x => x.BoardUsers.Any(x => x.ApplicationUserId == currentuser.Id && x.IsDeleted == false)).ToList();

            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", id);
            }
            else if (User.IsInRole("SuperAdmin") ||
                User.IsInRole("Admin") && board.CompanyId == currentuser.CompanyId
                || User.IsInRole("User") && board.CompanyId == currentuser.CompanyId && UserBoards.Contains(board)
                ) { 

                BoardDetailViewModel detailViewModel = new BoardDetailViewModel()
            {
                Board  = board
            };
            return View(detailViewModel);
            }
            return View("NotAuthorized");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var board = _boardRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var IsSuperAdmin = User.IsInRole("SuperAdmin");
            
            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", id);
            }
            else if (IsSuperAdmin || User.IsInRole("Admin") && board.CompanyId == currentuser.CompanyId)
            {
                var boardEditViewModel = new BoardEditViewModel
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
              
            };

            return View(boardEditViewModel);
            }
            //return RedirectToAction("NotAuthorized", "Account");
            return View("NotAuthorized");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UpdateAsync(BoardEditViewModel editModel)
        {
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var IsSuperAdmin = User.IsInRole("SuperAdmin");
            var board = _boardRepository.GetById(editModel.Id);

            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", board.Id);
            }
            else if (IsSuperAdmin || User.IsInRole("Admin") && board.CompanyId == currentuser.CompanyId) { 
                if (ModelState.IsValid)
            {
              
                board.Name = editModel.Name;
                board.Description = editModel.Description;
                board.UpdatedDate = DateTime.Now;
                board.UpdatedBy = User.Identity.Name;

                
                var response = _boardRepository.Update(board);

                if (response != null & response.Id != 0)
                {
                    return RedirectToAction("BoardsList");
                }
            }
            return View();
        }
            return View("NotAuthorized");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var board = _boardRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var IsSuperAdmin = User.IsInRole("SuperAdmin");


            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", id);
            }
            else if (IsSuperAdmin || board.CompanyId == currentuser.CompanyId) { 
                return View(board);
        
        }
            return View("NotAuthorized");
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteSureAsync(int id)
        {
            var board = _boardRepository.GetById(id);
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);

            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", id);
            }
            else if (User.IsInRole("SuperAdmin") || board.CompanyId == currentuser.CompanyId)
            {

            board.IsDeleted = true;
            board.UpdatedBy = User.Identity.Name;
            board.UpdatedDate = DateTime.Now;

            var response = _boardRepository.Delete(board);

            if (response != null && response.Id != 0)
            {
                var TasksinDeletedBoard = _taskRepository.GetAllTasksofBoard(id).ToList();
                var UserAssignedtoBoard = board.BoardUsers.ToList();

                foreach (var user in UserAssignedtoBoard)
                {
                    user.IsDeleted = true;
                    user.UpdatedBy = User.Identity.Name;
                    user.UpdatedDate = DateTime.Now;

                    _boardRepository.RemoveBoardUser(user);
                }

                foreach (var tasks in TasksinDeletedBoard)
                {
                    tasks.IsDeleted = true;
                    tasks.UpdatedBy = User.Identity.Name;
                    tasks.UpdatedDate = DateTime.Now;

                    _taskRepository.Delete(tasks);
                }

                return RedirectToAction("BoardsList");
            }

            return View(board);
        }
            return View("NotAuthorized");
        }
        [HttpGet]
        public async Task<IActionResult> BoardsListAsync()
        {
            
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
          
            try
            {
                if (User.IsInRole("SuperAdmin"))
                {
                    var boardList = _boardRepository.GetAllBoards();
                    return View(boardList);
                }
                else if (User.IsInRole("Admin"))
                {
                    var boardList = _boardRepository.GetAllBoards().Where(x => x.CompanyId == currentuser.CompanyId);
                  
                    return View(boardList);
                }
                else
                {
                    var boardList = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId)
                        .Where(x => x.BoardUsers.Any(x => x.ApplicationUserId == currentuser.Id))
                        .ToList();

                    return View(boardList);
                }
            }
            catch (Exception ex )
            {

                return View("error", ex);
            }
          
            }
        

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult AssignUsers(int boardId)
        {
            ViewBag.boardId = boardId;
            // send the boardid via viewbag since we cannot retrieve the boardid via the list given to the model.

            var board = _boardRepository.GetById(boardId);

            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", boardId);
            }


            var model = new List<AssignUsersViewModel>();
            var userList = _companyRepository.GetAllCompanyUsers(board.CompanyId).ToList();

            foreach (var user in userList)
            {
                // check if exists and is true == IsSelected moet ingevuld
                var IsAssigned = _boardRepository.FindBoardUser(boardId, user.Id) ;
               
                if(IsAssigned != null) { 

               var AssignUserModel = new AssignUsersViewModel()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        IsSelected = !IsAssigned.IsDeleted 
                };
                    model.Add(AssignUserModel);
                }
                else { 
            var Usermodel = new AssignUsersViewModel()
            {
                
                UserId = user.Id,
                UserName = user.UserName,
                IsSelected = false
            };
            model.Add(Usermodel);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> AssignUsersAsync(List<AssignUsersViewModel> model, int boardId)
        {
            var board = _boardRepository.GetById(boardId);

            if (board == null || board.IsDeleted == true)
            {
                Response.StatusCode = 404;
                return View("BoardNotFound", boardId);
            }

            for (int i = 0; i < model.Count(); i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);
                var Exists = _boardRepository.FindBoardUser(boardId, user.Id);
                var ExistingBoardUser = _boardRepository.FindBoardUserById(boardId, user.Id);

                 BoardUser boardsuser = new BoardUser
                {
                    BoardId = boardId,
                    Board = board,
                    ApplicationUserId = user.Id,
                    ApplicationUser = user,
                    CreatedBy = User.Identity.Name,
                    CreatedDate = DateTime.Now
                   
                };

                // is selected but does not exist CREATE
                if (model[i].IsSelected && Exists == null)
                {

                    _boardRepository.AssignBoardUser(boardsuser);
                }
                // is not selected and exist then update to delete
                else if (!model[i].IsSelected && Exists != null)
                {
                    ExistingBoardUser.IsDeleted = true;
                    ExistingBoardUser.UpdatedBy = User.Identity.Name;
                    ExistingBoardUser.UpdatedDate = DateTime.Now;
                    _boardRepository.UpdateBoardUser(ExistingBoardUser);

                }
                else if (model[i].IsSelected && Exists != null)
                // is selected and exists but is false
                {
                    ExistingBoardUser.IsDeleted = false;
                    ExistingBoardUser.UpdatedBy = User.Identity.Name;
                    ExistingBoardUser.UpdatedDate = DateTime.Now;
                    _boardRepository.UpdateBoardUser(ExistingBoardUser);
                }

                _logger.LogInformation("NO changes to the assigned user");       
            }

            return RedirectToAction("Details", new {id = boardId });
        }
    }

}


// Exists in Db and is checked => do nothing 

// is not selected and exist then update to delete
//if (model[i].IsSelected && Exists.IsDeleted == false)
//{
//    if (!model[i].IsSelected && Exists.IsDeleted == false)
//    {
//        ExistingBoardUser.IsDeleted = true;
//        goto Test;
//    }
//    else if (model[i].IsSelected && Exists.IsDeleted == true)
//    // is selected and exists but is false
//    {
//        ExistingBoardUser.IsDeleted = false;
//        goto Test;
//    }

//    _boardRepository.AssignBoardUser(boardsuser);
//    goto Test1;

//    Test:

//    ExistingBoardUser.UpdatedBy = User.Identity.Name;
//    ExistingBoardUser.UpdatedDate = DateTime.Now;
//    _boardRepository.UpdateBoardUser(ExistingBoardUser);

//    _logger.LogInformation("User's assignment to board was modified");

//    Test1:

//  _logger.LogInformation("User's assignment to board was created");
//}

// is geslecteerd, niet bestaat, toevoegen
// is niet geselecteerd, bestaat, verwijderen
// is geselecteerd, bestaat in DB maar op False, aanpassen