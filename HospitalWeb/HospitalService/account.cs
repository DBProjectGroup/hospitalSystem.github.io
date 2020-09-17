using HospitalService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntites
{
    public class account
    {
        [Key]
        public string user_ID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string account_type { get; set; }
        public virtual nurse nurse { get; set; }
    }
}
