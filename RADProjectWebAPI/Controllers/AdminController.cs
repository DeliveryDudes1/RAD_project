using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using RADProjectWebAPI.Models;
using System.Web.Http;
using System.Web.Mvc;
using RADProject.DataDomain;
using RADProject.DataDomain.DTO;

namespace RADProjectWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        AdminRepository db = new AdminRepository();

        [System.Web.Http.HttpPost]
        public void AssignStudentToModule(StudentModuleDTO studentModuleDTO)
        {
            if (ModelState.IsValid)
            {
                db.AssignStudentToModule(studentModuleDTO);
                db.Save();
            }
      
        }
        public IEnumerable<Lecturer> GetLecturer()
        {
            return db.GetAllLecturer();
        }
    }
}