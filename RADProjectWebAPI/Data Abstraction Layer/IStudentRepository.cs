using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Data_Abstraction_Layer
{
    public interface IStudentRepository : IDisposable
    {

        void Save();
    }
}