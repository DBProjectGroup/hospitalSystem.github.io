using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class NurseController : Controller
    {
        // GET: Nurse
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {
                NurseService d = new NurseService();
                //d.AddNewNurse("111", "2", "3", "4", "5", 6000);
                var res = d.GetAllNurse();
                return View(res);
            }
        }
        [HttpGet]
        public ActionResult Display()
        {
            NurseService nurserve = new NurseService();
            var QResult = nurserve.DisplayNurseSalary();
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Query(string nurse_ID)
        {
            NurseService nurserve = new NurseService();
            var QResult = nurserve.QueryByID(nurse_ID);
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            NurseService d = new NurseService();
            var res = d.GetAllNurse();
            return Json(res);
        }

        public ActionResult SearchID(string nurse_ID)
        {
            NurseService d = new NurseService();
            var res = d.GetNurseByID(nurse_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchIDe(string nurse_ID)
        {
            NurseService d = new NurseService();
            var res = d.GetNurseByIDe(nurse_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchName(string nurse_ID)
        {
            var a = nurse_ID;
            NurseService d = new NurseService();
            var res = d.GetNurseByName(nurse_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNew(string nurse_ID, string nurse_name, string nurse_dept,
            string position, string sex, int salary)
        {
            NurseService d = new NurseService();
            var res = d.AddNewNurse(nurse_ID, nurse_name, nurse_dept, position,sex, salary);
            return Json(res);
        }

        public ActionResult Delete(string nurse_ID)
        {
            NurseService d = new NurseService();
            d.DeleteNurseByID(nurse_ID);
            return Json(1);
        }

        public ActionResult Change(string prenurse_ID, string nurse_ID, string nurse_name, string nurse_dept,
            string position, string sex, int salary)
        {
            NurseService d = new NurseService();
            var res = d.ChangeNurseByID(prenurse_ID, nurse_ID, nurse_name, nurse_dept, position, sex, salary);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}