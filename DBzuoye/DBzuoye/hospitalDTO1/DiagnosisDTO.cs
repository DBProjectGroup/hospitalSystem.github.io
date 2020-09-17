using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalDTO1
{
    public class DiagnosisDTO
    {

        public string doc_ID { get; set; }

        public string dia_patient { get; set; }

        public int visit_ID { get; set; }
        public string med_ID { get; set; }
        public int med_Num { get; set; }
        public string date { get; set; }
        public string result { get; set; }

        public string patient_name { get; set; }
    }
}
