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
        public DbSet<LecturerModule> LecturerModules { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<AssignmentResult> AssignmentResults { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public StudentAssigmentContext() : base("StudentAssignment")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new StudentAssignmentInitialzer());
            Database.Initialize(true);
            

        }
    }
}
