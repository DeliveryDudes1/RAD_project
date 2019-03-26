using RADProject.DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Data_Abstraction_Layer
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Module> GetAllModules(string StudentID);
        IEnumerable<Attendance> GetAllAttendance(string StudentID);
        IEnumerable<AssignmentResult> GetAllResults(string StudentID);

        void Save();
    }
}