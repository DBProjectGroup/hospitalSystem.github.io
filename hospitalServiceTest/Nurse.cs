using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class Nurse
    {
        [Key]
        public string nurse_ID { get; set; }
        public string nurse_name { get; set; }
        public string sex { get; set; }
        public string nurse_dept { get; set; }
        public string position { get; set; }
        public float salary { get; set; }
    }
}
