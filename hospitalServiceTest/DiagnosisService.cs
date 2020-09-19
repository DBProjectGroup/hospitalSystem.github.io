using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace hospitalServiceTest
{
     public class DiagnosisService
    {
        public void AddNew1(string doc_ID, string dia_patient, string visit_ID, string med_ID, int med_Num, string result)
        {
            using (MyContext ctx = new MyContext())
            {
                Diagnosis diag = new Diagnosis();
                diag.doc_ID = doc_ID;
                diag.dia_patient = dia_patient;
                diag.visit_ID = visit_ID;
                diag.med_ID = med_ID;
                diag.med_Num = med_Num;
                diag.date = DateTime.Now;
                diag.result = result;
                ctx.Diagnosises.Add(diag);
                ctx.SaveChanges();
            }
        }

        private DiagnosisDTO ToDTO(Diagnosis diag)
        {
            DiagnosisDTO dto = new DiagnosisDTO();
            dto.doc_ID = diag.doc_ID;
            dto.dia_patient = diag.dia_patient;
            dto.visit_ID = diag.visit_ID;
            dto.med_ID = diag.med_ID;
            dto.med_Num = diag.med_Num;
            dto.date = diag.date.ToString();
            dto.result = diag.result;

            /*dto.doc_name = diag.Doctor.doctor_name;
            dto.pat_name = diag.Patient.patient_name;
            dto.med_name = diag.Medicine.med_ID;*/
            return dto;
        }

        public IEnumerable<DiagnosisDTO> QueryAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<DiagnosisDTO> diaglist = new List<DiagnosisDTO>();
                foreach (var diag in ctx.Diagnosises)
                {
                    diaglist.Add(ToDTO(diag));
                }
                return diaglist;
            }
        }

        public IEnumerable<DiagnosisDTO> QueryByPatientID(string PatientID)
        {
            using (MyContext ctx = new MyContext())
            {
                var diagset = ctx.Diagnosises.AsNoTracking().Where(e => e.dia_patient == PatientID);
                List<DiagnosisDTO> diaglist = new List<DiagnosisDTO>();
                foreach (var diag in diagset)
                {
                    diaglist.Add(ToDTO(diag));
                }
                return diaglist;
            }
        }

        public void DeleteOld(string doc_ID, string dia_patient, string visit_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var diag = ctx.Diagnosises.SingleOrDefault(s => s.doc_ID == doc_ID && s.dia_patient == dia_patient && s.visit_ID == visit_ID);
                if (diag == null)
                {
                    throw new ArgumentException("未找到该诊断");
                }
                else
                {
                    ctx.Diagnosises.Remove(diag);
                }
                ctx.SaveChanges();
            }
        }

        public IEnumerable<DiagnosisDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<DiagnosisDTO> list = new List<DiagnosisDTO>();
                foreach(var p in ctx.Diagnosises)
                {
                    var dto = new DiagnosisDTO();
                    dto.doc_ID = p.doc_ID;
                    dto.dia_patient = p.dia_patient;
                    dto.date = p.date.ToString();
                    dto.med_ID = p.med_ID;
                    dto.med_Num = p.med_Num;
                    dto.result = p.result;
                    dto.visit_ID = p.visit_ID;
                    list.Add(dto);
                }
                return list;
            }
        }
      


        public IEnumerable<DiagnosisDTO> GetBydia_patient(string dia_patient)
        {
            using (MyContext ctx = new MyContext())
            {
                var diags = ctx.Diagnosises.AsNoTracking().Where(e => e.dia_patient == dia_patient);
                List<DiagnosisDTO> list = new List<DiagnosisDTO>();          
                foreach (var s in diags)
                {
                    DiagnosisDTO dia = new DiagnosisDTO();
                    // dia.doc_ID = s.doc_ID;
                    // dia.dia_patient = s.dia_patient;
                    dia.date = s.date.ToString();
                    dia.med_Num = s.med_Num;
                    dia.med_ID = s.med_ID;
                    dia.result = s.result;
                    dia.visit_ID = s.visit_ID;
                    //dia6.doc_ID = s.doc_ID;

                    PatientService pa1 = new PatientService();
                    var dia1 = pa1.GetByID(dia_patient);

                    foreach (var s1 in dia1)
                    {
                        dia.patient_name = s1.patient_name;
                    }

                    DoctorService pa12 = new DoctorService();
                    var dia2 = pa12.GetByID(s.doc_ID);

                    foreach (var s2 in dia2)
                    {
                        dia.doctor_name = s2.doctor_name;
                    }

                    list.Add(dia);
                }
                
                return list;

            }
        }
    }
}
