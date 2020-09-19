using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospital1.EFConfig
{
    class RegisterConfig : EntityTypeConfiguration<Register>
    {
        public RegisterConfig()
        {
            ToTable("register");
            HasKey(e => e.ID);
            Property(e => e.ID).HasMaxLength(10).IsRequired();
            Property(e => e.login_time);
            //HasRequired(e => e.account).WithOptional().WillCascadeOnDelete();
        }
    }
}
