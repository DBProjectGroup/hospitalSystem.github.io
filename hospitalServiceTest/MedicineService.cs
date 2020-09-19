using hospital1;
using hospitalDTO;
using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class MedicineService
    {
        /*public void AddNew(Medicine new_medicine)
        {
            using(MyContext ctx = new MyContext())
            {
                Medicine med = new Medicine();
                med.med_ID = new_medicine.med_ID;
                med.med_name = new_medicine.med_name;
                med.cost_price = new_medicine.cost_price;
                med.sell_price = new_medicine.sell_price;
                med.unit = new_medicine.unit;
                med.num = new_medicine.num;
                med.producer = new_medicine.producer;
                ctx.Medicines.Add(med);
                ctx.SaveChanges();
            }
        }*/

        public void AddNew(string med_ID, string med_name, float cost_price, float sell_price, string unit, int num, string producer)
        {
            using (MyContext ctx = new MyContext())
            {
                Medicine med = new Medicine();
                med.med_ID = med_ID;
                med.med_name = med_name;
                med.cost_price = cost_price;
                med.sell_price = sell_price;
                med.unit = unit;
                med.num = num;
                med.producer = producer;
                ctx.Medicines.Add(med);
                ctx.SaveChanges();
            }
        }
        
        public void DeleteOld(string ID)
        {
            using(MyContext ctx = new MyContext())
            {
                var med = ctx.Medicines.SingleOrDefault(s => s.med_ID == ID);
                if(med == null)
                {
                    throw new ArgumentException("药品库中未找到编号为" + ID + "的药品");
                }
                else
                {
                    ctx.Medicines.Remove(med);
                }
                ctx.SaveChanges();
            }
        }

        private MedicineDTO ToDTO(Medicine med)
        {
            MedicineDTO dto = new MedicineDTO();
            dto.med_ID = med.med_ID;
            dto.med_name = med.med_name;
            dto.cost_price = med.cost_price;
            dto.sell_price = med.sell_price;
            dto.unit = med.unit;
            dto.num = med.num;
            dto.producer = med.producer;
            return dto;
        }

        public MedicineDTO Check(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var med = ctx.Medicines.AsNoTracking().SingleOrDefault(e => e.med_ID == ID);
                if(med == null)
                {
                    return null;
                }                
                return ToDTO(med);
            }
        }

        public IEnumerable<MedicineDTO> QueryByID(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var medset = ctx.Medicines.AsNoTracking().Where(e => e.med_ID == ID);
                List<MedicineDTO> medlist = new List<MedicineDTO>();
                foreach (var med in medset)
                {
                    medlist.Add(ToDTO(med));
                }
                return medlist;
            }
        }

        public IEnumerable<MedicineDTO> QueryAll()
        {
            using(MyContext ctx = new MyContext())
            {
                List<MedicineDTO> medlist = new List<MedicineDTO>();
                foreach(var med in ctx.Medicines)
                {
                    medlist.Add(ToDTO(med));
                }
                return medlist;
            }
        }

        public void IncreaseMedicine(string ID, int num)
        {
            using (MyContext ctx = new MyContext())
            {
                var med = ctx.Medicines.SingleOrDefault(s => s.med_ID == ID);
                if (med == null)
                {
                    throw new ArgumentException("药品库中未找到编号为" + ID + "的药品");
                }
                else
                {     
                    med.num = med.num + num;                                    
                }
                ctx.SaveChanges();
            }
        }

        public void DecreaseMedicine(string ID, int num)
        {
            using (MyContext ctx = new MyContext())
            {
                var med = ctx.Medicines.SingleOrDefault(s => s.med_ID == ID);
                if (med == null)
                {
                    throw new ArgumentException("药品库中未找到编号为" + ID + "的药品");
                }
                else
                {
                    if (med.num <= num)
                    {
                        ctx.Medicines.Remove(med);
                    }
                    else
                    {
                        ctx.Medicines.Remove(med);
                        med.num -= num;
                        ctx.Medicines.Add(med);
                    }
                }
                ctx.SaveChanges();
            }
        }

        public void ModNew(string med_ID, string med_name, float cost_price, float sell_price, string unit, int num, string producer)
        {
            using (MyContext ctx = new MyContext())
            {
                var med = ctx.Medicines.SingleOrDefault(e => e.med_ID == med_ID);
                med.med_ID = med_ID;
                med.med_name = med_name;
                med.cost_price = cost_price;
                med.sell_price = sell_price;
                med.unit = unit;
                med.num = num;
                med.producer = producer;
                ctx.SaveChanges();
            }
        }

    }
}
