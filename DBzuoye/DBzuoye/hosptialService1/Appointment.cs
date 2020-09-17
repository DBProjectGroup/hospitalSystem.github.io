using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosptialService1
{
    public class Appointment
    {
        [Key]
        [Column(Order = 0)]
        public string ap_dept { get; set; }
        [Key]
        [Column(Order = 1)]
        public string ap_patient { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime date { get; set; }

    }
}
