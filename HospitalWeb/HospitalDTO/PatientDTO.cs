using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDTO
{
    public class PatientDTO
    {
        public string patient_ID { get; set; }
        public string patient_name { get; set; }
        public int patient_age { get; set; }
        public string patient_sex { get; set; }
        public string patient_ward { get; set; }
        public string patient_ward_dept { get; set; }
        //public virtual ICollection<patient_care> patient_care { get; set; }

        //public virtual ward ward { get; set; }
    }
}
