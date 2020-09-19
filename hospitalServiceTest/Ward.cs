using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalService
{
    public class Ward
    {
        [Key]
          public string ward_ID { get; set; }
        public string ward_dept { get; set; }
         public int is_full { get; set; }
         public int capacity { get; set; }
    }
}
