using hospital1;
using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            MedicineService medserve = new MedicineService();
            var med = medserve.QueryAll();
            return View(med);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        
        public ActionResult Add(string med_ID, string med_name, int cost_price, int sell_price, string unit, int num, string producer)
        {
            MedicineService medserve = new MedicineService();
            if(medserve.Check(med_ID) == null)
            {
                medserve.AddNew(med_ID, med_name, cost_price, sell_price, unit, num, producer);
            }
            else
            {
                medserve.IncreaseMedicine(med_ID, num);
            }
            return Json("true");
        }

        /*[HttpPost]
        public ActionResult Add(string med_ID)
        {
            MedicineService medserve = new MedicineService();
            
            return Json("true");
        }*/

        public ActionResult Query(string ID)
        {
            MedicineService medserve = new MedicineService();
            var QResult = medserve.QueryByID(ID);
            return Json(QResult);
        }

        [HttpGet]
        public ActionResult Display()
        {
            MedicineService medserve = new MedicineService();
            var QResult = medserve.QueryAll();
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string ID)
        {
            MedicineService medserve = new MedicineService();
            medserve.DeleteOld(ID);
            return Json("true");
        }

        public ActionResult Increase(string med_ID, int num)
        {
            MedicineService medserve = new MedicineService();
            medserve.IncreaseMedicine(med_ID, num);
            return Json("true");
        }

        public ActionResult Edit(string med_ID, string med_name, int cost_price, int sell_price, string unit, int num, string producer)
        {
            MedicineService medserve = new MedicineService();
            medserve.ModNew(med_ID, med_name, cost_price, sell_price, unit, num, producer);
            return Json("true");
        }
    }
}