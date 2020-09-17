using hospitalDTO1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosptialService1
{
    public class AppointmentService
    {
        public string AddNew(string ap_dept, string ap_patient, DateTime date)
        {

            using (MyContext ctx = new MyContext())
            {
                var res = ctx.appointments.AsNoTracking().Where(e => e.ap_patient == ap_patient);
                if (res.Count() == 0)
                {
                    return "NO1";
                }
                var res2 = ctx.departments.AsNoTracking().SingleOrDefault(e => e.dept_name == ap_dept);
                if (res2 == null)
                {
                    return "NO2";
                }
                Appointment p = new Appointment();
                p.ap_dept = ap_dept;
                p.ap_patient = ap_patient;
                p.date = date;
                ctx.appointments.Add(p);
                ctx.SaveChanges();

            }
            return "YES";
        }

        public string Delete(string ap_patient,string ap_dept,DateTime date)
        {
            using (MyContext ctx = new MyContext())
            {
                var pa = ctx.appointments.SingleOrDefault(p => p.ap_patient == ap_patient && p.ap_dept == ap_dept && p.date == date);
               
                ctx.appointments.Remove(pa);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public IEnumerable<AppointmentDTO> GetByID(string ap_patient)
        {
            using (MyContext ctx = new MyContext())
            {

                var pp = ctx.appointments.AsNoTracking().Where(e => e.ap_patient == ap_patient);
                List<AppointmentDTO> list = new List<AppointmentDTO>();
                foreach (var p in pp)
                {
                    AppointmentDTO pdto = new AppointmentDTO();
                    pdto.ap_patient = p.ap_patient;
                    pdto.ap_dept = p.ap_dept;
                    pdto.date = p.date.ToString();
                    list.Add(pdto);
                }
                return list;
            }
        }

        public IEnumerable<AppointmentDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<AppointmentDTO> list = new List<AppointmentDTO>();
                foreach (var p in ctx.appointments)
                {
                    var dto = new AppointmentDTO();
                    dto.ap_dept = p.ap_dept;
                    dto.ap_patient = p.ap_patient;
                    dto.date = p.date.ToString();
                    list.Add(dto);
                }
                return list;
            }
        }


        public string Change(string oap_patient, string oap_dept, DateTime odate, string ap_patient, string ap_dept, DateTime date)
        {
            using (MyContext ctx = new MyContext())
            {
                var pat = ctx.appointments.SingleOrDefault(pp => pp.ap_patient == oap_patient && pp.ap_dept == oap_dept && pp.date == odate);
                var pat1 = ctx.appointments.SingleOrDefault(pp => pp.ap_dept == ap_dept);
                var pat2 = ctx.appointments.SingleOrDefault(pp => pp.ap_patient == ap_patient);
                if (pat1 == null)
                {
                    return "NO1";
                }
                if (pat1 == null)
                {
                    return "NO2";
                }
                ctx.appointments.Remove(pat);
                ctx.SaveChanges();

                //patient p = new patient();
                Appointment p = new Appointment();
                //pat.date = date;
                //pat.ap_dept = ap_dept;
                //pat.ap_patient = ap_patient;
                p.date = date;
                p.ap_dept = ap_dept;
                p.ap_patient = ap_patient;
                ctx.appointments.Add(p);
                ctx.SaveChanges();

            }
            return "YES";
        }
    }
}

