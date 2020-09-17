using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace hosptialService1.EFconfig
{
    class PatientConfig:EntityTypeConfiguration<Patient>
    {
        public PatientConfig()
        {
            ToTable("patient");
            Property(e => e.patient_ID).IsRequired();
            Property(e => e.patient_name).IsRequired();
            //Property(e => e.patient_age).IsRequired();
            Property(e => e.patient_sex).IsRequired();
        }
        
    }
}
