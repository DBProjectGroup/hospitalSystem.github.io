using EFEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HospitalDTO;

namespace HospitalService
{
    
    public class accountService
    {
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
                //var s = ctx.Accounts.AsNoTracking()
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
