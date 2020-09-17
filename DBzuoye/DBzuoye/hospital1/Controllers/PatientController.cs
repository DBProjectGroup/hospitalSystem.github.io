using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hosptialService1;

namespace hospital1.Controllers
{
    public class PatientController : Controller
    {
        // GET: patient
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {
                //patient us = new patient { patient_ID = "336", patient_name = "tj", patient_age = 20, patient_sex = "M" };
               // ctx.patients.Add(us);
                //ctx.SaveChanges();
            }
            return Content("OK");
        }
    }
}