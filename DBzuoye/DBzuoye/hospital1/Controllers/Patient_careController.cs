using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hosptialService1;

namespace hospital1.Controllers
{
    public class Patient_careController : Controller
    {
        // GET: patient_care
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {

            }
            return Content("OK");
        }
    }
}