using hospital1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class BillController : Controller
    {
        public ActionResult Display()
        {
            BillService billserve = new BillService();
            var QResult = billserve.QueryAll();
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(string bill_ID, string bill_patient, string type, int cost)
        {
            BillService billserve = new BillService();
            billserve.CreateBill(bill_ID, bill_patient, type, cost);
            return Json("true");
        }

        public ActionResult Query(string bill_patient)
        {
            BillService billserve = new BillService();
            var QResult = billserve.QueryByPatientID(bill_patient);
            return Json(QResult);
        }

        public ActionResult Delete(string bill_ID)
        {
            BillService billserve = new BillService();
            billserve.DeleteBill(bill_ID);
            return Json("true");
        }
        

    }
}