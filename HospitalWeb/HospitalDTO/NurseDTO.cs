using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDTO
{
    public class NurseDTO
    {
        public string nurse_ID { get; set; }
        public string nurse_name { get; set; }
        public string sex { get; set; }
        public string nurse_dept { get; set; }
        public string position { get; set; }
        public Nullable<float> salary { get; set; }

        public string  account_ID { get; set; }
        public string  dept_name { get; set; }
        //public virtual ICollection<patient_care> patient_care { get; set; }

    }
}
