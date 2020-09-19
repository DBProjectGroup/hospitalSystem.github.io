using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using hospitalService;

namespace hospitalServiceTest.EFconfig
{
    public class WardConfig : EntityTypeConfiguration<Ward>
    {
        public WardConfig()
        {
            ToTable("ward");
            this.HasKey(e => e.ward_ID);
            Property(e => e.ward_ID).IsRequired();
            Property(e => e.ward_dept).HasMaxLength(20).IsRequired();
            Property(e => e.is_full).IsRequired();
            //HasRequired(e => e.department).WithMany().HasForeignKey(e => e.ward_dept);
        }
    }
}
