using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class Department 
    {
        [Key]
        public string dept_name { get; set; }
        public string dir_name { get; set; }
        public string dir_ID { get; set; }
        public int room_ID { get; set; }
        public int people_num { get; set; }
    }
}

