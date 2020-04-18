using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MielsJimmyScrumProjectDAL.Context;
using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CompanyRepository> _logger;

        public TaskRepository(AppDbContext context, ILogger<CompanyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public BoardTask Create(BoardTask task)
        {
            try
            {
                if (task != null)
                {
                    var newTaskEntityEntry = _context.Tasks.Add(task);

                    if (newTaskEntityEntry != null &&
                        newTaskEntityEntry.State == EntityState.Added)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {task.Title} was created.");
                            return newTaskEntityEntry.Entity;
                        }
                    }
                }

                _logger.LogInformation($"The task given as null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When creating a task Failed.");
                throw;
            }
        }

        public BoardTask Delete(BoardTask task)
        {
            try
            {
               
                if (task != null)
                {
                    var DeletedTaskEntityEntry = _context.Tasks.Update(task);

                    if (DeletedTaskEntityEntry != null &&
                        DeletedTaskEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {task.Title} was soft deleted.");
                            return DeletedTaskEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogInformation($"The task given as null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When deleting the task Failed.");
                throw;
            }
        }

        public IEnumerable<BoardTask> GetAllTasksofBoard(int boardid)
        {
            var AllTasks = _context.Tasks.Where(t => t.BoardId == boardid && t.IsDeleted == false);

            return AllTasks;
        }

        public IEnumerable<BoardTask> GetAllToDoTask(int boardid)
        {
            var Todo = _context.Tasks.Where(t => t.Status == ScrumTaskStatus.ToDo && t.BoardId == boardid && t.IsDeleted != true ).Include(x => x.ApplicationUser);

            return Todo;
        }

        public IEnumerable<BoardTask> GetAllDoingTask(int boardid)
        {
            var Doing = _context.Tasks.Where(t => t.Status == ScrumTaskStatus.Doing && t.BoardId == boardid && t.IsDeleted != true).Include(x => x.ApplicationUser);

            return Doing;
        }

        public IEnumerable<BoardTask> GetAllDoneTask(int boardid)
        {
            var Done = _context.Tasks.Where(t => t.Status == ScrumTaskStatus.Done && t.BoardId == boardid && t.IsDeleted != true).Include(x => x.ApplicationUser);

            return Done;
        }

        public BoardTask GetById(int id)
        {
            var task = _context.Tasks.Include(x => x.Board).FirstOrDefault(x => x.Id == id);
            return task;
        }

        public ApplicationUser GetCurrentUserId(string username)
        {
            var currentUser = _context.Users.Where(e => e.UserName == username).FirstOrDefault();
            return currentUser;
        }

        public BoardTask Update(BoardTask task)
        {
            try
            {
                if (task != null)
                {
                    var updateTaskEntityEntry = _context.Tasks.Update(task);

                    if (updateTaskEntityEntry != null &&
                        updateTaskEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {task.Title} was updated.");
                            return updateTaskEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogInformation($"The task given as null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When updating a task Failed.");
                throw;
            }
        }
    }
}
