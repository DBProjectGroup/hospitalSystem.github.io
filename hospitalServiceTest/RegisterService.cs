using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;
using hospitalServiceTest;

namespace hospital1
{
    public class RegisterService
    {
        public void AddNew(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                Register register = new Register();
                register.ID = ID;
                ctx.Registers.Add(register);
                ctx.SaveChanges();
            }
        }
        public bool Update(string userID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Registers.SingleOrDefault(e => e.ID == userID);
                if (s == null)
                {
                    return false;
                }
               s.login_time= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ctx.SaveChanges();
                return true;
            }
        }
        /*public RegisterDTO GetById(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Accounts.AsNoTracking().SingleOrDefault(e => e.user_ID == ID);
                if (s == null)
                    return null;
                AccountDTO dto = new AccountDTO();
                dto.user_ID = s.user_ID;
                dto.password = s.password;
                dto.name = s.name;
                dto.account_type = s.account_type;
                return dto;
            }
        }*/
    }
}
