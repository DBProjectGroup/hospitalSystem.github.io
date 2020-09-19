using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace hospitalServiceTest.EFconfig
{
    public class PatientConfig:EntityTypeConfiguration<Patient>
    {
        public PatientConfig()
        {
            ToTable("patient");
            Property(e => e.patient_ID).HasMaxLength(10).IsRequired();
            Property(e => e.patient_name).IsRequired();
            Property(e => e.patient_sex).HasMaxLength(2);
            Property(e => e.patient_ward).HasMaxLength(10);
            Property(e => e.patient_age).IsRequired();
        }
        
    }
}
