
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HospitalDTO;
using hospitalServiceTest;
using hospital1;

namespace HospitalService
{
    
    
    public class accountService
    {
        //添加账号函数
        public bool AddNew1(string userID, string password, string name, string type)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.accounts.AsNoTracking().SingleOrDefault(e => e.user_ID == userID);
                if (s != null||userID==null||name==null|| password==null)
                    return false;
                account account = new account();
                Register register = new Register();
                register.ID = userID;
                register.login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                account.user_ID = userID;
                account.password = password;
                account.name = name;
                account.account_type = type;
                ctx.accounts.Add(account);
                ctx.SaveChanges();
                ctx.Registers.Add(register);
                ctx.SaveChanges();
                return true;
            }
        }
        //删除账号函数 （很少用到）
        public void Delete1(string userID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.accounts.SingleOrDefault(e => e.user_ID == userID);
                if (s == null)
                {
                    throw new ArgumentException("所需要删除账号不存在");
                }
                ctx.accounts.Remove(s);
                ctx.SaveChanges();
            }
        }
        //修改账号密码函数
        public bool Update(string userID, string name, string pass)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.accounts.SingleOrDefault(e => e.user_ID == userID);
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

        //根据账号 返回账号信息
        public AccountDTO GetById1(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.accounts.AsNoTracking().SingleOrDefault(e => e.user_ID == ID);
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
        public string backName(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.accounts.AsNoTracking().SingleOrDefault(e => e.user_ID == ID);
                if (s == null)
                    return null;
                return s.name;
            }
        }
        //根据账号某一属性 返回这一系列账号
        public IEnumerable<AccountDTO> GetByAcId(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var si = ctx.accounts.AsNoTracking().Where(e => e.user_ID == ID);
                List<AccountDTO> accountDTOs = new List<AccountDTO>();
                if (si == null)
                { return null; }
                foreach (var s in si)
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
        public AccountDTO Login(string ID, string pass)
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
        public void AddNew(string user_ID,string name, string password,string account_type)
        {
            using (MyContext ctx = new MyContext())
            {
                account s = new account();
                s.user_ID = user_ID;
                s.name = name;
                s.password = password;
                s.account_type = account_type;
                ctx.accounts.Add(s);
                ctx.SaveChanges();
            }
        }
        public void Change(string oldID, string newpassword)
        {
            using (MyContext ctx = new MyContext())
            {
                //Linq 查询 - 自动转译 T-SQL 语句
                var query = from item in ctx.accounts
                            where item.user_ID == oldID
                            select item;
                //查询到对象后，修改对象属性
                foreach (var item in query)
                {
                    item.password = newpassword;
                    break;
                }
                ctx.SaveChanges();
            }
        }
        public void Delete(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                var stu = ctx.accounts.SingleOrDefault(s => s.user_ID == id);
                if (stu == null)
                {
                    throw new ArgumentException("没找到id="+id+"的用户");
                }
                ctx.accounts.Remove(stu);
                ctx.SaveChanges();
            }
        }
        public AccountDTO GetById(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                //var s = ctx.accounts.AsNoTracking()
                //.Include(e => e.Class).Include(e => e.MinZu)
                //.SingleOrDefault(e => e.Id == id);
                var s = ctx.accounts.AsNoTracking()
                       .SingleOrDefault(e => e.user_ID == id);
                if (s == null)
                {
                    return null;
                }
                return ToDTO(s);
            }
        }
        private AccountDTO ToDTO(account s)
        {

            AccountDTO dto = new AccountDTO();
                dto.user_ID = s.user_ID;
                dto.name = s.name;
                dto.password = s.password;
                dto.account_type = s.account_type;
                return dto;
            
        }

    }
}
