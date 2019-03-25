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
        void Save();
    }
}