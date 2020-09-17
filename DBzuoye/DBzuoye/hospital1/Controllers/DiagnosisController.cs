using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hosptialService1;

namespace hospital1.Controllers
{
    public class DiagnosisController : Controller
    {
        // GET: diagnosis
        public ActionResult Index()
        {

            using (MyContext ctx = new MyContext())
            {
               // diagnosis us = new diagnosis { doc_ID = "336", dia_patient = "tj", visit_ID = 20, med_ID = "M",result = "1"};
                //ctx.diagnosises.Add(us);
                //ctx.SaveChanges();
            }

            return Content("OK");
         }
    }
}