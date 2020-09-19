using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            /*using (MyContext ctx = new MyContext())
            {
                DepartmentService d = new DepartmentService();
                var res = d.GetAllDepartment();
                return Json(res);
            }*/
            return View();
        }

        public ActionResult GetAll()
        {

            DepartmentService d = new DepartmentService();
            var res = d.GetAllDepartment();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNew(string dept_name, string dir_name, string dir_ID,
            int room_ID, int people_num)
        {
            DepartmentService d = new DepartmentService();
            d.AddNewDepartment(dept_name,dir_name,dir_ID,room_ID,people_num);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Del(string dept_name)
        {
            DepartmentService d = new DepartmentService();
            d.DeleteDepartmentByName(dept_name);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string dept_name)
        {
            DepartmentService d = new DepartmentService();
            var res = d.GetDepartmentByDptName(dept_name);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Change(string dept_name,string department_name, string dir_name, string dir_ID,
            int room_ID, int people_num)
        {
            DepartmentService d = new DepartmentService();
            d.ChangeDepartmentByName(dept_name,department_name,dir_name,dir_ID,room_ID,people_num);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}