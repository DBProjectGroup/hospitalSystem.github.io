using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalService.EntityConfig
{
    //public string dept_name { get; set; }
    //public string dir_name { get; set; }
    //public int dir_ID { get; set; }
    //public Nullable<int> room_ID { get; set; }
    //public Nullable<int> people_num { get; set; }
    class departmentconfig : EntityTypeConfiguration<department>
    {
        public departmentconfig()
        {
            ToTable("department");
            //this.HasKey(e => e.user_ID);
            Property(e => e.dept_name).HasMaxLength(20).IsRequired();
            Property(e => e.dir_name).HasMaxLength(10);
            Property(e => e.dir_ID).IsRequired();


        }
    }
}