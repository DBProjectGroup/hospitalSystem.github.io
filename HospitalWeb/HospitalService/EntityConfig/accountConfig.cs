using HospitalDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntites.EntityConfig
{
    class accountConfig : EntityTypeConfiguration<account>
    {

        //public int user_ID { get; set; }
        //public string name { get; set; }
        //public string password { get; set; }
        //public string account_type { get; set; }
        public accountConfig()
        { 
            ToTable("account");
            //this.HasKey(e => e.user_ID);
            Property(e => e.user_ID).IsRequired();
            Property(e => e.name).IsRequired();
            Property(e => e.password).IsRequired();
            Property(e => e.account_type).IsRequired();
            
        }
    } 
}
