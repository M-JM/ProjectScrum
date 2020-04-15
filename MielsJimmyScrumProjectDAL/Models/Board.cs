using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Models
{
    public class Board
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

       public List<BoardTask> BoardTasks{ get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Company")]

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual List<BoardUser> BoardUsers { get; set; }

    }
}
