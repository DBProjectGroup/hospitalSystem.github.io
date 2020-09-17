using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;

namespace hospital1
{
    public class AttendanceService
    {
        public static string MorningStartTimeStr = "07:30";
        public static string MorningEndTimeStr = "15:30";
        public static string NoonStartTimeStr = "14:00";
        public static string NoonEndTimeStr = "18:00";
        private TimeSpan MorningStartTime = DateTime.Parse(MorningStartTimeStr).TimeOfDay;
        private TimeSpan MorningEndTime=DateTime.Parse(MorningEndTimeStr).TimeOfDay;
        private TimeSpan NoonStartTime = DateTime.Parse(NoonStartTimeStr).TimeOfDay;
        private TimeSpan NoonEndTime = DateTime.Parse(NoonEndTimeStr).TimeOfDay;
        private int IsWorking()
        {
            //判断当前时间是否在上午打开时间段内，是否在下午打卡时间内
            TimeSpan dspNow = DateTime.Now.TimeOfDay;
            if (dspNow > MorningStartTime && dspNow < MorningEndTime)
            {
                return 0;
            }
            if (dspNow > NoonStartTime && dspNow < NoonEndTime)
                return 1;
            return 2;
        }
        //签到打卡
        public bool AddNew(string ID)//规定00为上午签到，01为下午签到
        {
            using (MyContext ctx = new MyContext())
            {
                Attendance attendance = new Attendance();
                if (IsWorking() == 0)
                    attendance.attend_ID = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.DayOfYear.ToString() + "00" + ID;
                else if (IsWorking() == 1)
                    attendance.attend_ID = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.DayOfYear.ToString() + "01" + ID;
                else return false;
                attendance.A_ID = ID;
                attendance.attend_time= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ctx.Attendances.Add(attendance);
                ctx.SaveChanges();
                /*try
                    { ctx.SaveChanges(); }
                /*catch(Exception ex)
                {
                    throw;
                }*/
                return true;
            }
        }
        //找出所有账户ID为001的签到信息
        public IEnumerable<AttendanceDTO> GetByAId(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var si = ctx.Attendances.AsNoTracking().Where(e => e.A_ID == ID);
                List<AttendanceDTO> attendanceDTOs = new List<AttendanceDTO>();
                if (si == null)
                { return null; }
                foreach (var s in si)
                {
                    AttendanceDTO dto = new AttendanceDTO();
                    dto.attend_ID= s.attend_ID;
                    dto.attend_time = s.attend_time;
                    dto.A_ID = s.A_ID;
                    attendanceDTOs.Add(dto);
                }
                return attendanceDTOs;
            }
        }
        public attendanceData GetTimes(string ID)
        {
            int timesTotal = DateTime.Now.Day*2;
            int times = 0;
            List<AttendanceDTO> attendanceDTOs = (List<AttendanceDTO>)GetByAId(ID);
            int mon = DateTime.Now.Month;
            attendanceData attendanceData = new attendanceData();
            foreach (var s in attendanceDTOs)
            {
               int month=int.Parse(s.attend_time[0].ToString() + s.attend_time[1].ToString());
                if(month==mon)
                {
                    times++;
                }
                //string now = s.attend_ID[4].ToString() + s.attend_ID[5].ToString();
                /*int month = int.Parse(now);
                if()*/
            }
            attendanceData.attTime = times;
            attendanceData.attPri = times / timesTotal;
            return attendanceData;
        }
        //返回该用户在该阶段是否已经签到
        public bool IsAttendanced(string ID, string IsWork)
        {
            List<AttendanceDTO> attendanceDTOs = GetByAId(ID).ToList();
            foreach (var s in attendanceDTOs)
            {
                if (s.attend_ID == DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.DayOfYear.ToString() + IsWork + ID)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
