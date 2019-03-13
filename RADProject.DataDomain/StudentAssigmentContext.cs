using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    public class StudentAssigmentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }

        public StudentAssigmentContext() : base("StudentAssignment")
        {
            Database.SetInitializer(new StudentAssignmentInitialzer());
            Database.Initialize(true);
        }
    }
}
