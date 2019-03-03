using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDomain.Classes.ClubModels
{
    public class Student
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<Course> StudentCourses { get; set; }
    }
}
