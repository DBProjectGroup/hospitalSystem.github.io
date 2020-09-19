using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HospitalService;
using HospitalDTO;
using hospitalDTO;
using hospitalServiceTest;
using hospital1;

namespace MVCtest.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult registe()
        {
            return View("registe");
        }
        //管理员账号注册
        public ActionResult ManAdd(string ID, string pass, string name)
        {

            accountService account = new accountService();
            if (account.AddNew1(ID, pass, name, "Manager") == true)
                return Json("注册成功");
            else
                return Json("注册账号已存在");
        }
        //医生账号注册
        public ActionResult ManAdd2(string userID, string name, string pass, string dept,
            string position, string age, string sex)
        {
            accountService accounts = new accountService();
            DoctorService doctorService = new DoctorService();
            account account = new account();
            if (accounts.AddNew1(userID, pass, name, "Doctor") == false)//ToDo
                return Json("账号已存在,请重新注册");
            account.user_ID = userID;
            account.name = name;
            int iu = int.Parse(age);
            doctorService.AddNew(account, dept, position, 0, iu, sex);
            //返回值待定
            return Json("注册成功");
        }
        //护士账号注册
        public ActionResult ManAdd1(string nurseID, string nurseName, string nursePassword, string nursePosition, string nurseDept_name,
             string nurseGender)
        {
            accountService accountS = new accountService();
            NurseService nurseService = new NurseService();
            account account = new account();
            if (accountS.AddNew1(nurseID, nursePassword, nurseName, "Nurse") == false)
                return Json("账号已存在,请重新注册");//ToDo
            account.user_ID = nurseID;
            account.name = nurseName;
            nurseService.AddNew(account, nurseDept_name, nursePosition, 0, nurseGender);
            //返回值待定
            return Json("注册成功");
        }
        //修改密码
        public ActionResult ChangeAc(string username, string name, string pass, string checkPass)
        {
            accountService accountS = new accountService();
            if (pass == checkPass && accountS.Update(username, name, pass) == true)
                return Json("ture");
            else
                return Json("false");
        }
        //账号登录验证
        public ActionResult Login(string ID, string pass)
        {
            accountService accountS = new accountService();
            RegisterService registerService = new RegisterService();
            if (ID == null || pass == null)
                return Json(null);
            AccountDTO accountDTO = accountS.Login(ID, pass);
            if (accountDTO != null)
            {
                registerService.Update(ID);
                return Json(accountDTO);
            }
            else
                return Json(null);
        }
        //返回当前所有手术数据
        public ActionResult OpeAll()
        {
            OperationService operationService = new OperationService();
            List<OperationDTO> operationDTOs = operationService.GetAll().ToList();
            return Json(operationDTOs);
        }
        //搜索的手术ID的Json list
        public ActionResult OpeSea(string op_ID)
        {
            OperationService operationService = new OperationService();
            OperationDTO dto = operationService.GetById(op_ID);
            List<OperationDTO> operationDTOs = new List<OperationDTO>();
            operationDTOs.Add(dto);
            return Json(operationDTOs);
        }
        //添加手术
        public ActionResult OpeAdd(string op_ID, string op_name, string op_dept, string op_patient, string date1, string date2)
        {
            OperationService operationService = new OperationService();
            string date3 = date2.Replace("T", " ");
            string date = date3.Replace(".000Z", "");
            operationService.AddNew(op_ID, op_name, op_patient, op_dept, date);
            return Json(true);
        }
        //修改手术信息
        public ActionResult OpeUp(string op_ID, string op_name, string op_dept, string op_patient, string date1, string date2)
        {
            OperationService operationService = new OperationService();
            string date3 = date2.Replace("T", " ");
            string date = date3.Replace(".000Z", "");
            operationService.Update(op_ID, op_name, op_patient, op_dept, date);
            return Json(true);
        }
        //删除手术信息
        public ActionResult OpeDe(string op_ID)
        {
            OperationService operationService = new OperationService();
            operationService.Delete(op_ID);
            return Json(true);
        }
        //返回当前手术所有参与人员
        public ActionResult ParAll(string op_ID)
        {
            Operation_participateService operation_ParticipateService = new Operation_participateService();
            List<Operation_participateDTO> operation_ParticipateDTOs = new List<Operation_participateDTO>();
            operation_ParticipateDTOs = operation_ParticipateService.GetAll(op_ID).ToList();
            return Json(operation_ParticipateDTOs);
        }
        //为当前手术增加参与人员
        public ActionResult OpeParAdd(string op_ID, string person_ID)
        {
            Operation_participateService operation_ParticipateService = new Operation_participateService();
            operation_ParticipateService.AddNew(op_ID, person_ID);
            return Json("true");
        }
        //为当前手术删减参与人员
        public ActionResult OpeParDel(string op_ID, string person_ID)
        {
            Operation_participateService operation_ParticipateService = new Operation_participateService();
            operation_ParticipateService.Delete(op_ID, person_ID);
            return Json("true");
        }

        //签到记录
        public ActionResult Acttendance(string peo_ID)
        {
            AttendanceService attendanceService = new AttendanceService();
            if (attendanceService.AddNew(peo_ID) == true)
                return Json(attendanceService.GetTimes(peo_ID, true));
            else
                return Json(attendanceService.GetTimes(peo_ID, false));
        }
        //验证签到记录
        public ActionResult IsActtendanced(string ID, string time)
        {
            AttendanceService attendanceService = new AttendanceService();
            if (attendanceService.IsAttendanced(ID, time) == true)
                return Content("trued");
            else
                return Content("falsed");
        }
        //返回签到信息
        public ActionResult AttData(string peo_ID)
        {
            AttendanceService attendanceService = new AttendanceService();
            return Json(attendanceService.GetTimes(peo_ID, true));
            /*    return Content("trued");
            else
                return Content("falsed");*/
        }
        [HttpPost]
        public ActionResult RegisterAdd(string ID)
        {

            RegisterService registerService = new RegisterService();
            registerService.AddNew(ID);
            return RedirectToAction("Index");

        }


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
            PatientService patservice = new PatientService();
            IEnumerable<PatientDTO> patients = patservice.GetbyWard(id);
            return Json(patients);
            
        }
        //5.编辑按钮：信息：病房id,接口：返回相应病房里所有病人的DTO的Json对象
        [HttpPost]
        public ActionResult ContributePatient(string patient_Id,string ward_Id)
        {
            PatientService patservice = new PatientService();
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
            PatientService patservice = new PatientService();
            string result=patservice.contributenurse(nurse_Id, patient_Id);
            return Json(result);

        }
        //8.给指定的病人分配护士：信息：病人的ID和护士的ID，返回：分配成功或者失败
        [HttpPost]
        public ActionResult DisContributeNurse(string patient_Id, string nurse_Id)
        {
            PatientService patservice = new PatientService();
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
        public ActionResult AddDevice(string id,string name)
        {
            deviceService devService = new deviceService();
            int k = devService.AddNew(id,name);
            if (k == -1) return Json("添加失败，已经有相应编号的设备了");
            else return Json("添加成功");
        }
        [HttpPost]
        public ActionResult SearchDevice(string id)
        {
            deviceService devService = new deviceService();
            DeviceDTO device = devService.GetById(id);
            return Json(device);
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
            PatientService patService = new PatientService();
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
    }
}