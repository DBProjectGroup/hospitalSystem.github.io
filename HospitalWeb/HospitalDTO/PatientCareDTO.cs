using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDTO
{
    public class PatientCareDTO
    {
        public string pat_ID { get; set; }
        public string patient_name { get; set; }
        public string nur_ID { get; set; }
        public string nurse_name { get; set; }
        public System.DateTime start_time { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public string ward_ID { get; set; }

    }
}
