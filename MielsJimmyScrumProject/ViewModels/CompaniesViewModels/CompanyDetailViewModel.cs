using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MielsJimmyScrumProject.ViewModels.CompaniesViewModels
{
    public class CompanyDetailViewModel
    {
        public Company Company { get; set; }

        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
