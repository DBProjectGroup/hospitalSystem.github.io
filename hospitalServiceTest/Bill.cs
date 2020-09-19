using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class Bill
    {
        public string bill_ID { get; set; }
        [ForeignKey("Patient")]
        public string bill_patient { get; set; }
        public System.DateTime transaction_ti { get; set; }
        public string type { get; set; }
        public float cost { get; set; }

        public Patient Patient { get; set; }
    }
}
