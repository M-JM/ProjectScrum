using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Repositories
{
    public interface ITaskRepository
    {


        //INTERFACE OF CRUD OPERATIONS METHODS Defined in Repository.

        // READ
        BoardTask GetById(int id);
        ApplicationUser GetCurrentUserId(string username);

        IEnumerable<BoardTask> GetAllToDoTask(int boardid);
        IEnumerable<BoardTask> GetAllDoingTask(int boardid);
        IEnumerable<BoardTask> GetAllDoneTask(int boardid);
        IEnumerable<BoardTask> GetAllTasksofBoard(int boardid);

        // CREATE

        BoardTask Create(BoardTask task);

        // DELETE

        BoardTask Delete(BoardTask task);

        // UPDATE

        BoardTask Update(BoardTask task);

    }
}
