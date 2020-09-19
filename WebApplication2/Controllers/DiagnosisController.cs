using hospitalDTO;
using hospitalServiceTest;
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
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string doc_ID, string dia_patient, string visit_ID, string med_ID, int med_Num, string result)
        {
            DiagnosisService diagserve = new DiagnosisService();
            diagserve.AddNew1(doc_ID, dia_patient, visit_ID, med_ID, med_Num, result);
            return Json("true");
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