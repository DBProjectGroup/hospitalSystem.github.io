using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    public class Patient_careConfig:EntityTypeConfiguration<Patient_care>
    {
        public Patient_careConfig()
        {
            ToTable("patient_care");
            Property(e => e.patient_ID).IsRequired();
            Property(e => e.nur_ID).IsRequired();
            Property(e => e.start_time).IsRequired();
        }
        
    }
}
