﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MielsJimmyScrumProject.ViewModels.TasksViewModels;
using MielsJimmyScrumProjectDAL.Models;
using MielsJimmyScrumProjectDAL.Repositories;

namespace MielsJimmyScrumProject.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,User")]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<TasksController> _logger;

        public TasksController(
            ITaskRepository taskRepository, 
            IBoardRepository boardRepository, 
            UserManager<ApplicationUser> userManager,
            ILogger<TasksController> logger
            )
        {
            _taskRepository = taskRepository;
            _boardRepository = boardRepository;
            _userManager = userManager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> CreateAsync(int boardid)
        {

            try
            {
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);
                var board = _boardRepository.GetById(boardid);
                var BoardUser = _boardRepository.GetUsersofBoard(boardid).ToList();

                if (board == null || board.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("../Boards/BoardNotFound", boardid);
                }
                else if (User.IsInRole("SuperAdmin") || currentuser.CompanyId == board.CompanyId)
                {
                    var taskCreateViewModel = new TaskCreateViewModel()
                    {
                        BoardId = board.Id,
                        Board = board,
                        CompanyId = board.CompanyId,
                        AvailableUsers = BoardUser
                    };
                    return View(taskCreateViewModel);
                }
                return View("NotAuthorized");
            }
            catch (Exception ex )
            {

                _logger.LogError(ex, $"When getting the create form.");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(TaskCreateViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                    if (User.IsInRole("SuperAdmin") || currentuser.CompanyId == model.CompanyId)
                    {

                        model.CreatedDate = DateTime.Now;
                        model.CreatedBy = User.Identity.Name;

                        var response = _taskRepository.Create(model);

                        if (response != null && response.Id != 0)
                        {
                            return RedirectToAction("Details", new { taskid = model.Id });
                        }

                        return View(model);

                    }
                    return View("NotAuthorized");
                }
                // error
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When creaating tasks.");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(int taskid)
        {

            try
            {
                var task = _taskRepository.GetById(taskid);
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                if (task == null || task.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("TaskNotFound", taskid);
                }
                else if (
                    User.IsInRole("SuperAdmin") ||
                    task.Userid == currentuser.Id ||
                    User.IsInRole("Admin") && task.Board.CompanyId == currentuser.CompanyId
                    )
                {
                    var detailViewModel = new TaskEditViewModel()
                    {
                        Board = task.Board,
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        Status = task.Status,
                        CreatedBy = task.CreatedBy,
                        CreatedDate = task.CreatedDate,
                        BoardId = task.BoardId,
                        AssginedUser = task.ApplicationUser.UserName

                    };
                    return View(detailViewModel);
                }
                return View("NotAuthorized");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"When getting task.");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> TaskListAsync(int boardId)
        {

            try
            {

                var board = _boardRepository.GetById(boardId);
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);
                var Exists = _boardRepository.FindBoardUser(boardId, currentuser.Id);
                if (board == null || board.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("../Boards/BoardNotFound", boardId);
                }
                else if (
                  User.IsInRole("SuperAdmin") ||
                  board.CompanyId == currentuser.CompanyId && Exists != null ||
                  User.IsInRole("Admin") && board.CompanyId == currentuser.CompanyId
                  )
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
                return View("NotAuthorized");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When getting taskslist.");
                throw;
              
            }
        }
   
        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int taskid)
        {
            try
            {
                var task = _taskRepository.GetById(taskid);
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);
                var BoardUser = _boardRepository.GetUsersofBoard(task.BoardId).ToList();

                if (task == null || task.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("TaskNotFound", taskid);
                }
                else if (
                    User.IsInRole("SuperAdmin") ||
                    task.Userid == currentuser.Id ||
                    User.IsInRole("Admin") && task.Board.CompanyId == currentuser.CompanyId
                    )
                {
                    var taskEditViewModel = new TaskEditViewModel
                    {

                        BoardId = task.BoardId,
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        Status = task.Status,
                        UpdatedBy = User.Identity.Name,
                        UpdatedDate = DateTime.Now,
                        AvailableUsers = BoardUser,
                        AssginedUser = task.ApplicationUser.UserName

                    };

                    return View(taskEditViewModel);
                }
                return View("NotAuthorized");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When getting the task for updating .");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(TaskEditViewModel editModel)
        {
            try
            {
                var task = _taskRepository.GetById(editModel.Id);
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                if (task == null || task.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("TaskNotFound", editModel.Id);
                }
                else if (
                    User.IsInRole("SuperAdmin") ||
                    task.Userid == currentuser.Id ||
                    User.IsInRole("Admin") && task.Board.CompanyId == currentuser.CompanyId
                    )
                {

                    if (ModelState.IsValid)
                    {

                        task.Title = editModel.Title;
                        task.Description = editModel.Description;
                        task.Status = editModel.Status;
                        task.UpdatedDate = DateTime.Now;
                        task.UpdatedBy = User.Identity.Name;
                        task.Userid = editModel.Userid;


                        var response = _taskRepository.Update(task);

                        if (response != null & response.Id != 0)
                        {
                            return RedirectToAction("taskList", new { boardid = task.BoardId });
                        }
                        return View();
                    }
                }
                return View("NotAuthorized");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When updating task.");
                throw;
                
            }
        }
            
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int taskid)
        {
            try
            {
                var task = _taskRepository.GetById(taskid);
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                if (task == null || task.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("TaskNotFound", taskid);
                }
                else if (
                    User.IsInRole("SuperAdmin") ||
                    task.Userid == currentuser.Id ||
                    User.IsInRole("Admin") && task.Board.CompanyId == currentuser.CompanyId
                    )
                {

                    return View(task);
                }
                return View("NotAuthorized");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When getting task for deleting.");
                throw;
            }
        }

        public async Task<IActionResult> DeleteSureAsync(int taskid)
        {
            try
            {
                var task = _taskRepository.GetById(taskid);
                var currentuser = await _userManager.GetUserAsync(HttpContext.User);

                if (task == null || task.IsDeleted == true)
                {
                    Response.StatusCode = 404;
                    return View("TaskNotFound", taskid);
                }
                else if (
                    User.IsInRole("SuperAdmin") ||
                    task.Userid == currentuser.Id ||
                    User.IsInRole("Admin") && task.Board.CompanyId == currentuser.CompanyId
                    )
                {

                    task.IsDeleted = true;
                    task.UpdatedBy = User.Identity.Name;
                    task.UpdatedDate = DateTime.Now;

                    var response = _taskRepository.Update(task);

                    if (response != null && response.Id != 0)
                    {
                        return RedirectToAction("taskList", new { boardid = task.BoardId });
                    }


                    return View("error");
                }
                return View("NotAuthorized");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When deleting task.");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserTasklistAsync()
         {

            //TODO check if parameter tampering is possible here?
            try
            {

                var currentuser = await _userManager.GetUserAsync(HttpContext.User);
                // var boards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).ToList();
                var UserBoards = _boardRepository.GetAllBoardsfromcompany(currentuser.CompanyId).Where(x => x.BoardUsers.Any(x => x.ApplicationUserId == currentuser.Id)).ToList();


                var userTaskListViewModel = new UserTaskListViewModel
                {
                    Boards = UserBoards

                };

                return View(userTaskListViewModel);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"When retrieving the task list of a specific user.");
                throw;
            }
    }

}
}