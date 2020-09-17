using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hosptialService1
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=connStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly()
                );
        }

        //每多一张表，多加一句
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Diagnosis> diagnosises { get; set; }

        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Patient_care> patient_cares { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
