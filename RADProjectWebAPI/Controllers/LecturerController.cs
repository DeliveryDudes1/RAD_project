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
        LecturerRepository db = new LecturerRepository();

        [HttpPost]
        [Route("MakeAssignment")]
        //post lecturer module
        public void MakeAssignment(AssignmentDTO assignmentDTO)
        {
            if (ModelState.IsValid)
            {
                db.MakeAssignment(assignmentDTO);
                db.Save();
            }
        }

        [HttpPost]
        [Route("RecordAttendance")]
        
        public void RecordAttendance(AttendaceDTO attendaceDTO)
        {
            if (ModelState.IsValid)
            {
                db.RecordAttendance(attendaceDTO);
                db.Save();
            }
        }

        [HttpPost]
        [Route("RecordAssigmentResult")]
        
        public void RecordAssigmentResult(ResultsDTO resultsDTO)
        {
            if (ModelState.IsValid)
            {
                db.RecordAssigmentResult(resultsDTO);
                db.Save();
            }
        }

        [HttpGet]
        [Route("GetAllModules")]
        public IEnumerable<Module> GetAllModules(int id)
        {
            return db.GetAllModules(id);
        }

       
    }
}