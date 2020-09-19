using hospital1;
using hospitalService;
using HospitalService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
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

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnosises { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient_care> Patient_cares { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<device> devices { get; set; }
        public DbSet<account> accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Operation> operations { get; set; }
        public DbSet<Operation_participate> Operation_Participates { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
