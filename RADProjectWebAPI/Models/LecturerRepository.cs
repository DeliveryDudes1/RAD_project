using RADProject.DataDomain;
using RADProject.DataDomain.DTO;
using RADProjectWebAPI.Data_Abstraction_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Models
{
    public class LecturerRepository : ILecturerRepository
    {
        StudentAssigmentContext db = new StudentAssigmentContext();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> GetAllModules(int LecturerID)
        {
            var x = from m in db.Modules
                    join lm in db.LecturerModules
                    on m.ModuleID equals lm.ModuleID
                    where lm.LecturerID == LecturerID
                    select m;

            return x.ToList();

        }

        public void MakeAssignment(AssignmentDTO assignmentDTO)
        {
            Assignment assign = new Assignment
            {
               Name = assignmentDTO.Name,
               ModuleID = assignmentDTO.ModuleID
            };
            db.Assignments.Add(assign);
        }

        public void RecordAssigmentResult(ResultsDTO resultsDTO)
        {
            AssignmentResult res = new AssignmentResult
            {
                AssignmentID = resultsDTO.AssignmentID,
                StudentID = resultsDTO.StudentID,
                Mark = resultsDTO.Mark
            };
            db.AssignmentResults.Add(res);
        }

        public void RecordAttendance(AttendaceDTO attendaceDTO)
        {
            Attendance att = new Attendance
            {
                LecturerID = attendaceDTO.LessonID,
                StudentID = attendaceDTO.StudentID,
                Present =attendaceDTO.Present
            };
            db.Attendances.Add(att);
        }

        public void Save()
        {
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}