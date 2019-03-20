using RADProject.DataDomain;
using RADProject.DataDomain.DTO;
using RADProjectWebAPI.Data_Abstraction_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Models
{

    public class AdminRepository : IAdminRepository
    {
       
        //ApplicationDbContext appdb = new ApplicationDbContext();
        StudentAssigmentContext db = new StudentAssigmentContext();

        public void AssignLecturerToModule(LecturerModuleDTO lecturerModuleDTO)
        {
            LecturerModule lm = new LecturerModule
            {
                LecturerID = lecturerModuleDTO.LecturerID,
                ModuleID = lecturerModuleDTO.ModuleID
            };
            db.LecturerModules.Add(lm);
            //throw new NotImplementedException();
        }

        public void AssignStudentToModule(StudentModuleDTO studentModuleDTO)
        {
            StudentModule sm = new StudentModule { StudentID= studentModuleDTO.StudentID,
                ModuleID =studentModuleDTO.ModuleID };
            db.StudentModules.Add(sm);
            // throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lecturer> GetAllLecturer()
        {
            return db.Lecturers;
            //throw new NotImplementedException();
        }

        public IEnumerable<Module> GetAllModule()
        {
            return db.Modules;
            //throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.Students;
            //throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}