﻿using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MielsJimmyScrumProject.ViewModels.HomeViewModels
{
    public class AdminIndexViewModel
    {
        public Company company;
        public IEnumerable<Board> boards;
              
    }
}
