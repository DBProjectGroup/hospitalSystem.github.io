using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.EntityConfig
{
    //public int device_ID { get; set; }
    //public string device_name { get; set; }
    //public string device_dept { get; set; }
    //public int device_mark { get; set; }
    //public string device_info { get; set; }

    //public virtual department department { get; set; }
    class deviceconfig : EntityTypeConfiguration<device>
    {
        public deviceconfig()
        {
            ToTable("device");
            Property(e => e.device_ID).IsRequired();
            Property(e => e.device_name).HasMaxLength(20).IsRequired();
            Property(e => e.device_mark).IsRequired();
            Property(e => e.device_dept).HasMaxLength(20);
            Property(e => e.device_info).HasMaxLength(50);
            HasRequired(e => e.department).WithMany().HasForeignKey(e => e.device_dept);
        }

    }
}
