using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalDTO
{
    public class MedicineDTO
    {
        public string med_ID { get; set; }
        public string med_name { get; set; }
        public float cost_price { get; set; }
        public float sell_price { get; set; }
        public string unit { get; set; }
        public int num { get; set; }
        public string producer { get; set; }
    }
}
