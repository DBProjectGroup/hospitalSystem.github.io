using hospitalDTO;
using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class BillService
    {
        public void CreateBill(string bill_ID, string bill_patient, string type, int cost)
        {
            using(MyContext ctx = new MyContext())
            {
                Bill bill = new Bill();
                bill.bill_ID = bill_ID;
                bill.bill_patient = bill_patient;
                bill.transaction_ti = DateTime.Now;
                bill.type = type;
                bill.cost = cost;
                ctx.Bills.Add(bill);
                ctx.SaveChanges();
            }
        }

        private BillDTO ToDTO(Bill bill)
        {
            BillDTO dto = new BillDTO();
            dto.bill_ID = bill.bill_ID;
            dto.bill_patient = bill.bill_patient;
            dto.transaction_ti = bill.transaction_ti.ToString("D");
            dto.type = bill.type;
            dto.cost = bill.cost;

            //dto.patient_name = bill.Patient.patient_name;
            return dto;
        }

        public IEnumerable<BillDTO> QueryAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<BillDTO> billlist = new List<BillDTO>();
                foreach (var bill in ctx.Bills)
                {
                    billlist.Add(ToDTO(bill));
                }
                return billlist;
            }
        }

        public IEnumerable<BillDTO> QueryByPatientID(string PatientID)
        {
            using (MyContext ctx = new MyContext())
            {
                var billset = ctx.Bills.AsNoTracking().Where(e => e.bill_patient == PatientID);
                List<BillDTO> billlist = new List<BillDTO>();
                foreach (var bill in billset)
                {
                    billlist.Add(ToDTO(bill));
                }
                return billlist;
            }
        }

        public void DeleteBill(string bill_ID)
        {
            using(MyContext ctx = new MyContext())
            {
                var bill = ctx.Bills.SingleOrDefault(e => e.bill_ID == bill_ID);
                if(bill == null)
                {
                    throw new ArgumentException("未找到该订单");
                }
                else
                {
                    ctx.Bills.Remove(bill);
                }
                ctx.SaveChanges();
            }
        }

    }
}
