using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService
{
    public class patient
    {
        //public patient()
        //{
        //    this.patient_care = new HashSet<patient_care>();
        //}
        [Key]
        public string patient_ID { get; set; }
        public string patient_name { get; set; }
        public int patient_age { get; set; }
        public string patient_sex { get; set; }
        public string patient_ward { get; set; }
        
        //public virtual ICollection<patient_care> patient_care { get; set; }
        
        public virtual ward ward { get; set; }
    }
}
