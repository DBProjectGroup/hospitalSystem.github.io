using HospitalService;
using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService
{
    public class account
    {
        [Key]
        public string user_ID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string account_type { get; set; }
        public virtual Nurse nurse { get; set; }
    }
}
