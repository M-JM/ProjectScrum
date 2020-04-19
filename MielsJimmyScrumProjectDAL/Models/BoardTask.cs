using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace MielsJimmyScrumProjectDAL.Models
{
    public class BoardTask
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public ScrumTaskStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Board")]

        public int BoardId { get; set; }

        public virtual Board Board { get; set; }

        [ForeignKey("ApplicationUser")]

        public string Userid { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
