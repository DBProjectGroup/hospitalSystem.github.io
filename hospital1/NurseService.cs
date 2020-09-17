using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;

namespace hospital1
{
    public class NurseService
    {
        public void AddNew(Nurse nurse)
        {
            using (MyContext ctx = new MyContext())
            {
                Nurse nurse1 = new Nurse();
                nurse1 = nurse;
                ctx.Nurses.Add(nurse1);
                ctx.SaveChanges();
            }
        }
        public void AddNew(Account NurseAcc, string dept, string pos, float salary, string sex)
        {
            using (MyContext ctx = new MyContext())
            {
                Nurse nurse = new Nurse();
                nurse.nurse_ID = NurseAcc.user_ID;
                nurse.nurse_name = NurseAcc.name;
                nurse.nurse_dept = dept;
                nurse.position = pos;
                nurse.salary = salary;
                nurse.sex = sex;
                ctx.Nurses.Add(nurse);
                ctx.SaveChanges();
            }
        }
    }
}
