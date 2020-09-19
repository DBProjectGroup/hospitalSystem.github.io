using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using hospitalServiceTest;
using hospitalService;

namespace HospitalService
{
    public class wardService
    {
        //public int ward_ID { get; set; }
        //public string ward_dept { get; set; }
        //public int is_empty { get; set; }
        //public int capacity { get; set; }

        //public virtual department department { get; set; }
        //public virtual patient patient { get; set; }
        public int AddNew(string ward_ID, string ward_dept, int capacity)
        {
            using (MyContext ctx = new MyContext())
            {
                var ward = ctx.Wards.SingleOrDefault(w => w.ward_ID == ward_ID);
                var dept = ctx.Departments.SingleOrDefault(d => d.dept_name == ward_dept);
                if (dept == null)
                {
                    return 2;
                    //表示输入部门科室不存在
                }
                if (ward == null)
                {
                    Ward s = new Ward();
                    s.ward_ID = ward_ID;
                    s.ward_dept = ward_dept;
                    s.capacity = capacity;
                    s.is_full = 0;
                    ctx.Wards.Add(s);
                    ctx.SaveChanges();
                    return 1;
                    //添加成功
                }
                
                else return -1;
                //添加的病房已经有了
            }
        }
        public int Delete(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                foreach (var w in ctx.Patients)
                {
                    if (w.patient_ward == id)
                    {
                        w.patient_ward = null;
                    }
                }
                var ward = ctx.Wards.SingleOrDefault(s => s.ward_ID == id);
                if (ward == null)
                {
                    return -1;
                }

                ctx.Wards.Remove(ward);
                ctx.SaveChanges();
                return 1;
            }
        }
        public WardDTO GetbyId(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                var ward = ctx.Wards.AsNoTracking().SingleOrDefault(s => s.ward_ID == id);
                if (ward == null)
                {
                    return null;
                }
                return ToDTO(ward);
            }
        }
        public int disContribute(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                var patient = ctx.Patients.SingleOrDefault(w => w.patient_ID == id);
                if (patient == null)
                {
                    return -1;
                }
                //Linq 查询 - 自动转译 T-SQL 语句
                var query1 = from item in ctx.Patients
                             where item.patient_ID == id
                             select item;
                //查询到对象后，修改对象属性
                string ward_ID="";
                foreach (var item in query1)
                {
                    ward_ID = item.patient_ward;
                    item.patient_ward = null;
                    break;
                }
                //Linq 查询 - 自动转译 T-SQL 语句
                var query2 = from item in ctx.Wards
                             where item.ward_ID == ward_ID
                             select item;
                foreach (var item in query2)
                {
                    item.is_full = 0;
                    break;
                }
                ctx.SaveChanges();
                return 1;
            }
        }
        public IEnumerable<WardDTO> GetbyDept(string ward_dept)
        {
            using (MyContext ctx = new MyContext())
            {
                var Wards = ctx.Wards.AsNoTracking()
                    .Where(e => e.ward_dept == ward_dept).ToList();
                List<WardDTO> list = new List<WardDTO>();
                foreach (var w in Wards)
                {
                    list.Add(ToDTO(w));
                }
                return list;
            }
        }
        public IEnumerable<WardDTO> GetALL()
        {
            using (MyContext ctx = new MyContext())
            {
                var Wards = ctx.Wards.AsNoTracking().OrderBy(e => e.ward_ID).ToList();
                List<WardDTO> list = new List<WardDTO>();
                foreach (var w in Wards)
                {
                    list.Add(ToDTO(w));
                }
                return list;
            }
        }
        public IEnumerable<WardDTO> GetNotFull()
        {
            using (MyContext ctx = new MyContext())
            {
                var Wards = ctx.Wards.AsNoTracking().OrderBy(e => e.ward_ID).Where(e=>e.is_full==0).ToList();
                List<WardDTO> list = new List<WardDTO>();
                foreach (var w in Wards)
                {
                    list.Add(ToDTO(w));
                }
                return list;
            }
        }
        private WardDTO ToDTO(Ward s)
        {


            WardDTO dto = new WardDTO();
            dto.ward_ID = s.ward_ID;
            dto.ward_dept = s.ward_dept;
            dto.capacity = s.capacity;
            dto.is_full = s.is_full;
            return dto;

        }
    }
}
