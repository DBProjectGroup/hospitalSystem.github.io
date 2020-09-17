using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;

namespace hospital1
{
    public class DoctorService
    {
        public void AddNew(Doctor doctor)
        {
            using (MyContext ctx = new MyContext())
            {
                Doctor doctor1 = new Doctor();
                doctor1 = doctor;
                ctx.Doctors.Add(doctor1);
                ctx.SaveChanges() ;
            }
        }
        public void AddNew(Account doctorAcc,string dept,string pos,float salary,int age,string sex)
        {
            using (MyContext ctx = new MyContext())
            {
                Doctor doctor1 = new Doctor();
                doctor1.doctor_ID = doctorAcc.user_ID;
                doctor1.doctor_name = doctorAcc.name;
                doctor1.doctor_dept = dept;
                doctor1.doctor_position = pos;
                doctor1.salary = salary;
                doctor1.age = age;
                doctor1.sex = sex;
                doctor1.is_arranged = 0;
                ctx.Doctors.Add(doctor1);
                ctx.SaveChanges();
            }
        }
        public void Delete(string userID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == userID);
                if (s == null)
                {
                    throw new ArgumentException("所需要删除账号不存在");
                }
                ctx.Doctors.Remove(s);
                ctx.SaveChanges();
            }
        }
    }

}
