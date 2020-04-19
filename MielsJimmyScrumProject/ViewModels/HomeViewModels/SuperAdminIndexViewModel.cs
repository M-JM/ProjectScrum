using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MielsJimmyScrumProject.ViewModels.HomeViewModels
{
    public class SuperAdminIndexViewModel
    {
        public IEnumerable<Board> boards;
        public IEnumerable<Company> Companies;
        public IEnumerable<ApplicationUser> Users;


    }
}
