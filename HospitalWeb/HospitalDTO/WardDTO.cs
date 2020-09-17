using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDTO
{
    public class WardDTO
    {
        public string ward_ID { get; set; }
        public string ward_dept { get; set; }
        public int is_full { get; set; }
        public int capacity { get; set; }
    }
}
