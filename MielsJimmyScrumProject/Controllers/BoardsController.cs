using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MielsJimmyScrumProject.ViewModels.BoardsViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;
//test
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MielsJimmyScrumProject.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,User")]
    public class BoardsController : Controller
    {
        private readonly IBoardRepository _BoardRepository;
        private readonly ICompanyRepository _CompanyRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<ApplicationUser> _UserManager;

        public BoardsController(IBoardRepository boardRepository,ICompanyRepository companyRepository, ITaskRepository taskRepository,
            UserManager<ApplicationUser> userManager)
        {
            _BoardRepository = boardRepository;
            _CompanyRepository = companyRepository;
            _taskRepository = taskRepository;
            _UserManager = userManager;
        }
     
        [HttpGet]
        public IActionResult Create(int companyid)
        {

            var company = _CompanyRepository.GetById(companyid);
           
            BoardCreateViewModel boardCreateViewModel = new BoardCreateViewModel()
            {
                        
                Company = company,
                                        
            };

            return View(boardCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BoardCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
             
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = User.Identity.Name;
                   
                }

                var response = _BoardRepository.Create(model);

                if (response != null && response.Id != 0)
                {
                    return RedirectToAction("details", new { id = model.Id });
                }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var board = _BoardRepository.GetById(id);

            BoardDetailViewModel detailViewModel = new BoardDetailViewModel()
            {
                Board  = board
            };
            return View(detailViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var board = _BoardRepository.GetById(id);

            var boardEditViewModel = new BoardEditViewModel
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
              
            };

            return View(boardEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(BoardEditViewModel editModel)
        {

            if (ModelState.IsValid)
            {
                var board = _BoardRepository.GetById(editModel.Id);

                board.Name = editModel.Name;
                board.Description = editModel.Description;
                board.UpdatedDate = DateTime.Now;
                board.UpdatedBy = User.Identity.Name;

                
                var response = _BoardRepository.Update(board);

                if (response != null & response.Id != 0)
                {
                    return RedirectToAction("BoardsList");
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var board = _BoardRepository.GetById(id);

            return View(board);
        }

        public IActionResult DeleteSure(int id)
        {
            var board = _BoardRepository.GetById(id);

            board.IsDeleted = true;

            var response = _BoardRepository.Delete(board);

            if (response != null && response.Id != 0)
            {
                var TasksinDeletedBoard = _taskRepository.GetAllTasksofBoard(id).ToList();

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

        public IActionResult BoardsList()
        {
            var boardList = _BoardRepository.GetAllBoards();
            return View(boardList);
        }

        [HttpGet]
        public IActionResult AssignUsers(int boardId)
        {
            ViewBag.boardId = boardId;
            // send the boardid via viewbag since we cannot retrieve the boardid via the list given to the model.

            var board = _BoardRepository.GetById(boardId);

            if (board == null)
            {
                //return RedirectToAction("HttpStatusCodeHandler", "ErrorController");
            }


            var model = new List<AssignUsersViewModel>();
            var userList = _CompanyRepository.GetAllCompanyUsers(board.CompanyId).ToList();

            foreach (var user in userList)
            {
                var IsAssigned = _BoardRepository.FindBoardUser(boardId, user.Id);
                var AssignUserModel = new AssignUsersViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = IsAssigned,
                };
                             
               model.Add(AssignUserModel);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignUsersAsync(List<AssignUsersViewModel> model, int boardId)
        {
            var board = _BoardRepository.GetById(boardId);

            if (board == null)
            {
                //return RedirectToAction("HttpStatusCodeHandler", "ErrorController");
            }

            for (int i = 0; i < model.Count(); i++)
            {
                var user = await _UserManager.FindByIdAsync(model[i].UserId);
                var Exists = _BoardRepository.FindBoardUser(boardId, user.Id);
                var ExistingBoardUser = _BoardRepository.FindBoardUserById(boardId, user.Id);
                BoardUser boardsuser = new BoardUser
                {
                    BoardId = boardId,
                    Board = board,
                    ApplicationUserId = user.Id,
                    ApplicationUser = user
                };

                if (model[i].IsSelected && Exists.Equals(false))
                {
                    _BoardRepository.AssignBoardUser(boardsuser);

                }
                else if (!model[i].IsSelected && Exists.Equals(true))
                {
                    _BoardRepository.RemoveBoardUser(ExistingBoardUser);
                }
              
            }

            return RedirectToAction("Details", new {id = boardId });
        }
    }


}
