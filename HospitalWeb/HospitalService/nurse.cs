using EFEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService
{
    public class nurse
    {
        //public nurse()
        //{
        //    this.patient_care = new HashSet<patient_care>();
        //}
        [Key]
        public string nurse_ID { get; set; }
        public string nurse_name { get; set; }
        public string sex { get; set; }
        public string nurse_dept { get; set; }
        public string position { get; set; }
        public Nullable<float> salary { get; set; }

        public virtual account account { get; set; }
        public virtual department department { get; set; }
        //public virtual ICollection<patient_care> patient_care { get; set; }
    }
}
