using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService
{
    public class patient_care
    {
        [Key]
        public string pat_ID { get; set; }
        public string nur_ID { get; set; }
        public DateTime start_time { get; set; } = DateTime.Now;
        public string name { get; set; }
        public string content { get; set; }
        public string ward_ID { get; set; }

        public virtual nurse nurse { get; set; }
        public virtual patient patient { get; set; }
        public virtual ward ward { get; set; }
    }
}
