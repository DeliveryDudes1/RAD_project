using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDomain.Classes.ClubModels
{
    public class Course
    {

        public string Code { get; set; }
 
        public string year { get; set; }
        public string Desription { get; set; }

        public virtual ICollection<Student> CourseStudents { get; set; } 

        
    }
}
