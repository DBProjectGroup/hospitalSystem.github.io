using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;
using HospitalService;
using hospitalServiceTest;

namespace hospital1
{
    public class Operation_participateService
    {
        //添加手术参与成员函数
        public void AddNew(string op_ID, string person_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                Operation_participate operation_Participate = new Operation_participate();
                operation_Participate.op_ID = op_ID;
                operation_Participate.person_ID = person_ID;
                ctx.Operation_Participates.Add(operation_Participate);
                ctx.SaveChanges();
            }
        }
        //获得参与该手术的所有成员函数
        public IEnumerable<Operation_participateDTO> GetAll(string op_ID)
        {
            accountService account = new accountService();
            using (MyContext ctx = new MyContext())
            {
                var si = ctx.Operation_Participates.Where(e => e.op_ID == op_ID);
                List<Operation_participateDTO> operation_ParticipateDTOs = new List<Operation_participateDTO>();
                if (si == null)
                { return null; }
                foreach (var s in si)
                {
                    Operation_participateDTO operation_ParticipateDTO = new Operation_participateDTO();
                    operation_ParticipateDTO.op_ID = s.op_ID;
                    operation_ParticipateDTO.person_ID = s.person_ID;
                    operation_ParticipateDTO.person_name = account.backName(s.person_ID);
                    operation_ParticipateDTOs.Add(operation_ParticipateDTO);
                }
                return operation_ParticipateDTOs;
            }
        }
        //删除手术参与成员函数
        public bool Delete(string op_ID,string person_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Operation_Participates.Where(e => e.op_ID == op_ID);
                if (s == null)
                {
                    return false;
                    throw new ArgumentException("所需要删除账号不存在");
                }
                foreach (var si in s)
                {
                    if(si.person_ID == person_ID)
                    ctx.Operation_Participates.Remove(si);
                }
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
