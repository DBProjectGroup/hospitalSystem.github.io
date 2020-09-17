using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosptialService1
{
    public class Patient:Base
    {
        [Key]
        public string patient_ID { get; set; }
        public string patient_name{ get; set; }
        public int patient_age { get; set; }     
        public string patient_sex { get; set; }
        public string patient_ward { get; set; }


    }
}
