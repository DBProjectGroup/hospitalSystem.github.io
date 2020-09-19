using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    public class AppointmentConfig :EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfig()
        {
            ToTable("appointment");
            Property(e => e.ap_dept).IsRequired();
            Property(e => e.ap_patient).IsRequired();
            Property(e => e.date).IsRequired();
        }

    }
}
