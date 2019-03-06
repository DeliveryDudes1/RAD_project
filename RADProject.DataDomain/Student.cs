using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Display(Name = "StudentID")]
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<Course> StudentCourses { get; set; }

        public override string ToString()
        {
            return StudentID + " " + FirstName + " " + SecondName;
        }
    }
}
