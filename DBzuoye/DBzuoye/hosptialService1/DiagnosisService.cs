using hospitalDTO1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace hosptialService1
{
     public class DiagnosisService
    {
        
        public IEnumerable<DiagnosisDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<DiagnosisDTO> list = new List<DiagnosisDTO>();
                foreach(var p in ctx.diagnosises)
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
                var diags = ctx.diagnosises.AsNoTracking().Where(e => e.dia_patient == dia_patient);
                List<DiagnosisDTO> list = new List<DiagnosisDTO>();
                DiagnosisDTO dia = new DiagnosisDTO();
                foreach (var s in diags)
                {
                   
                    dia.doc_ID = s.doc_ID;
                    dia.dia_patient = s.dia_patient;
                    dia.date = s.date.ToString();
                    dia.med_Num = s.med_Num;
                    dia.med_ID = s.med_ID;
                    dia.result = s.result;

                    list.Add(dia);
                }
                

                PatientService pa1 = new PatientService();
                var dia1 = pa1.GetByID(dia_patient);

                foreach (var s in dia1)
                {

                    dia.patient_name = s.patient_name;

                    list.Add(dia);
                }
                return list;

            }
        }
    }
}
