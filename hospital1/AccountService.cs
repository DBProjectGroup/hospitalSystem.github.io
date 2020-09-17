using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;


namespace hospital1
{
    public class AccountService
    {
        //添加账号函数
        public void AddNew(string userID, string password, string name, string type)
        {
            using (MyContext ctx = new MyContext())
            {
                Account account = new Account();
                Register register = new Register();
                register.ID = userID;
                register.login_time= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                account.user_ID = userID;
                account.password = password;
                account.name = name;
                account.account_type = type;
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
                ctx.Registers.Add(register);
                ctx.SaveChanges();
            }
        }
        //删除账号函数 （很少用到）
        public void Delete(string userID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Accounts.SingleOrDefault(e => e.user_ID == userID);
                if(s==null)
                {
                    throw new ArgumentException("所需要删除账号不存在");
                }
                ctx.Accounts.Remove(s);
                ctx.SaveChanges();
            }
        }
        //修改账号密码函数
        public bool Update(string userID,string name,string pass)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Accounts.SingleOrDefault(e => e.user_ID == userID);
                if (s == null)
                {
                    return false;
                    throw new ArgumentException("所需要修改账号不存在");
                }
                else if (s.name == name)
                {
                    s.password = pass;
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool Update(string userID, string pass)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Accounts.SingleOrDefault(e => e.user_ID == userID);
                if (s == null)
                {
                    return false;
                    throw new ArgumentException("所需要修改账号不存在");
                }
                    s.password = pass;
                    ctx.SaveChanges();
                    return true;
            }
        }
        //根据账号 返回账号信息
        public AccountDTO GetById(string ID)
        {
            using (MyContext ctx=new MyContext())
            {
                var s = ctx.Accounts.AsNoTracking().SingleOrDefault(e => e.user_ID==ID);
                if (s == null)
                    return null;
                AccountDTO dto = new AccountDTO();
                dto.user_ID = s.user_ID;
                dto.password = s.password;
                dto.name = s.name;
                dto.account_type = s.account_type;
                return dto;
            }
        }
        //根据账号某一属性 返回这一系列账号
        public IEnumerable<AccountDTO> GetByAcId(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var si = ctx.Accounts.AsNoTracking().Where(e => e.user_ID == ID);
                List<AccountDTO> accountDTOs = new List<AccountDTO>();
                if (si == null)
                { return null; }
                foreach(var s in si)
                {
                    AccountDTO dto = new AccountDTO();
                    dto.user_ID = s.user_ID;
                    dto.password = s.password;
                    dto.name = s.name;
                    dto.account_type = s.account_type;
                    accountDTOs.Add(dto);
                }    
                return accountDTOs;
            }
        }
        //登录时 检查账号 密码是否正确
        public AccountDTO Login(string ID,string pass)
        {
            AccountDTO accountnow = GetById(ID);
            if (accountnow == null)
                return null;
            else
            {
                if (accountnow.password == pass)
                    return accountnow;
                else return null;
            }
        }
    }
}
