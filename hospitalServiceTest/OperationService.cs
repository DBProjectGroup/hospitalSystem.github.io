using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;
using hospitalServiceTest;

namespace hospital1
{
    public class OperationService
    {
        //添加手术函数
        public void AddNew(string op_ID, string op_name, string pa_ID, string op_dept,string op_date)
        {
            using (MyContext ctx = new MyContext())
            {
                Operation operation = new Operation();
                operation.op_ID = op_ID;
                operation.op_name = op_name;
                operation.op_patient = pa_ID;
                operation.op_dept = op_dept;
                operation.date = op_date;
                //register.login_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ctx.operations.Add(operation);
                ctx.SaveChanges();
            }
        }
        //修改手术基本信息
        public bool Update(string op_ID, string op_name, string pa_ID, string op_dept, string op_date)
        {

            using (MyContext ctx = new MyContext())
            {
                var s = ctx.operations.SingleOrDefault(e => e.op_ID == op_ID);
                if (s == null)
                {
                    return false;
                    throw new ArgumentException("所需要修改手术信息不存在");
                }
                s.op_ID = op_ID;
                s.op_name = op_name;
                s.op_patient = pa_ID;
                s.op_dept = op_dept;
               s.date = op_date;
                ctx.SaveChanges();
                return true;
            }
        }

        //删除手术项函数 （很少用到）
        public bool Delete(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.operations.SingleOrDefault(e => e.op_ID == ID);
                if (s == null)
                {
                    return false;
                    throw new ArgumentException("所需要删除账号不存在");
                }
                ctx.operations.Remove(s);
                ctx.SaveChanges();
                return true;
            }
        }
        //根据手术ID 返回手术信息
        public OperationDTO GetById(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.operations.AsNoTracking().SingleOrDefault(e => e.op_ID == ID);
                if (s == null)
                    return null;
                OperationDTO dto = new OperationDTO();
                dto.op_ID = s.op_ID;
                dto.op_name = s.op_name;
                dto.op_dept = s.op_dept;
                dto.op_patient = s.op_patient;
                dto.date = s.date;
                return dto;
            }
        }
        //获得所有的手术信息
        public IEnumerable<OperationDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<OperationDTO> OperationDTOs = new List<OperationDTO>();
                foreach (var s in ctx.operations)
                {
                    OperationDTO dto = new OperationDTO();
                    dto.op_ID = s.op_ID;
                    dto.op_name = s.op_name;
                    dto.op_dept = s.op_dept;
                    dto.op_patient = s.op_patient;
                    dto.date = s.date;
                    OperationDTOs.Add(dto);
                }
                return OperationDTOs;
            }
        }
        //根据账号某一属性 返回这一系列账号
       /* public IEnumerable<AccountDTO> GetByAcId(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var si = ctx.Accounts.AsNoTracking().Where(e => e.user_ID == ID);
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
        }*/

    }
}
