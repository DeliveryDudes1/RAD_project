using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendaceID { get; set; }
        //public int ModuleID { get; set; }
        [ForeignKey("associatedLesson")]
        public int LessonID { get; set; }
        [ForeignKey("associatedStudent")]
        public string StudentID { get; set; }
        //bool yes no
        //lecturer id
        //bool attednecace

        public virtual Student associatedStudent { get; set; }
       
    }
}
