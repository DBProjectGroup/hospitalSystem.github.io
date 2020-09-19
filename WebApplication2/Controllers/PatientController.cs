using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital1Web.Controllers
{
    public class PatientController : Controller
    {
        // GET: patient
        public ActionResult Index()
        {
            PatientService patService = new PatientService();
            //var pat =  patService.GetByID("001");   
            var pat = patService.GetAll();
            //return View(pat);
            return Json(pat, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
         public ActionResult AddNew()
         {
             return View();  
            //return Json("TURE");
         }

        [HttpPost]
        public ActionResult AddNew(string patient_ID,string patient_name,int patient_age,string patient_sex,string patient_ward)
        {
            PatientService pa = new PatientService();
            var res = pa.AddNew(patient_ID,patient_name,patient_age,patient_sex,patient_ward);
            //return RedirectToAction(nameof(Index));
            return Json(res);
           // return Json(pa);
        }

        public ActionResult Delete(string patient_ID)
        {
            PatientService pa = new PatientService();
            var res = pa.Delete(patient_ID);
            //return RedirectToAction(nameof(Index));
            return Json(res);
        }

        [HttpGet]
        public ActionResult Change()
        {
            return View();
            //return Json("TURE");
        }

        [HttpPost]
        public ActionResult Change(string opatient_ID,string patient_ID, string patient_name, int patient_age, string patient_sex, string patient_ward)
        {
            PatientService pa = new PatientService();
            var res = pa.Change(opatient_ID,patient_ID, patient_name, patient_age, patient_sex, patient_ward);
            //return RedirectToAction(nameof(Index));
            return Json(res);
        }

        [HttpGet]
        public ActionResult GetByID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetByID(string patient_ID)
        {
            PatientService pa = new PatientService();
            var pat = pa.GetByID(patient_ID);
            //return View(pat);
            return Json(pat);
        }

        public ActionResult GetAll()
        {
            PatientService pa = new PatientService();
            var pat = pa.GetAll();
            // return View(pat);
            return Json(pat,JsonRequestBehavior.AllowGet);
        }
    }   
}