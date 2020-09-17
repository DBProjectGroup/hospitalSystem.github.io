using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hosptialService1.EFconfig
{
    class DiagnosisConfig : EntityTypeConfiguration<Diagnosis>
    {
        public DiagnosisConfig()
        {
            //在这里写约束
            ToTable("diagnosis");
           Property(e => e.doc_ID).IsRequired();
           Property(e => e.dia_patient).IsRequired();
           Property(e => e.visit_ID).IsRequired();
        }
    }
}
