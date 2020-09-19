using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospital1.EFConfig
{
    class BillConfig : EntityTypeConfiguration<Bill>
    {
        public BillConfig()
        {
            ToTable("patient_bill");
            Property(e => e.bill_ID).HasMaxLength(10).IsRequired();
            Property(e => e.bill_patient).HasMaxLength(10);
            Property(e => e.type).HasMaxLength(10);
            Property(e => e.cost).IsRequired();
            HasKey(e => e.bill_ID);
        }
    }
}
