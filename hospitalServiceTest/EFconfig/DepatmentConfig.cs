using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    class DepartmentConfig:EntityTypeConfiguration<Department>
    {
        public DepartmentConfig()
        {
            ToTable("department");
            Property(e => e.dept_name).IsRequired();
            Property(e => e.dir_name).HasMaxLength(100).IsRequired();
            Property(e => e.dir_ID).IsRequired();
            Property(e => e.room_ID).IsRequired();
            Property(e => e.people_num).IsRequired();
        }
    }
}
