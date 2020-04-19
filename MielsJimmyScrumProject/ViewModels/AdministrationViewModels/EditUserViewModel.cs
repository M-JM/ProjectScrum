using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MielsJimmyScrumProject.ViewModels.AdministrationViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
       
            Roles = new List<string>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Email must be a valid Address Email.")]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
        
        public IList<string> Roles { get; set; }

        public List<IdentityRole> AllRoles { get; set; }
        [Required]
        public string NewRole { get; set; }
    }
}
