using Microsoft.AspNetCore.Http;
using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MielsJimmyScrumProject.ViewModels.CompaniesViewModels
{
    public class CompanyCreateViewModel : Company
    {
        public IFormFile Photo { get; set; }

    }
}
