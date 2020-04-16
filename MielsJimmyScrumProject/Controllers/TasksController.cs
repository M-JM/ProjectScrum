using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MielsJimmyScrumProject.ViewModels.TasksViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;

namespace MielsJimmyScrumProject.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TasksController(ITaskRepository taskRepository, IBoardRepository boardRepository, UserManager<ApplicationUser> userManager)
        {
            _taskRepository = taskRepository;
            _boardRepository = boardRepository;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Create(int boardid)
        {
                        
            var board = _boardRepository.GetById(boardid);

            var taskCreateViewModel = new TaskCreateViewModel()
            {
                BoardId = board.Id,
                Board = board            
            };

            return View(taskCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskCreateViewModel model)
        {

            var user = _taskRepository.GetCurrentUserId(HttpContext.User.Identity.Name);
            if (ModelState.IsValid)
            {
                
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = User.Identity.Name;
                model.Userid = user.Id;
            }

            var response = _taskRepository.Create(model);

            if (response != null && response.Id != 0)
            {
                return RedirectToAction("BoardsList","Boards");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int taskid)
        {
          
            var task = _taskRepository.GetById(taskid);

            var detailViewModel = new TaskEditViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedBy = task.CreatedBy,
                CreatedDate =task.CreatedDate,
                BoardId = task.BoardId

            };
            return View(detailViewModel);
        }

        [HttpGet]
        public IActionResult TaskList(int boardId)
        {
            var board = _boardRepository.GetById(boardId);

            if (board != null)
            {

                var detailViewModel = new TaskDetailViewModel
                {

                    BoardId = board.Id,
                    BoardName = board.Name,
                    TodoTasks = _taskRepository.GetAllToDoTask(boardId),
                    DoingTasks = _taskRepository.GetAllDoingTask(boardId),
                    DoneTasks = _taskRepository.GetAllDoneTask(boardId)

                };
                return View(detailViewModel);
            }
            Response.StatusCode = 404;
            return View("../Boards/BoardNotFound", boardId);
        }


        [HttpGet]
        public IActionResult Update(int taskid)
        {
            var task = _taskRepository.GetById(taskid);

            var taskEditViewModel = new TaskEditViewModel
            {

                BoardId = task.BoardId,
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                UpdatedBy = User.Identity.Name,
                UpdatedDate = DateTime.Now
             };

            return View(taskEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TaskEditViewModel editModel)
        {

            if (ModelState.IsValid)
            {
                var task = _taskRepository.GetById(editModel.Id);

                task.Title = editModel.Title;
                task.Description = editModel.Description;
                task.Status = editModel.Status;
                task.UpdatedDate = DateTime.Now;
                task.UpdatedBy = User.Identity.Name;


                var response = _taskRepository.Update(task);

                if (response != null & response.Id != 0)
                {
                    return RedirectToAction("taskList", new { boardid = task.BoardId });
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = _taskRepository.GetById(taskid);

            return View(task);
        }

  
        public IActionResult DeleteSure(int taskid)
        {
            var task = _taskRepository.GetById(taskid);

            task.IsDeleted = true;
            task.UpdatedBy = User.Identity.Name;
            task.UpdatedDate = DateTime.Now;

            var response = _taskRepository.Update(task);

            if (response != null && response.Id != 0)
            {
                return RedirectToAction("taskList",new { boardid = task.BoardId });
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> UserTasklistAsync()
         {
            var currentuser = await _userManager.GetUserAsync(HttpContext.User);
            var test = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).ToList();
            //var boards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).Where(x => x.BoardUsers.Any(x => x.ApplicationUser == currentuser)).ToList();
            //var boards2 = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).Where(x => x.BoardUsers.FindAll(x.BoardUsers.ApplicationUser.Id == currentuser.Id)).ToList();

            var query = from board in test
                        where board.BoardUsers.Any(x => x.ApplicationUserId == currentuser.Id)
                        select board;

            var Test2 = test.Where(x => x.BoardUsers.Any(x => x.ApplicationUserId == currentuser.Id)).ToList();

            var tasksDoing = Test2.Where(x => x.BoardTasks.Any(x => x.Status == ScrumTaskStatus.Doing)).ToList();

            var userTaskListViewModel = new UserTaskListViewModel
            {
               Boards = query.ToList()
               // Boards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).Where(x => x.BoardUsers.All(x => x.ApplicationUser != currentuser)).ToList()
            };
    
            return View(userTaskListViewModel);
    }

}
}