using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService
{
    public class device
    {
        [Key]
        public string device_ID { get; set; }
        public string device_name { get; set; }
        public string device_dept { get; set; }
        public int device_mark { get; set; }
        public string device_info { get; set; }

        public virtual department department { get; set; }
    }
}
