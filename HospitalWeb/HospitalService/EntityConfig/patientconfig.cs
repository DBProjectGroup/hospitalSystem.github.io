using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.EntityConfig
{
    //public string patient_ID { get; set; }
    //public string patient_name { get; set; }
    //public Nullable<int> patient_age { get; set; }
    //public string patient_sex { get; set; }
    //public string patient_ward { get; set; }

    //public virtual ICollection<patient_care> patient_care { get; set; }

    //public virtual ward ward { get; set; }
    class patientconfig : EntityTypeConfiguration<patient>
    {
        public patientconfig()
        {
            ToTable("patient");
            Property(e => e.patient_ID).HasMaxLength(10).IsRequired();
            Property(e => e.patient_name).HasMaxLength(10).IsRequired();
            Property(e => e.patient_sex).HasMaxLength(2);
            Property(e => e.patient_ward).HasMaxLength(10);
            HasRequired(e => e.ward).WithMany().HasForeignKey(e => e.patient_ward);
        }

    }
}
