using hospitalDTO;
using HospitalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class DoctorService
    {
        public void AddNew(account doctorAcc, string dept, string pos, float salary, int age, string sex)
        {

            using (MyContext ctx = new MyContext())
            {
                Doctor doctor1 = new Doctor();
                doctor1.doctor_ID = doctorAcc.user_ID;
                doctor1.doctor_name = doctorAcc.name;
                doctor1.doctor_dept = dept;
                doctor1.doctor_position = pos;
                doctor1.salary = salary;
                doctor1.age = age;
                doctor1.sex = sex;
                doctor1.is_arranged = 0;
                ctx.Doctors.Add(doctor1);
                ctx.SaveChanges();
            }
        }
        public void Delete(string userID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == userID);
                if (s == null)
                {
                    throw new ArgumentException("所需要删除账号不存在");
                }
                ctx.Doctors.Remove(s);
                ctx.SaveChanges();
            }
        }
        private DoctorDTO ToDTO(Doctor doc)
        {
            DoctorDTO dto = new DoctorDTO();
            dto.doctor_ID = doc.doctor_ID;
            dto.doctor_name = doc.doctor_name;
            dto.doctor_dept = doc.doctor_dept;
            dto.doctor_position = doc.doctor_position;
            dto.salary = doc.salary;
            dto.age = doc.age;
            dto.sex = doc.sex;
            dto.is_arranged = doc.is_arranged;
            return dto;
        }

        public IEnumerable<DoctorDTO> DisplayDoctorSalary()
        {
            using (MyContext ctx = new MyContext())
            {
                List<DoctorDTO> doclist = new List<DoctorDTO>();
                foreach (var doc in ctx.Doctors)
                {
                    doclist.Add(ToDTO(doc));
                }
                return doclist;
            }
        }

        public IEnumerable<DoctorDTO> QueryByID(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var docset = ctx.Doctors.AsNoTracking().Where(e => e.doctor_ID == ID);
                List<DoctorDTO> doclist = new List<DoctorDTO>();
                foreach (var doc in docset)
                {
                    doclist.Add(ToDTO(doc));
                }
                return doclist;
            }
        }

        public float RetrunDoctorTotalSalary()
        {
            using (MyContext ctx = new MyContext())
            {
                float total = 0;
                foreach (var doc in ctx.Doctors)
                {
                    total += doc.salary;
                }
                return total;
            }
        }

        public void ChangeDoctorState(string doctor_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == doctor_ID);
                if (s.is_arranged == 0)
                    s.is_arranged = 1;
                else s.is_arranged = 0;
                ctx.SaveChanges();
            }
        }

        public void NextMonth()
        {
            using (MyContext ctx = new MyContext())
            {
                var docset = ctx.Doctors;
                foreach (var doc in docset)
                {
                    if (doc.is_arranged == 1)
                        doc.is_arranged = 0;
                }
                ctx.SaveChanges();
            }
        }

        public int RtState(string doctor_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == doctor_ID);
                return s.is_arranged;
            }
        }

    public IEnumerable<DoctorDTO> GetByID(string doctor_ID)
        {

            using (MyContext ctx = new MyContext())
            {

                var pp = ctx.Doctors.AsNoTracking().Where(e => e.doctor_ID == doctor_ID);
                List<DoctorDTO> list = new List<DoctorDTO>();
                foreach (var p in pp)
                {
                    DoctorDTO pdto = new DoctorDTO();
                    pdto.doctor_name = p.doctor_name;
                    list.Add(pdto);

                }
                return list;
            }
        }

        public string AddNewDoctor(string doctor_ID, string doctor_name, string doctor_dept, 
            string doctor_position, float salary, int age, string sex, int is_arranged)
        {
            using (MyContext ctx = new MyContext())
            {
                var f = ctx.Departments.SingleOrDefault(e => e.dept_name == doctor_dept);
                if (f == null)
                {
                    return "NO";
                }
                Doctor s = new Doctor();
                s.doctor_ID = doctor_ID;
                s.doctor_name = doctor_name;
                s.doctor_dept = doctor_dept;
                s.doctor_position = doctor_position;
                s.salary = salary;
                s.sex = sex;
                s.age = age;
                s.is_arranged = is_arranged;
                ctx.Doctors.Add(s);
                ctx.SaveChanges();
            }
            return "YES";
        }
        public void DeleteDoctorByID(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var doc = ctx.Doctors.SingleOrDefault(s=>s.doctor_ID == ID);
                if (doc == null)
                {
                    throw new ArgumentException("抱歉！并为找到ID为" + ID + "的医生！");
                }
                ctx.Doctors.Remove(doc);
                ctx.SaveChanges();
            }
        }

        public string ChangeDoctorByID(string p_ID,string doctor_ID, string doctor_name, string doctor_dept,
            string doctor_position, float salary, int age, string sex, int is_arranged)//按ID查找后进行修改
        {
            using (MyContext ctx = new MyContext())
            {
                var f = ctx.Departments.SingleOrDefault(e => e.dept_name == doctor_dept);
                if (f == null)
                {
                    return "NO";
                }
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == p_ID);
                
                s.doctor_ID = doctor_ID;
                s.doctor_name = doctor_name;
                s.doctor_dept = doctor_dept;
                s.doctor_position = doctor_position;
                s.salary = salary;
                s.sex = sex;
                s.age = age;
                s.is_arranged = is_arranged;
                
                ctx.SaveChanges();
            }
            return "YES";
        }

        public IEnumerable<DoctorDTO> GetDoctorByID(string ID)//按ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == ID);
                if(s == null)
                {
                    return null;
                }
                List<DoctorDTO> list = new List<DoctorDTO>();
                DoctorDTO dto = new DoctorDTO();
                dto.doctor_ID = s.doctor_ID;
                dto.doctor_name = s.doctor_name;
                dto.doctor_dept = s.doctor_dept;
                dto.doctor_position = s.doctor_position;
                dto.salary = s.salary;
                dto.sex = s.sex;
                dto.age = s.age;
                dto.is_arranged = s.is_arranged;
                list.Add(dto);
                return list;
            }
        }

        public DoctorDTO GetDoctorByIDe(string ID)//按ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == ID);
                if (s == null)
                {
                    return null;
                }
                DoctorDTO dto = new DoctorDTO();
                dto.doctor_ID = s.doctor_ID;
                dto.doctor_name = s.doctor_name;
                dto.doctor_dept = s.doctor_dept;
                dto.doctor_position = s.doctor_position;
                dto.salary = s.salary;
                dto.sex = s.sex;
                dto.age = s.age;
                dto.is_arranged = s.is_arranged;
                return dto;
            }
        }


        public IEnumerable<DoctorDTO> GetDoctorByName(string doctor_name)//按名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var docs = ctx.Doctors.Where(e => e.doctor_name == doctor_name);
                if (docs == null)
                {
                    return null;
                }
                List<DoctorDTO> list = new List<DoctorDTO>();
                foreach (var s in docs)
                {
                    DoctorDTO dto = new DoctorDTO();
                    dto.doctor_ID = s.doctor_ID;
                    dto.doctor_name = s.doctor_name;
                    dto.doctor_dept = s.doctor_dept;
                    dto.doctor_position = s.doctor_position;
                    dto.salary = s.salary;
                    dto.sex = s.sex;
                    dto.age = s.age;
                    dto.is_arranged = s.is_arranged;
                    list.Add(dto);
                }
                return list;
            }
        }
        public IEnumerable<DoctorDTO> GetAllDoctor()//按名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var docs = ctx.Doctors;
                if (docs == null)
                {
                    return null;
                }
                List<DoctorDTO> list = new List<DoctorDTO>();
                foreach (var s in docs)
                {
                    DoctorDTO dto = new DoctorDTO();
                    dto.doctor_ID = s.doctor_ID;
                    dto.doctor_name = s.doctor_name;
                    dto.doctor_dept = s.doctor_dept;
                    dto.doctor_position = s.doctor_position;
                    dto.salary = s.salary;
                    dto.sex = s.sex;
                    dto.age = s.age;
                    dto.is_arranged = s.is_arranged;
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
