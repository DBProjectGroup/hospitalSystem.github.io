using HospitalDTO;
using HospitalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            //url:'/Account/Index'
            //deviceService devService = new deviceService();
            //devService.AddNew("032", "听诊器", "风湿科");
            //devService.Report("032", "没电了");
            patientService patService = new patientService();
            //patService.AddNew("101", "甲", 30, "男");
            //patService.AddNew("201", "乙", 25, "女");
            //patService.AddNew("231", "丙", 12, "男");
            //patService.AddNew("321", "丁", 60, "女");
            wardService warService = new wardService();
            // patService.contribute("201", "001");
            warService.disContribute("201");
            return View();
        }
        public ActionResult add()
        {
            //deviceService devService = new deviceService();
            ////devService.AddNew("011", "核磁共振仪", "心血管科");
            //devService.AddNew("006", "光学显微镜", "儿科");
            ////devService.AddNew("032", "听诊器", "风湿科");
            patientService patservice = new patientService();
            IEnumerable<PatientDTO> patients = patservice.GetbyWard("001");
            return Content(patients.ToString());
        }
    }
}