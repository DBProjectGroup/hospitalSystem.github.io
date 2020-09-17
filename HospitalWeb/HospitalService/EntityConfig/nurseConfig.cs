using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.EntityConfig
{
    //public string nurse_ID { get; set; }
    //public string nurse_name { get; set; }
    //public string sex { get; set; }
    //public string nurse_dept { get; set; }
    //public string position { get; set; }
    //public Nullable<float> salary { get; set; }

    //public virtual account account { get; set; }
    //public virtual department department { get; set; }
    //public virtual ICollection<patient_care> patient_care { get; set; }
    class nurseConfig : EntityTypeConfiguration<nurse>
    {
        public nurseConfig()
        {
            ToTable("nurse");
            this.HasKey(e => e.nurse_ID);
            Property(e => e.nurse_name).HasMaxLength(10).IsRequired();
            Property(e => e.nurse_ID).HasMaxLength(10).IsRequired();
            Property(e => e.nurse_dept).HasMaxLength(20);
            Property(e => e.position).HasMaxLength(10);
            Property(e => e.sex).HasMaxLength(2);
            HasRequired(e => e.department).WithMany().HasForeignKey(e => e.nurse_dept);
            HasRequired(p => p.account).WithOptional(a => a.nurse);
        }
    }
}
