using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class Patient_care
    {
        [Key]
        [Column(Order = 0)]
        public string patient_ID { get; set; }
        [Key]
        [Column(Order = 1)]
        public string nur_ID { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public string ward_ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime start_time { get; set; }
    }
}
