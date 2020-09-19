using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1.EFConfig
{
    class Operation_participateConfig : EntityTypeConfiguration<Operation_participate>
    {
        public Operation_participateConfig()
        {
            ToTable("operation_participate");
            HasKey(e => e.op_ID);
            HasKey(e => e.person_ID);
            Property(e => e.op_ID).HasMaxLength(10).IsRequired();
            Property(e => e.person_ID).HasMaxLength(10).IsRequired();
        }

    }
}
