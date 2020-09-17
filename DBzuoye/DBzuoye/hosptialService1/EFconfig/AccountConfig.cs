using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hosptialService1.EFconfig
{
    class AccountConfig:EntityTypeConfiguration<Account>
    {
        public AccountConfig()
        {
            //在这里写约束
            ToTable("account");
            Property(e => e.user_ID).IsRequired();
            Property(e => e.name).HasMaxLength(100).IsRequired();
            Property(e => e.password).HasMaxLength(100).IsRequired();
            Property(e => e.account_type).HasMaxLength(100).IsRequired();
        }
    }
}
