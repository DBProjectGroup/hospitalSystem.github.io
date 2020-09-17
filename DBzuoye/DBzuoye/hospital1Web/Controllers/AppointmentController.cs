using hosptialService1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital1Web.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: appointment
        public ActionResult Index()
        {
            AppointmentService patService = new AppointmentService();
            var pat = patService.GetAll();
           //return View(pat);
            return Json(pat, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(string ap_dept, string ap_patient, string date)
        {
            DateTime da = DateTime.Parse(date);
            AppointmentService pa = new AppointmentService();
            var res = pa.AddNew(ap_dept, ap_patient, da);
            //return RedirectToAction(nameof(Index));
            return Json(res, JsonRequestBehavior.AllowGet);
        }


      
        public ActionResult Delete(string ap_patient,string ap_dept,string date)
        {
            DateTime da = DateTime.Parse(date);
            AppointmentService pa = new AppointmentService();
            var res = pa.Delete(ap_patient,ap_dept,da);
           // return RedirectToAction(nameof(Index));
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetByID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetByID(string ap_patient)
        {
            AppointmentService pa = new AppointmentService();
            var pat = pa.GetByID(ap_patient);
            //return View(pat);
            return Json(pat, JsonRequestBehavior.AllowGet);
        }

       
        [HttpGet]
        public ActionResult Change()
        {
            return View();
            //return Json("TURE");
        }

        [HttpPost]
        public ActionResult Change(string oap_patient, string oap_dept, string odate, string ap_patient, string ap_dept, string date)
        {
            DateTime oda = DateTime.Parse(odate);
            DateTime da = DateTime.Parse(date);
            AppointmentService pa = new AppointmentService();
            var res = pa.Change(oap_patient, oap_dept,oda, ap_patient,ap_dept, da);
            //return RedirectToAction(nameof(Index));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}