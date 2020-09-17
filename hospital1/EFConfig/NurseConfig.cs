using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace hospital1.EFConfig
{
    class NurseConfig : EntityTypeConfiguration<Nurse>
    {
        public NurseConfig()
        {
            ToTable("nurse");
            HasKey(e => e.nurse_ID);
            Property(e => e.nurse_ID).HasMaxLength(10).IsRequired();
            Property(e => e.nurse_name).HasMaxLength(10).IsRequired();
            Property(e => e.nurse_dept).HasMaxLength(20).IsRequired();
            Property(e => e.position).HasMaxLength(10);
            Property(e => e.salary);
            Property(e => e.sex).HasMaxLength(2);
            //HasRequired(e => e.account).WithOptional().WillCascadeOnDelete();
        }

    }
}
