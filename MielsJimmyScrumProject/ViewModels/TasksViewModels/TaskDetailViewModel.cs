using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MielsJimmyScrumProject.ViewModels.TasksViewModels
{
    public class TaskDetailViewModel
    {
        public int BoardId { get; set; }
        public string BoardName { get; set; }

       public IEnumerable<BoardTask> TodoTasks { get; set; }
       public IEnumerable<BoardTask> DoingTasks { get; set; }
       public IEnumerable<BoardTask> DoneTasks { get; set; }
    }
}
