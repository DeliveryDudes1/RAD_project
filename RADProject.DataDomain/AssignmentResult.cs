using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("Results")]
    public class AssignmentResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultID { get; set; }
        [ForeignKey("associatedAssignment")]
        public int AssignmentID { get; set; }
        // public int ModuleID { get; set; }
        [ForeignKey("associatedStudent")]
        public string StudentID { get; set; }
        //mark
        public int Mark { get; set; }

        public virtual Student associatedStudent { get; set; }
        public virtual Assignment associatedAssignment { get; set; }
       
    }
}
