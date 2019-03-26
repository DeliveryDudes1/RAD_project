using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain.DTO
{
    public class AttendaceDTO
    {
        public int LessonID { get; set; }
      
        public string StudentID { get; set; }

        public bool Present { get; set; }
    }
}
