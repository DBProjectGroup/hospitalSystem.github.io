using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=connStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(
                 Assembly.GetExecutingAssembly()
                );
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Operation> operations { get; set; }
        public DbSet<Operation_participate> Operation_Participates { get; set; }
    }
}
