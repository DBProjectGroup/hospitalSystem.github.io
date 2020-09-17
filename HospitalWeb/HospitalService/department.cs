using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService
{
    public class department
    {
       
        [Key]
        public string dept_name { get; set; }
        public string dir_name { get; set; }
        public int dir_ID { get; set; }
        public Nullable<int> room_ID { get; set; }
        public Nullable<int> people_num { get; set; }
    }
}
