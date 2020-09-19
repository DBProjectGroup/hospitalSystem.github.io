using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospital1.EFConfig
{
    class OperationConfig : EntityTypeConfiguration<Operation>
    {
        public OperationConfig()
        {
            ToTable("Operation");
            HasKey(e => e.op_ID);
            Property(e => e.op_ID).HasMaxLength(10).IsRequired();
            Property(e => e.op_name).HasMaxLength(20);
            Property(e => e.op_dept).HasMaxLength(20);
            Property(e => e.op_patient).HasMaxLength(10);
            Property(e => e.date);
         
            //HasRequired(e => e.account).WithOptional().WillCascadeOnDelete();
        }
    }
}
