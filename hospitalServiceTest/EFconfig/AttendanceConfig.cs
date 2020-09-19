using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1.EFConfig
{
    class AttendanceConfig : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfig()
        {
            ToTable("attendance");
            HasKey(e => e.A_ID);
            HasKey(e => e.attend_ID);
            Property(e => e.A_ID).HasMaxLength(10).IsRequired();
            Property(e => e.attend_ID).HasMaxLength(20).IsRequired();
            Property(e => e.attend_time);
        }
    }
}
