using RADProject.DataDomain;
using RADProject.DataDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Data_Abstraction_Layer
{
    public interface ILecturerRepository : IDisposable
    {
        void MakeAssignment(AssignmentDTO assignmentDTO);
        IEnumerable<Module> GetAllModules(int LecturerID);
        void RecordAttendance(AttendaceDTO attendaceDTO);
        void RecordAssigmentResult(ResultsDTO resultsDTO);

        void Save();
    }
}