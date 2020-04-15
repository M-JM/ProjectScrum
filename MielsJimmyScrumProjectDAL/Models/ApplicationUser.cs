using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Models
{
   public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public virtual Company Company { get; set; }

        public virtual List<BoardUser> BoardUser  { get; set; }



    }
}
