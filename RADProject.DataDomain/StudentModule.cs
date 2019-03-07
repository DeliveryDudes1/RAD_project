using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("StudentModules")]
    class StudentModule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("associatedStudent")]
        public int StudentID { get; set; }
        [ForeignKey("associatedModule")]
        public int ModuleID { get; set; }
        public virtual Student associatedStudent { get; set; }
        public virtual Module associatedModule { get; set; }
    }
}
