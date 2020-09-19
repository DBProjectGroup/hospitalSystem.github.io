using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class DepartmentService
    {
        public void AddNewDepartment(string department_name, string dir_name, string dir_ID, //增
            int room_ID, int people_num)
        {
            using (MyContext ctx = new MyContext())
            {
                Department s = new Department();
                s.dept_name = department_name;
                s.dir_name = dir_name;
                s.dir_ID = dir_ID;
                s.room_ID = room_ID;
                s.people_num = people_num;
                ctx.Departments.Add(s);
                ctx.SaveChanges();
            }
        }
        public void DeleteDepartmentByName(string department_name)//删
        {

            using (MyContext ctx = new MyContext())
            {
                var a = department_name;
                var dpt = ctx.Departments.SingleOrDefault(s=>s.dept_name == department_name);
                if (dpt == null)
                {
                    return;
                }
                ctx.Departments.Remove(dpt);
                ctx.SaveChanges();
            }
        }

        public void ChangeDepartmentByName(string dept_name,string department_name, string dir_name, string dir_ID, 
            int room_ID, int people_num)//按科室名查找后进行修改
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Departments.SingleOrDefault(e => e.dept_name == dept_name);
                s.dept_name = department_name;
                s.dir_name = dir_name;
                s.dir_ID = dir_ID;
                s.room_ID = room_ID;
                s.people_num = people_num;
                ctx.SaveChanges();
            }
        }


        public DepartmentDTO GetDepartmentByDptName(string department_name)//按科室名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Departments.SingleOrDefault(e => e.dept_name == department_name);
                if(s == null)
                {
                    return null;
                }
                DepartmentDTO dto = new DepartmentDTO();
                dto.dept_name = s.dept_name;
                dto.dir_name = s.dir_name;
                dto.dir_ID = s.dir_ID;
                dto.room_ID = s.room_ID;
                dto.people_num = s.people_num;
                return dto;
            }
        }

        public IEnumerable<DepartmentDTO> GetDepartmentByDirName(string dir_name)//按行政主任名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var dpt = ctx.Departments.Where(e => e.dir_name == dir_name);
                if (dpt == null)
                {
                    return null;
                }
                List<DepartmentDTO> list = new List<DepartmentDTO>();
                foreach (var s in dpt)
                {
                    DepartmentDTO dto = new DepartmentDTO();
                    dto.dept_name = s.dept_name;
                    dto.dir_name = s.dir_name;
                    dto.dir_ID = s.dir_ID;
                    dto.room_ID = s.room_ID;
                    dto.people_num = s.people_num;
                    list.Add(dto);
                }
                return list;
            }
        }

        public IEnumerable<DepartmentDTO> GetDdepartmentByDirID(string dir_ID)//按行政主任ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var dpt = ctx.Departments.Where(e => e.dir_ID == dir_ID);
                if (dpt == null)
                {
                    return null;
                }
                List<DepartmentDTO> list = new List<DepartmentDTO>();
                foreach (var s in dpt)
                {
                    DepartmentDTO dto = new DepartmentDTO();
                    dto.dept_name = s.dept_name;
                    dto.dir_name = s.dir_name;
                    dto.dir_ID = s.dir_ID;
                    dto.room_ID = s.room_ID;
                    dto.people_num = s.people_num;
                    list.Add(dto);
                }
                return list;
            }
        }

        public IEnumerable<DepartmentDTO> GetAllDepartment()//获取全部科室
        {
            using (MyContext ctx = new MyContext())
            {
                var dpts = ctx.Departments;
                if (dpts == null)
                {
                    return null;
                }
                List<DepartmentDTO> departmentList = new List<DepartmentDTO>();
                foreach (var s in dpts)
                {
                    DepartmentDTO dto = new DepartmentDTO();
                    dto.dept_name = s.dept_name;
                    dto.dir_name = s.dir_name;
                    dto.dir_ID = s.dir_ID;
                    dto.room_ID = s.room_ID;
                    dto.people_num = s.people_num;
                    departmentList.Add(dto);
                }
                return departmentList;
            }
        }
    }
}
