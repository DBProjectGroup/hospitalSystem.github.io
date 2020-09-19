using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        public ActionResult Next()
        {
            DoctorService docserve = new DoctorService();
            docserve.NextMonth();
            return Json("true");
        }

        public ActionResult RtState(string doctor_ID)
        {
            DoctorService docserve = new DoctorService();
            List<int> statelist = new List<int>();
            int is_arranged = docserve.RtState(doctor_ID);
            statelist.Add(is_arranged);
            return Json(statelist);
        }
        public ActionResult Change1(string doctor_ID)
        {
            DoctorService docserve = new DoctorService();
            docserve.ChangeDoctorState(doctor_ID);
            return Json("true");
        }

        [HttpGet]
        public ActionResult Display()
        {
            DoctorService docserve = new DoctorService();
            var QResult = docserve.DisplayDoctorSalary();
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Query(string doctor_ID)
        {
            DoctorService docserve = new DoctorService();
            var QResult = docserve.QueryByID(doctor_ID);
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RtSalary()
        {
            List<float> salalist = new List<float>();
            DoctorService docserve = new DoctorService();
            NurseService nurserve = new NurseService();
            float total1 = docserve.RetrunDoctorTotalSalary();
            float total2 = nurserve.ReturnNurseTotalSalary();
            salalist.Add(total1 + total2);
            return Json(salalist);
        }
        // GET: Doctor
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {
                DoctorService d = new DoctorService();
                var res = d.GetAllDoctor();
                return View(res);
            }
        }

        public ActionResult GetAll()
        {
            DoctorService d = new DoctorService();
            var res = d.GetAllDoctor();
            return Json(res);
        }

        public ActionResult SearchID(string doctor_ID)
        {
            DoctorService d = new DoctorService();
            var res = d.GetDoctorByID(doctor_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchIDe(string doctor_ID)
        {
            DoctorService d = new DoctorService();
            var res = d.GetDoctorByIDe(doctor_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchName(string doctor_ID)
        {
            var a = doctor_ID;
            DoctorService d = new DoctorService();
            var res = d.GetDoctorByName(doctor_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNew(string doctor_ID, string doctor_name, string doctor_dept,
            string doctor_position, float salary, int age, string sex, int is_arranged)
        {
            DoctorService d = new DoctorService();
            var res = d.AddNewDoctor(doctor_ID, doctor_name, doctor_dept, doctor_position, salary, age, sex, is_arranged);
            return Json(res);
        }

        public ActionResult Delete(string doctor_ID)
        {
            DoctorService d = new DoctorService();
            d.DeleteDoctorByID(doctor_ID);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Change(string predoctor_ID,string doctor_ID, string doctor_name, string doctor_dept,
            string doctor_position, float salary, int age, string sex, int is_arranged)
        {
            DoctorService d = new DoctorService();
            var res = d.ChangeDoctorByID(predoctor_ID, doctor_ID, doctor_name,doctor_dept, doctor_position, salary, age, sex, is_arranged);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}