using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.EntityConfig
{
    //public string ward_ID { get; set; }
    //public string ward_dept { get; set; }
    //public int is_full { get; set; }
    //public int capacity { get; set; }

    //public virtual department department { get; set; }
    public class wardConfig : EntityTypeConfiguration<ward>
    {
        public wardConfig()
        {
            ToTable("ward");
            this.HasKey(e => e.ward_ID);
            Property(e => e.ward_ID).IsRequired();
            Property(e => e.ward_dept).HasMaxLength(20).IsRequired();
            Property(e => e.is_full).IsRequired();
            HasRequired(e => e.department).WithMany().HasForeignKey(e => e.ward_dept);
        }
    }
}
