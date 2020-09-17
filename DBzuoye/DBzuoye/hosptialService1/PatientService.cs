using hospitalDTO1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosptialService1
{
     public class PatientService
    {
        public string AddNew(string patient_ID, string patient_name, int patient_age, string patient_sex,string patient_ward)
        {
            
            using (MyContext ctx = new MyContext())
            {
                var pat = ctx.patients.Where(pp => pp.patient_ward == patient_ward);
                if(pat.Count()==0)
                {
                    return "NO1";
                }
                var pat1 = ctx.patients.SingleOrDefault(pp => pp.patient_ID == patient_ID);
                    if (pat1 != null)
                        return "NO2";
                Patient p = new Patient();
                p.patient_ID = patient_ID;
                p.patient_name = patient_name;
                p.patient_age = patient_age;
                p.patient_sex = patient_sex;
                p.patient_ward = patient_ward;
                ctx.patients.Add(p);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public string Delete(string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var pat = ctx.patients.SingleOrDefault(p=>p.patient_ID == patient_ID); 
                
                ctx.patients.Remove(pat);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public string Change(string opatient_ID,string patient_ID, string patient_name,int patient_age, string patient_sex, string patient_ward)
        {
            using (MyContext ctx = new MyContext())
            {
                var pat1 = ctx.patients.Where(pp => pp.patient_ward == patient_ward);
                if (pat1.Count() == 0)
                {
                    return "NO1";
                }
                var pat2 = ctx.patients.SingleOrDefault(pp => pp.patient_ID == patient_ID);
                if (pat2 != null)
                    return "NO2";
                var pat = ctx.patients.SingleOrDefault(pp => pp.patient_ID == opatient_ID);
                ctx.patients.Remove(pat);
                ctx.SaveChanges();

                Patient p = new Patient();
                p.patient_ID = patient_ID;
                p.patient_name = patient_name;
                p.patient_age = patient_age;
                p.patient_sex = patient_sex;
                p.patient_ward = patient_ward;
                ctx.patients.Add(p);
                ctx.SaveChanges();

            }
            return "YES";
        }

        public IEnumerable<PatientDTO> GetByID(string patient_ID)
        {   
            using (MyContext ctx = new MyContext())
            {
                
                var pp = ctx.patients.AsNoTracking().Where(e => e.patient_ID == patient_ID);
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
                foreach(var p in ctx.patients)
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
