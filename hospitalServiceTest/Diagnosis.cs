using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class Diagnosis
    {
       [Key]
       [Column(Order = 0)]
       public string doc_ID { get; set; }
       [Key]
        [Column(Order = 1)]
        public string dia_patient { get; set; }
       [Key]
        [Column(Order = 2)]
        public string visit_ID { get; set; }
        public string med_ID { get; set; }
        public int med_Num { get; set; }
        public DateTime date { get; set; }
        public string result { get; set; }
    }
}
