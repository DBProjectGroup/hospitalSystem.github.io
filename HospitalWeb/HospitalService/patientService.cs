using EFEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HospitalDTO;

namespace HospitalService
{
    public class patientService
    {
        //public string patient_ID { get; set; }
        //public string patient_name { get; set; }
        //public Nullable<int> patient_age { get; set; }
        //public string patient_sex { get; set; }
        //public string patient_ward { get; set; }

        //public virtual ICollection<patient_care> patient_care { get; set; }

        //public virtual ward ward { get; set; }
        public void AddNew(string patient_ID, string patient_name, int patient_age,
            string patient_sex)
        {
            using (MyContext ctx = new MyContext())
            {
                patient s = new patient();
                s.patient_ID = patient_ID;
                s.patient_name = patient_name;
                s.patient_age = patient_age;
                s.patient_sex = patient_sex;
                ctx.patients.Add(s);
                ctx.SaveChanges();
            }
        }
        public void Delete(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                var patient = ctx.patients.SingleOrDefault(s => s.patient_ID == id);
                if (patient == null)
                {
                    throw new ArgumentException("没找到id=" + id + "的病人");
                }
                ctx.patients.Remove(patient);
                ctx.SaveChanges();
            }
        }
        //给病人分配护士护理
        public string Discontributenurse(string nurse_ID, string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                foreach (var item in ctx.patientCares)
                {
                    if (item.nur_ID == nurse_ID && item.pat_ID == patient_ID)
                    {
                        ctx.patientCares.Remove(item);
                    }
                }
                ctx.SaveChanges();
                return "撤销成功";
            }
        }
        //分配病房的函数
        public string contribute(string patient_ID,string ward_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var patient = ctx.patients.AsNoTracking().SingleOrDefault(e => e.patient_ID == patient_ID);
                if (patient == null)
                {
                    return "没找到id=" + patient_ID + "的病人";
                }
                var ward = ctx.wards.AsNoTracking().SingleOrDefault(e => e.ward_ID == ward_ID);
                if (ward.is_full == 1) {
                    return "你要分配的病房已经满了";
                }
                if (patient.patient_ward != null){
                   return "病人已经分配病房，请先删除原分配的病房";
                }
                //Linq 查询 - 自动转译 T-SQL 语句
                var query1 = from item in ctx.patients
                            where item.patient_ID == patient_ID
                            select item;
                //查询到对象后，修改对象属性
                foreach (var item in query1)
                {
                    item.patient_ward = ward_ID;
                    break;
                }
                ctx.SaveChanges();
                var count = ctx.patients.AsNoTracking()
                    .Include(e => e.ward)
                    .Where(e => e.patient_ward == ward_ID).Count();
                if (count == ward.capacity)
                {
                    //Linq 查询 - 自动转译 T-SQL 语句
                    var query2 = from item in ctx.wards
                                where item.ward_ID == ward_ID
                                select item;
                    foreach (var item in query2)
                    {
                        item.is_full = 1;
                        break;
                    }
                }
                ctx.SaveChanges();
                return "分配成功";
            }
        }
        //查询当前病房的病人
        public IEnumerable<PatientDTO> GetbyWard(string ward_id)
        {
            using (MyContext ctx = new MyContext())
            {
                var patients = ctx.patients.AsNoTracking()
                    .Include(e => e.ward)
                    .Where(e => e.patient_ward == ward_id).ToList();
                List<PatientDTO> list = new List<PatientDTO>();
                foreach (var p in patients)
                {
                    list.Add(ToDTO(p));
                }
                return list;
            }
        }
        //给病人分配护士护理
        public string contributenurse(string nurse_ID,string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                foreach(var item in ctx.patientCares)
                {
                    if (item.nur_ID == nurse_ID && item.pat_ID == patient_ID)
                    {
                        return "当前的护士已经分配护理该病人";
                    }
                }
                patient_care s = new patient_care();
                s.nur_ID = nurse_ID;
                s.pat_ID = patient_ID;
                var patient = ctx.patients.AsNoTracking().SingleOrDefault(e => e.patient_ID == patient_ID);
                s.ward_ID = patient.patient_ward;
                ctx.patientCares.Add(s);
                ctx.SaveChanges();
                return "分配成功";
            }
        }
        //查询病人的护士
        public IEnumerable<NurseDTO> searchnurse(string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var nurse_ID = "";
                List<NurseDTO> list = new List<NurseDTO>();
                foreach (var item in ctx.patientCares.ToList())
                {
                    if (item.pat_ID == patient_ID)
                    {

                        nurse_ID = item.nur_ID;
                        var nurse = ctx.nurses.AsNoTracking().SingleOrDefault(e => e.nurse_ID == nurse_ID);
                        list.Add(ToNurseDTO(nurse));
                        nurse_ID = "";
                    }
                }
                if (list != null)
                {
                    return list;
                }
                else return null;
                
            }
        }
        private PatientDTO ToDTO(patient s)
        {


            PatientDTO dto = new PatientDTO();
            dto.patient_name = s.patient_name;
            dto.patient_sex = s.patient_sex;
            dto.patient_ID = s.patient_ID;
            dto.patient_ward_dept = s.ward.ward_dept;
            dto.patient_ward = s.ward.ward_ID;
            dto.patient_age = s.patient_age;
            return dto;

        }
        private PatientCareDTO CareToDTO(patient_care s)
        {


            PatientCareDTO dto = new PatientCareDTO();
            dto.pat_ID = s.patient.patient_ID;
            dto.nur_ID = s.nurse.nurse_ID;
            dto.ward_ID = s.ward.ward_ID;
            dto.patient_name = s.patient.patient_name;
            dto.nurse_name = s.nurse.nurse_name;
            dto.content = s.content;
            dto.name = s.name;
            return dto;

        }
        private NurseDTO ToNurseDTO(nurse s)
        {


            NurseDTO dto = new NurseDTO();
            dto.nurse_ID = s.account.user_ID;
            dto.nurse_name = s.nurse_name;
            dto.position = s.position;
            dto.salary = s.salary;
            dto.sex = s.sex;
            dto.dept_name = s.department.dept_name;
            return dto;

        }
    }
}

