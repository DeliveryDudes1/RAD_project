using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    class StudentAssigmentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StudentAssigmentContext() : base("StudentAssignment")
        {
            Database.SetInitializer(new StudentAssignmentInitialzer());
            Database.Initialize(true);
        }
    }
}
