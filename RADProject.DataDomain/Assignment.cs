using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("Assignments")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentID { get; set; }

        [ForeignKey("associatedModule")]
        public int ModuleID { get; set; }
        //public ICollection<Student> Students { get; set; }
        public string Name { get; set; }
        //lectuere id

        
        public virtual Module associatedModule { get; set; }
    }
}
