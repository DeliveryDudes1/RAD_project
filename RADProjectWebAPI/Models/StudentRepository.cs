using RADProject.DataDomain;
using RADProjectWebAPI.Data_Abstraction_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Models
{
    public class StudentRepository : IStudentRepository
    {
        StudentAssigmentContext db = new StudentAssigmentContext();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attendance> GetAllAttendance(string StudentID)
        {
            var x = from a in db.Attendances
                    where a.StudentID == StudentID
                    select a;

            return x.ToList();
        }

        public IEnumerable<Module> GetAllModules(string StudentID)
        {
            var x = from m in db.Modules
                    join sm in db.StudentModules
                    on m.ModuleID equals sm.ModuleID
                    where sm.StudentID == StudentID
                    select m;

            return x.ToList();
        }

        public IEnumerable<AssignmentResult> GetAllResults(string StudentID)
        {
            var x = from r in db.AssignmentResults
                    where r.StudentID == StudentID
                    select r;

            return x.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}