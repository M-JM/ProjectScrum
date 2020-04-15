using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Models
{
    public class BoardUser
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("Board")]
        public int BoardId { get; set; }
        
        public virtual Board Board { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
