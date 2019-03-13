using RADProject.DataDomain;
using RADProject.DataDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Data_Abstraction_Layer
{
    public interface IAdminRepository : IDisposable
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Module> GetAllModule();
        IEnumerable<Lecturer> GetAllLecturer();

        void AssignStudentToModule(StudentModuleDTO studentModuleDTO);
        void AssignLecturerToModule(Lecturer item);

        void Save();
    }
}