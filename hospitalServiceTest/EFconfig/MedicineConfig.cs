using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    public class MedicineConfig : EntityTypeConfiguration<Medicine>
    {
        public MedicineConfig()
        {
            ToTable("medicine");
            Property(e => e.med_ID).HasMaxLength(10).IsRequired();
            Property(e => e.med_name).HasMaxLength(20);
            Property(e => e.unit).HasMaxLength(5);
            Property(e => e.producer).HasMaxLength(20);
            HasKey(e => e.med_ID);
        } 
    }
}
