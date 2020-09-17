using HospitalDTO;
using HospitalService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFEntites
{
    public class MyContext:DbContext
    {
        public MyContext() : base("name=connStr")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly());
        }
        public DbSet<account> accounts { get; set; }
        public DbSet<nurse> nurses { get; set; }
        public DbSet<department> departments { get; set; }
        public DbSet<ward> wards { get; set; }
        public DbSet<patient> patients { get; set; }
        public DbSet<device> devices { get; set; }
        public DbSet<patient_care> patientCares { get; set; }
    }
}
