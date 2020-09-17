using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HospitalService;
using HospitalDTO;

namespace MVCtest.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            return View("登录");
        }
        public ActionResult wardManager()
        {
            return View("wardManager");
        }
        //1.加载病房主页面的时候，信息：空，接口：返回所有病房DTO的Json对象
        //2.搜索按钮：信息：病房ID，接口：返回相应病房的DTO的Json对象
        //3.空闲病房查询按钮：信息：空，接口：返回病房没满的DTO的Json对象
        //4.删除按钮：信息：病房id,接口：返回删除成功或者失败的信息
        //5.编辑按钮：信息：病房id,接口：返回相应病房里所有病人的DTO的Json对象
        //6.添加病人的按钮：信息：病人的id，接口：返回添加病人成功或者失败
        //7.删除病人的按钮：信息：病人的id，接口：返回删除病人成功或者失败
        //8.给指定的病人分配护士：信息：病人的ID和护士的ID，返回：分配成功或者失败
        //9.删除病房的按钮：信息：病房的id,接口：返回删除病房成功或者失败
        //10.加载设备主页面的时候，信息：空，接口：返回所有设备DTO的Json对象
        //10.删除设备按钮，信息：设备id，接口：返回删除设备成功或者失败
        //10.添加设备按钮，信息：设备id，设备名称，接口：返回添加设备成功或者失败
        //10.分配设备按钮，信息：设备id，分配的部门名称，接口：返回分配成功或者失败
        [HttpPost]
        public ActionResult LoadWards()
        {
            wardService warService = new wardService();
            IEnumerable<WardDTO> wards= warService.GetALL();
            return Json(wards);
        }
        //1.加载病房主页面的时候，信息：空，接口：返回所有病房DTO的Json对象
        [HttpPost]
        public ActionResult SearchWards(string id)
        {
            wardService warService = new wardService();
            WardDTO ward = warService.GetbyId(id);
            return Json(ward);                                 
        }
        //2.搜索按钮：信息：病房ID，接口：返回相应病房的DTO的Json对象
        [HttpPost]
        public ActionResult SearchEmpty()
        {
            wardService warService = new wardService();
            IEnumerable<WardDTO> wards = warService.GetNotFull();
            return Json(wards);
        }
        //3.空闲病房查询按钮：信息：空，接口：返回病房没满的DTO的Json对象
        [HttpPost]
        public ActionResult DeleteWard(string id)
        {
            wardService warService = new wardService();
            int k=warService.Delete(id);
            if (k == -1) return Json("删除失败");
            else return Json("删除成功");
        }
        //4.删除按钮：信息：病房id,接口：返回删除成功或者失败的信息
        [HttpPost]
        public ActionResult AddWard(string id,string dept,int capacity)
        {
            wardService warService = new wardService();
            int k=warService.AddNew(id,dept,capacity);
            if (k == -1) return Json("添加失败，已经有相应编号的病房了");
            else if (k == 2) return Json("添加失败，不存在该部门");
            else return Json("添加成功");
        }
        //添加病房按钮
        [HttpPost]
        public ActionResult EditWard(string id)
        {
            patientService patservice = new patientService();
            IEnumerable<PatientDTO> patients = patservice.GetbyWard(id);
            return Json(patients);
            
        }
        //5.编辑按钮：信息：病房id,接口：返回相应病房里所有病人的DTO的Json对象
        [HttpPost]
        public ActionResult ContributePatient(string patient_Id,string ward_Id)
        {
            patientService patservice = new patientService();
            string result = patservice.contribute(patient_Id,ward_Id);
            return Json(result);

        }
        //6.添加病人的按钮：信息：病人的id，接口：返回添加病人成功或者失败
        [HttpPost]
        public ActionResult DisContributePatient(string patient_Id)
        {
            wardService warService = new wardService();
            int k=warService.disContribute(patient_Id);
            if (k == -1) return Json("删除失败");
            else return Json("删除成功");

        }
        //7.删除病人的按钮：信息：病人的id，接口：返回删除病人成功或者失败
        [HttpPost]
        public ActionResult ContributeNurse(string patient_Id,string nurse_Id)
        {
            patientService patservice = new patientService();
            string result=patservice.contributenurse(nurse_Id, patient_Id);
            return Json(result);

        }
        //8.给指定的病人分配护士：信息：病人的ID和护士的ID，返回：分配成功或者失败
        [HttpPost]
        public ActionResult DisContributeNurse(string patient_Id, string nurse_Id)
        {
            patientService patservice = new patientService();
            string result = patservice.Discontributenurse(nurse_Id, patient_Id);
            return Json(result);

        }
        //8.给指定的病人撤销护士：信息：病人的ID和护士的ID，返回：撤销成功或者失败
        [HttpPost]
        public ActionResult LoadDevices()
        {
            deviceService devService = new deviceService();
            IEnumerable<DeviceDTO> devices = devService.GetALL();
            return Json(devices);
        }
        //10.加载设备主页面的时候，信息：空，接口：返回所有设备DTO的Json对象
        [HttpPost]
        public ActionResult DeleteDevice(string id)
        {
            deviceService devService = new deviceService();
            string result=devService.Delete(id);
            return Json(result);
        }
        //10.删除设备按钮，信息：设备id，接口：返回删除设备成功或者失败
        [HttpPost]
        public ActionResult AddDevice(string id,string name,string dept)
        {
            deviceService devService = new deviceService();
            int k = devService.AddNew(id,name,dept);
            if (k == -1) return Json("添加失败，已经有相应编号的设备了");
            else return Json("添加成功");
        }
        //10.添加设备按钮，信息：设备id，设备名称，接口：返回添加设备成功或者失败
        [HttpPost]
        public ActionResult ContributeDevice(string id, string dept)
        {
            deviceService devService = new deviceService();
            string result = devService.Contribute(id, dept);
            return Json(result);
           
        }
        //10.分配设备按钮，信息：设备id，分配的部门名称，接口：返回分配成功或者失败
        [HttpPost]
        public ActionResult SearchNurses(string id)
        {
            patientService patService = new patientService();
            IEnumerable<NurseDTO> result = patService.searchnurse(id);
            return Json(result);
        }
        //10.查询病人所关联的护士
        [HttpPost]
        public ActionResult ReportDevice(string id,string info)
        {
            deviceService devService = new deviceService();
            string result = devService.Report(id, info);
            return Json(result);
        }
        //10.分配设备按钮，信息：设备id，分配的部门名称，接口：返回分配成功或者失败
        //管理员账号注册
        //[HttpPost]
        //public ActionResult ManagerAdd(string ID, string name, string pass, string type)
        //{

        //    AccountService accountService = new AccountService();
        //    accountService.AddNew(ID, pass, name, type);
        //    返回值待定
        //    return RedirectToAction("Index");

        //}
        //医生账号注册
        //[HttpPost]
        //public ActionResult DoctorAdd(string ID, string name, string pass, string type, string dept,
        //    string pos, float salary, int age, string sex)
        //{
        //    AccountService accountService = new AccountService();
        //    DoctorService doctorService = new DoctorService();
        //    Account account = new Account();
        //    accountService.AddNew(ID, pass, name, type);
        //    account.user_ID = ID;
        //    account.name = name;
        //    doctorService.AddNew(account, dept, pos, salary, age, sex);
        //    返回值待定
        //    return RedirectToAction("Index");
        //}
        //护士账号注册
        //[HttpPost]
        //public ActionResult NurseAdd(string ID, string name, string pass, string type, string dept,
        //    string pos, float salary, string sex)
        //{
        //    AccountService accountService = new AccountService();
        //    NurseService nurseService = new NurseService();
        //    Account account = new Account();
        //    accountService.AddNew(ID, pass, name, type);
        //    account.user_ID = ID;
        //    account.name = name;
        //    nurseService.AddNew(account, dept, pos, salary, sex);
        //    返回值待定
        //    return RedirectToAction("Index");
        //}
        //账号登录验证
        public ActionResult Login(string ID, string name)
        {
            accountService accService = new accountService();
            AccountDTO accountDTO = accService.GetById(ID);
            if (accountDTO != null)
            {
                
                return Json(accountDTO);
            }
            else
                return Json(null);
        }
        //签到记录
        //public ActionResult Acttendance(string ID)
        //{
        //    AttendanceService attendanceService = new AttendanceService();
        //    if (attendanceService.AddNew(ID) == true)
        //        return Content("true");
        //    else
        //        return Content("false");
        //}
        //验证签到记录
        //public ActionResult IsActtendanced(string ID, string time)
        //{
        //    AttendanceService attendanceService = new AttendanceService();
        //    if (attendanceService.IsAttendanced(ID, time) == true)
        //        return Content("trued");
        //    else
        //        return Content("falsed");
        //}

        //[HttpPost]
        //public ActionResult RegisterAdd(string ID)
        //{

        //    RegisterService registerService = new RegisterService();
        //    registerService.AddNew(ID);
        //    return RedirectToAction("Index");

        //}
        //[HttpPost]
        //public ActionResult Delete(string ID)
        //{

        //    AccountService accountService = new AccountService();
        //    accountService.Delete(ID);
        //    return RedirectToAction("Index");

        //}
        ///*public ActionResult RegisterAccount()
        //{

        //}*/

        public ActionResult test1(int id, string str)
        {
            return Content("返回一个字符串" + id + str);
            //return Json("返回一个字符串" + id + str);
        }
    }
}