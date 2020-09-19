using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HospitalService;

namespace hospital1.EFConfig
{
    class AccountConfig : EntityTypeConfiguration<account>
    {
        public AccountConfig()
        {
            ToTable("account");
            HasKey(e=>e.user_ID);
            Property(e => e.user_ID).HasMaxLength(10).IsRequired();
            Property(e => e.name).HasMaxLength(10).IsRequired();
            Property(e => e.password).IsRequired();
            Ignore(e => e.nurse);
            Property(e => e.account_type).IsRequired();
        }
    }
}
