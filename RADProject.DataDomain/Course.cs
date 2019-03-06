using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Column(Order = 1)]
        public string Code { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Year { get; set; }
        public string Desription { get; set; }

        public virtual ICollection<Student> CourseStudents { get; set; }

        public override string ToString()
        {
            return Code + " " + Year + " " + Desription;
        }


    }
}
