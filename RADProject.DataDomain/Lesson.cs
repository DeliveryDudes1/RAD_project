using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonID { get; set; }

        [ForeignKey("associatedModule")]
        public int ModuleID { get; set; }
        //lecturerid from link and students
        //forgien keys
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual Module associatedModule { get; set; }
    }
}
