using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosptialService1
{
    public class Account:Base
    {
        [Key]
        public string user_ID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string account_type { get; set; }
 

        //外键拍扁
    }
}
