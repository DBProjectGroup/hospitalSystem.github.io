using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital1Web.Controllers
{
    public class Patient_careController : Controller
    {
        // GET: patient_care
        public ActionResult Index()
        {
            Patient_careService patService = new Patient_careService();
            //var pat =  patService.GetByID("001");   
            var pat = patService.GetAll();
            // return View(pat);
            return Json(pat);
        }

        [HttpGet]
        public ActionResult GetByID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetByID(string patient_ID)
        {
            Patient_careService pa = new Patient_careService();
            var pat = pa.GetByID(patient_ID);
            // return View(pat);
            return Json(pat); 
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
            //return Json("TURE");
        }

        [HttpPost]
        public ActionResult AddNew(string patient_ID, string nur_ID, string name, string content, string ward_ID, string start_time)
        {
            DateTime da = DateTime.Parse(start_time);
            Patient_careService pa = new Patient_careService();
            var res = pa.AddNew(patient_ID,  nur_ID, name,  content,  ward_ID,  da);
            //return RedirectToAction(nameof(Index));
            return Json(res);
            // return Json(pa);
        }

        public ActionResult Delete(string patient_ID, string nur_ID, string start_time)
        {
            DateTime da = DateTime.Parse(start_time);
            Patient_careService pa = new Patient_careService();
            pa.Delete(patient_ID,nur_ID,da);
            //return RedirectToAction(nameof(Index));
            return Json(pa);
        }

        [HttpGet]
        public ActionResult Change()
        {
            return View();
            //return Json("TURE");
        }

        [HttpPost]
        public ActionResult Change(string opatient_ID,string onur_ID,string  ostart_time,string  patient_ID,string  nur_ID,string start_time,string  name,string  content,string   ward_ID)
        {
            DateTime osta = DateTime.Parse(ostart_time);
            DateTime sta = DateTime.Parse(start_time);
            Patient_careService pa = new Patient_careService();
            var res = pa.Change(opatient_ID, onur_ID, osta, patient_ID, nur_ID, sta, name,content,ward_ID);
            //return RedirectToAction(nameof(Index));
            return Json(res);
        }
    }
}