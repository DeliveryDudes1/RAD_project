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
    [System.Web.Http.Authorize(Roles = "Student")]
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        StudentRepository db = new StudentRepository();

        [HttpGet]
        [Route("GetAllAttendance")]
        public IEnumerable<Attendance> GetAllAttendance(string id)
        {
            return db.GetAllAttendance(id);
        }

        [HttpGet]
        [Route("GetAllModules")]
        public IEnumerable<Module> GetAllModules(string id)
        {
            return db.GetAllModules(id);
        }

        [HttpGet]
        [Route("GetAllResults")]
        public IEnumerable<AssignmentResult> GetAllResults(string id)
        {
            return db.GetAllResults(id);
        }
    }
}