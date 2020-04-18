using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MielsJimmyScrumProject.ViewModels.TasksViewModels
{
    public class TaskCreateViewModel : BoardTask
    {
        public List<BoardUser> AvailableUsers { get; set; }

        public int CompanyId{ get; set; }

    }
}
