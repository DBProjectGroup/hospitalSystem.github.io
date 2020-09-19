using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalDTO
{
    public class BillDTO
    {
        public string bill_ID { get; set; }
        public string bill_patient { get; set; }
        public string transaction_ti { get; set; }
        public string type { get; set; }
        public float cost { get; set; }

        //public string patient_name { get; set; }
    }
}
