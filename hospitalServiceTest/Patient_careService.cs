using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace hospitalServiceTest
{
    public class Patient_careService
    {
        public IEnumerable<Patient_careDTO> GetByID(string patient_ID)
        {
            using (MyContext ctx = new MyContext())
            {

                var pp = ctx.Patient_cares.AsNoTracking().Where(e => e.patient_ID == patient_ID);
                List<Patient_careDTO> list = new List<Patient_careDTO>();
                foreach (var p in pp)
                {
                    Patient_careDTO pdto = new Patient_careDTO();
                    pdto.patient_ID = p.patient_ID;
                    pdto.content = p.content;
                    pdto.name= p.name;
                    pdto.nur_ID = p.nur_ID;
                    pdto.start_time = p.start_time.ToString();
                    pdto.ward_ID = p.ward_ID;
                    list.Add(pdto);

                }
                return list;
            }
        }

        public IEnumerable<Patient_careDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<Patient_careDTO> list = new List<Patient_careDTO>();
                foreach (var p in ctx.Patient_cares)
                {
                    var dto = new Patient_careDTO();
                    dto.patient_ID = p.patient_ID;
                    dto.name = p.name;
                    dto.nur_ID = p.nur_ID;
                    dto.ward_ID = p.ward_ID;
                    dto.start_time = p.start_time.ToString();
                    dto.content = p.content;
                    list.Add(dto);
                }
                return list;
            }
        }

        public string AddNew(string patient_ID,string nur_ID,string name,string content,string ward_ID,DateTime date)
        {
            using (MyContext ctx = new MyContext())
            {
                var pat1 = ctx.Nurses.SingleOrDefault(pp => pp.nurse_ID== nur_ID);
                if (pat1 == null)
                {
                    return "NO1";
                }
                var pat2 = ctx.Patients.SingleOrDefault(pp => pp.patient_ID == patient_ID);
                if (pat2 == null)
                {
                    return "NO2";
                }
                var pat3 = ctx.Wards.SingleOrDefault(pp => pp.ward_ID == ward_ID);
                if (pat3 == null)
                {
                    return "NO3";
                }
                Patient_care p = new Patient_care();
                p.patient_ID = patient_ID;
                p.nur_ID = nur_ID;
                p.name = name;
                p.content = content;
                p.ward_ID = ward_ID;
                p.start_time = date;
                ctx.Patient_cares.Add(p);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public string Delete(string patient_ID,string nur_ID,DateTime start_time)
        {
            using (MyContext ctx = new MyContext())
            {
                
                var pat = ctx.Patient_cares.SingleOrDefault(p => p.patient_ID == patient_ID && p.nur_ID == nur_ID && p.start_time == start_time);
               
                ctx.Patient_cares.Remove(pat);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public string Change(string opatient_ID, string onur_ID, DateTime ostart_time, string patient_ID, string nur_ID, DateTime start_time, string name, string content, string ward_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var pat1 = ctx.Nurses.SingleOrDefault(pp => pp.nurse_ID == nur_ID);
                if (pat1 == null)
                {
                    return "NO1";
                }
                var pat2 = ctx.Patients.SingleOrDefault(pp => pp.patient_ID == patient_ID);
                if (pat2 == null)
                {
                    return "NO2";
                }
                var pat3 = ctx.Wards.SingleOrDefault(pp => pp.ward_ID == ward_ID);
                if (pat3 == null)
                {
                    return "NO3";
                }
                var pat = ctx.Patient_cares.SingleOrDefault(pp => pp.patient_ID == opatient_ID && pp.nur_ID == onur_ID && pp.start_time == ostart_time);
                ctx.Patient_cares.Remove(pat);
                ctx.SaveChanges();

                //patient p = new patient();
                Patient_care p = new Patient_care();
                //pat.date = date;
                //pat.ap_dept = ap_dept;
                //pat.ap_patient = ap_patient;
                p.patient_ID = patient_ID;
                p.nur_ID = nur_ID;
                p.start_time = start_time;
                p.ward_ID = ward_ID;
                p.name = name;
                p.content = content;
                ctx.Patient_cares.Add(p);
                ctx.SaveChanges();
                return "YES";
            }
        }
    }
}
