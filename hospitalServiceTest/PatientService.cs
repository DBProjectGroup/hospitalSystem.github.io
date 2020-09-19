using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{

     public class PatientService
    {
        public string Discontributenurse(string nurse_ID, string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                foreach (var item in ctx.Patient_cares.ToList())
                {
                    if (item.nur_ID == nurse_ID && item.patient_ID == patient_ID)
                    {
                        ctx.Patient_cares.Remove(item);
                        try
                        {
                            ctx.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {

                            // Update the values of the entity that failed to save from the store
                            ex.Entries.Single().Reload();
                        }
                    }
                }
                ctx.SaveChanges();
                return "撤销成功";
            }
        }

        //分配病房的函数
        public string contribute(string patient_ID, string ward_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var patient = ctx.Patients.AsNoTracking().SingleOrDefault(e => e.patient_ID == patient_ID);
                if (patient == null)
                {
                    return "没找到id=" + patient_ID + "的病人";
                }
                var ward = ctx.Wards.AsNoTracking().SingleOrDefault(e => e.ward_ID == ward_ID);
                if (ward.is_full == 1)
                {
                    return "你要分配的病房已经满了";
                }
                if (patient.patient_ward != null)
                {
                    return "病人已经分配病房，请先删除原分配的病房";
                }
                //Linq 查询 - 自动转译 T-SQL 语句
                var query1 = from item in ctx.Patients
                             where item.patient_ID == patient_ID
                             select item;
                //查询到对象后，修改对象属性
                foreach (var item in query1)
                {
                    item.patient_ward = ward_ID;
                    break;
                }
                ctx.SaveChanges();
                var count = ctx.Patients.AsNoTracking()
                    .Where(e => e.patient_ward == ward_ID).Count();
                if (count == ward.capacity)
                {
                    //Linq 查询 - 自动转译 T-SQL 语句
                    var query2 = from item in ctx.Wards
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
                var Patients = ctx.Patients.AsNoTracking()
                    .Where(e => e.patient_ward == ward_id).ToList();
                List<PatientDTO> list = new List<PatientDTO>();
                foreach (var p in Patients)
                {
                    list.Add(ToDTO(p));
                }
                return list;
            }
        }
        //给病人分配护士护理
        public string contributenurse(string nurse_ID, string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                foreach (var item in ctx.Patient_cares)
                {
                    if (item.nur_ID == nurse_ID && item.patient_ID == patient_ID)
                    {
                        return "当前的护士已经分配护理该病人";
                    }
                }
                var nurse = ctx.Nurses.AsNoTracking().SingleOrDefault(e => e.nurse_ID == nurse_ID);
                if (nurse == null)
                {
                    return "没有找到该护士";
                }
                Patient_care s = new Patient_care();
                s.nur_ID = nurse_ID;
                s.patient_ID = patient_ID;
                var patient = ctx.Patients.AsNoTracking().SingleOrDefault(e => e.patient_ID == patient_ID);
                s.ward_ID = patient.patient_ward;
                ctx.Patient_cares.Add(s);
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
                foreach (var item in ctx.Patient_cares.ToList())
                {
                    if (item.patient_ID == patient_ID)
                    {

                        nurse_ID = item.nur_ID;
                        var nurse = ctx.Nurses.AsNoTracking().SingleOrDefault(e => e.nurse_ID == nurse_ID);
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
        private PatientDTO ToDTO(Patient s)
        {


            PatientDTO dto = new PatientDTO();
            dto.patient_name = s.patient_name;
            dto.patient_sex = s.patient_sex;
            dto.patient_ID = s.patient_ID;
            //dto.patient_ward_dept = s.ward.ward_dept;
            dto.patient_ward = s.patient_ward;
            dto.patient_age = s.patient_age;
            return dto;

        }
        private Patient_careDTO CareToDTO(Patient_care s)
        {
            Patient_careDTO dto = new Patient_careDTO();
            dto.patient_ID = s.patient_ID;
            dto.nur_ID = s.nur_ID;
            dto.ward_ID = s.ward_ID;
            dto.name = s.name;
            dto.content = s.content;
            dto.start_time = s.start_time.ToString();
            return dto;
        }

        private NurseDTO ToNurseDTO(Nurse s)
        {
            NurseDTO dto = new NurseDTO();
            dto.nurse_ID = s.nurse_ID;
            dto.nurse_name = s.nurse_name;
            dto.position = s.position;
            dto.salary = s.salary;
            dto.sex = s.sex;
            dto.nurse_dept = s.nurse_name;
            return dto;
        }

        public string AddNew(string patient_ID, string patient_name, int patient_age, string patient_sex,string patient_ward)
        {
            
            using (MyContext ctx = new MyContext())
            {
                
                var pat = ctx.Wards.SingleOrDefault(pp => pp.ward_ID == patient_ward);
                if(pat == null)
                {
                    return "NO1";
                }
                var pat1 = ctx.Patients.SingleOrDefault(pp => pp.patient_ID == patient_ID);
                    if (pat1 != null)
                        return "NO2";
                Patient p = new Patient();
                p.patient_ID = patient_ID;
                p.patient_name = patient_name;
                p.patient_age = patient_age;
                p.patient_sex = patient_sex;
                p.patient_ward = patient_ward;
                ctx.Patients.Add(p);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public string Delete(string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var pat = ctx.Patients.SingleOrDefault(p=>p.patient_ID == patient_ID); 
                
                ctx.Patients.Remove(pat);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public string Change(string opatient_ID,string patient_ID, string patient_name,int patient_age, string patient_sex, string patient_ward)
        {
            using (MyContext ctx = new MyContext())
            {
                
                
                var pat1 = ctx.Wards.SingleOrDefault(pp => pp.ward_ID == patient_ward);
                if(pat1 == null)
                {
                    return "NO2";
                }
                var pat = ctx.Patients.SingleOrDefault(pp => pp.patient_ID == opatient_ID);
                ctx.Patients.Remove(pat);
                ctx.SaveChanges();

                Patient p = new Patient();
                p.patient_ID = patient_ID;
                p.patient_name = patient_name;
                p.patient_age = patient_age;
                p.patient_sex = patient_sex;
                p.patient_ward = patient_ward;
                ctx.Patients.Add(p);
                ctx.SaveChanges();

            }
            return "YES";
        }

        public IEnumerable<PatientDTO> GetByID(string patient_ID)
        {   
            using (MyContext ctx = new MyContext())
            {
                
                var pp = ctx.Patients.AsNoTracking().Where(e => e.patient_ID == patient_ID);
                List<PatientDTO> list = new List<PatientDTO>();
                foreach(var p in pp)
                {
                    PatientDTO pdto = new PatientDTO();
                    pdto.patient_ID = p.patient_ID;
                    pdto.patient_name = p.patient_name;
                    pdto.patient_age = p.patient_age;
                    pdto.patient_sex = p.patient_sex;
                    pdto.patient_ward = p.patient_ward;
                    list.Add(pdto);

                }
                return list;
            }
        }

        public IEnumerable<PatientDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<PatientDTO> list = new List<PatientDTO>();
                foreach(var p in ctx.Patients)
                {
                    var dto = new PatientDTO();
                    dto.patient_ID = p.patient_ID;
                    dto.patient_name = p.patient_name;
                    dto.patient_sex = p.patient_sex;
                    dto.patient_age = p.patient_age;
                    dto.patient_ward = p.patient_ward;
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
