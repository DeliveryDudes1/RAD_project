using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RADPrpjectMVC.Controllers
{
    public class StudentController : ApiController
    {
        // GET: Student
        public ActionResult Index()
        {

            return View();

        }
    }
}