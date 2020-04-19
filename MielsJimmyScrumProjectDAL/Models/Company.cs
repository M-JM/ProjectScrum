using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Models
{
  public  class Company
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]  
        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public List<ApplicationUser> Employees { get; set; }

    }
}
