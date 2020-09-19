using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HospitalDTO;
using hospitalServiceTest;

namespace HospitalService
{
    //public int device_ID { get; set; }
    //public string device_name { get; set; }
    //public string device_dept { get; set; }
    //public int device_mark { get; set; }
    //public string device_info { get; set; }

    public class deviceService
    {
       public int AddNew(string device_ID, string device_name)
        {
            using (MyContext ctx = new MyContext())
            {
                var device = ctx.devices.SingleOrDefault(d => d.device_ID == device_ID);
                if (device == null)
                {
                    device s = new device();
                    s.device_ID = device_ID;
                    s.device_name = device_name;
                    s.device_dept = null;
                    s.device_mark = 0;
                    ctx.devices.Add(s);
                    ctx.SaveChanges();
                    return 1;
                }
                else return -1;
            }
        }
        public string Report(string device_ID, string device_info)
        {
            //申请报修
            using (MyContext ctx = new MyContext())
            {
                //Linq 查询 - 自动转译 T-SQL 语句
                var query = from item in ctx.devices
                            where item.device_ID == device_ID
                            select item;
                //查询到对象后，修改对象属性
                foreach (var item in query.ToList())
                {
                    if (item.device_mark == 0)
                    {
                        item.device_mark = 1;
                        
                        item.device_info = device_info;
                        //设置mark为1，并设置报修信息
                        break;
                    }
                    else
                    {
                        if (device_info == "")
                        {
                            item.device_mark = 0;
                            item.device_info = device_info;
                            ctx.SaveChanges();
                            return "撤销申请设备成功";
                        }
                        else
                        return "你要申请报修的设备正在维护！";
                    }
                    
                    
                }
                ctx.SaveChanges();
                return "申请成功";
            }
        }
        public string Contribute(string id,string device_dept)
            //分配设备给相应的部门
        {
            using (MyContext ctx = new MyContext())
            {
                var device = ctx.devices.SingleOrDefault(s => s.device_ID == id);
                //查询第一个满足ID==id的设备
                if (device == null)
                {
                    return "没找到id=" + id + "的设备";
                }
                if (device.device_mark == 1)
                {
                    return "你要分配的设备正在维护！";
                }
                var depart= ctx.Departments.SingleOrDefault(s => s.dept_name ==device_dept);
                if (depart == null)
                {
                    return "你要新分配的部门不存在! ";
                }
                device.device_dept = device_dept;
                ctx.SaveChanges();
                return "分配成功";
            }
        }
        public string Delete(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                var device = ctx.devices.SingleOrDefault(s => s.device_ID == id);
                if (device == null)
                {
                    return "没找到id="+id+"的设备";
                }
                ctx.devices.Remove(device);
                ctx.SaveChanges();
                return "删除成功";
            }
        }
        public DeviceDTO GetById(string id)
        {
            using (MyContext ctx = new MyContext())
            {
                //var s = ctx.accounts.AsNoTracking()
                //.Include(e => e.Class).Include(e => e.MinZu)
                //.SingleOrDefault(e => e.Id == id);
                var s = ctx.devices.AsNoTracking()
                       .SingleOrDefault(e => e.device_ID == id);
                if (s == null)
                {
                    return null;
                }
                return ToDTO(s);
            }
        }
        public IEnumerable<DeviceDTO> GetbyDept(string device_dept)
        {
            using (MyContext ctx = new MyContext())
            {
                var devices = ctx.devices.AsNoTracking()
                    .Include(e => e.department)
                    .Where(e => e.device_dept == device_dept);
                List<DeviceDTO> list = new List<DeviceDTO>();
                foreach (var d in devices)
                {
                    list.Add(ToDTO(d));
                }
                return list;
            }
        }
        public IEnumerable<DeviceDTO> GetALL()
        {
            using (MyContext ctx = new MyContext())
            {
                var devices = ctx.devices.AsNoTracking().OrderBy(e=>e.device_ID);
                List<DeviceDTO> list = new List<DeviceDTO>();
                foreach (var d in devices.ToList())
                {
                    list.Add(ToDTO(d));
                }
                return list;
            }
        }
        private DeviceDTO ToDTO(device s)
        {

            DeviceDTO dto = new DeviceDTO();
                dto.device_ID = s.device_ID;
            if (s.department != null)
            {
                dto.device_dept = s.department.dept_name;
            }
                dto.device_info = s.device_info;
                dto.device_mark = s.device_mark;
                dto.device_name = s.device_name;
                return dto;
            
        }

    }
}
