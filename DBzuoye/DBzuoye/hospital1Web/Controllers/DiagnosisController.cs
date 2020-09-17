using hospitalDTO1;
using hosptialService1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital1Web.Controllers
{
    public class DiagnosisController : Controller
    {
        // GET: diagnosis
        public ActionResult Index()
        {
            DiagnosisService diaService  = new DiagnosisService();
            //var pat =  patService.GetByID("001");   
            var dia = diaService.GetAll();
            //return View(dia);
            return Json(dia);
        }

       

       

        [HttpGet]
        public ActionResult GetBydia_patient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBydia_patient(string dia_patient)
        {
            DiagnosisService pa = new DiagnosisService();
            var dia = pa.GetBydia_patient(dia_patient);
            return Json(dia);

           
        }

    }
}