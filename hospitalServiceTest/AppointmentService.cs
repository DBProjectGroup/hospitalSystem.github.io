using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class AppointmentService
    {
        public string AddNew(string ap_dept, string ap_patient, DateTime date)
        {

            using (MyContext ctx = new MyContext())
            {
                var res = ctx.Patients.AsNoTracking().SingleOrDefault(e => e.patient_ID == ap_patient);
                if (res == null)
                {
                    return "NO1";
                }
                var res2 = ctx.Departments.AsNoTracking().SingleOrDefault(e => e.dept_name == ap_dept);
                if (res2 == null)
                {
                    return "NO2";
                }
                Appointment p = new Appointment();
                p.ap_dept = ap_dept;
                p.ap_patient = ap_patient;
                p.date = date;
                ctx.Appointments.Add(p);
                ctx.SaveChanges();

            }
            return "YES";
        }

        public string Delete(string ap_patient, string ap_dept, DateTime date)
        {
            using (MyContext ctx = new MyContext())
            {
                var pa = ctx.Appointments.SingleOrDefault(p => p.ap_patient == ap_patient && p.ap_dept == ap_dept && p.date == date);

                ctx.Appointments.Remove(pa);
                ctx.SaveChanges();
            }
            return "YES";
        }

        public IEnumerable<AppointmentDTO> GetByID(string ap_patient)
        {
            using (MyContext ctx = new MyContext())
            {

                var pp = ctx.Appointments.AsNoTracking().Where(e => e.ap_patient == ap_patient);
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

        public IEnumerable<AppointmentDTO> GetDept(string ap_dept)
        {
            using (MyContext ctx = new MyContext())
            {

                var pp = ctx.Appointments.AsNoTracking().Where(e => e.ap_dept == ap_dept);
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

                foreach (var p in ctx.Appointments)
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
                var pat = ctx.Appointments.SingleOrDefault(pp => pp.ap_patient == oap_patient && pp.ap_dept == oap_dept && pp.date == odate);
                var pat1 = ctx.Departments.SingleOrDefault(pp => pp.dept_name == ap_dept);
                var pat2 = ctx.Patients.SingleOrDefault(pp => pp.patient_ID == ap_patient);
                if (pat1 == null)
                {
                    return "NO1";
                }
                if (pat1 == null)
                {
                    return "NO2";
                }
                ctx.Appointments.Remove(pat);
                ctx.SaveChanges();

                //patient p = new patient();
                Appointment p = new Appointment();
                //pat.date = date;
                //pat.ap_dept = ap_dept;
                //pat.ap_patient = ap_patient;
                p.date = date;
                p.ap_dept = ap_dept;
                p.ap_patient = ap_patient;
                ctx.Appointments.Add(p);
                ctx.SaveChanges();

            }
            return "YES";
        }



        public IEnumerable<AppointmentDTO> GetQueue(string ap_dept)
        {
            using (MyContext ctx = new MyContext())
            {
                var pp = ctx.Appointments.AsNoTracking().Where(e => e.ap_dept == ap_dept);
                List<AppointmentDTO> list = new List<AppointmentDTO>();
                foreach (var p in pp)
                {
                    AppointmentDTO pdto = new AppointmentDTO();
                    pdto.ap_patient = p.ap_patient;
                    pdto.ap_dept = p.ap_dept;
                    pdto.date = p.date.ToString();

                    PatientService pa1 = new PatientService();
                    var dia1 = pa1.GetByID(p.ap_patient);

                    foreach (var s1 in dia1)
                    {
                        pdto.patient_name = s1.patient_name;
                    }
                    list.Add(pdto);
                }
                list = list.OrderBy(e => e.date).ToList();
                return list;

            }
        }
    }
}


