using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hosptialService1.EFconfig
{
    class DepartmentConfig : EntityTypeConfiguration<Department>
    {
        public DepartmentConfig()
        {
            //在这里写约束
            ToTable("department");
            Property(e => e.dept_name).IsRequired();
        }
    }
    
}
