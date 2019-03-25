using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using RADProjectWebAPI.Models;
using System.Web.Http;
//using System.Web.Mvc;
using RADProject.DataDomain;
using RADProject.DataDomain.DTO;

namespace RADProjectWebAPI.Controllers
{
    [System.Web.Http.Authorize(Roles = "Lecturer")]
    [RoutePrefix("api/lecturer")]
    public class LecturerController : ApiController
    {
        AdminRepository db = new AdminRepository();

        //post student module
        [System.Web.Http.HttpPost]
        [Route("AssignStudentToModule")]
        public void AssignStudentToModule(StudentModuleDTO studentModuleDTO)
        {
            if (ModelState.IsValid)
            {
                db.AssignStudentToModule(studentModuleDTO);
                db.Save();
            }

        }

        [HttpPost]
        [Route("AssignLecturerToModule")]
        //post lecturer module
        public void AssignLecturerToModule(LecturerModuleDTO lecturerModuleDTO)
        {
            if (ModelState.IsValid)
            {
                db.AssignLecturerToModule(lecturerModuleDTO);
                db.Save();
            }
        }

        [HttpGet]
        [Route("AllLecturers")]
        public IEnumerable<Lecturer> GetLecturer()
        {
            return db.GetAllLecturer();
        }

        [HttpGet]
        [Route("AllStudents")]
        public IEnumerable<Student> GetStudent()
        {
            return db.GetAllStudents();
        }

        [HttpGet]
        [Route("AllModules")]
        public IEnumerable<Module> GetModule()
        {
            return db.GetAllModule();
        }
    }
}