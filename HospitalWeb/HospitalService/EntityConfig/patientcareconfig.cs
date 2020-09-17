using System;
using EFEntites;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.EntityConfig
{
    
    //public string patient_ID { get; set; }
    //public string nur_ID { get; set; }
    //public System.DateTime start_time { get; set; }
    //public string name { get; set; }
    //public string content { get; set; }
    //public Nullable<int> ward_ID { get; set; }

    //public virtual nurse nurse { get; set; }
    //public virtual patient patient { get; set; }
    class patientcareconfig : EntityTypeConfiguration<patient_care>
    {
        public patientcareconfig()
        {
            ToTable("patient_care");
            this.HasKey(e => e.pat_ID);
            this.HasKey(e => e.nur_ID);
            this.HasKey(e => e.start_time);
            Property(e => e.pat_ID).HasMaxLength(10).IsRequired();
            Property(e => e.nur_ID).HasMaxLength(10).IsRequired();
            Property(e => e.start_time).IsRequired();
            Property(e => e.name).HasMaxLength(10);
            Property(e => e.content).HasMaxLength(30);
            Property(e => e.ward_ID).HasMaxLength(10);
            HasRequired(e => e.nurse).WithMany().HasForeignKey(e => e.nur_ID);
            HasRequired(e => e.patient).WithMany().HasForeignKey(e => e.pat_ID);
            HasRequired(e => e.ward).WithMany().HasForeignKey(e => e.ward_ID);
        }
    }
}
