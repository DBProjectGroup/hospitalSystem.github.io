using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    public class DiagnosisConfig : EntityTypeConfiguration<Diagnosis>
    {
        public DiagnosisConfig()
        {
            //在这里写约束
            ToTable("diagnosis");
            Property(e => e.doc_ID).HasMaxLength(10).IsRequired();
            Property(e => e.dia_patient).HasMaxLength(10).IsRequired();
            Property(e => e.visit_ID).IsRequired();
            Property(e => e.med_ID).HasMaxLength(10);
            Property(e => e.result).HasMaxLength(200);
        }
    }
}
