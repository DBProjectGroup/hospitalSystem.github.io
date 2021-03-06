﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;
using hospitalServiceTest;

namespace hospital1
{
    public class AttendanceService
    {
        public static string MorningStartTimeStr = "07:30";
        public static string MorningEndTimeStr = "10:30";
        public static string NoonStartTimeStr = "14:00";
        public static string NoonEndTimeStr = "17:00";
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
            string month, day;
            using (MyContext ctx = new MyContext())
            {
                Attendance attendance = new Attendance();
                if(DateTime.Now.Month<10)
                {
                    month = "0" + DateTime.Now.Month.ToString();
                }
                else
                    month = DateTime.Now.Month.ToString();
                if(DateTime.Now.Day < 10)
                {
                    day = "0" + DateTime.Now.Day.ToString();
                }
                else
                    day = DateTime.Now.Day.ToString();
                if (IsWorking() == 0)
                    attendance.attend_ID = DateTime.Now.Year.ToString() + month + day + "00" + ID;
                else if (IsWorking() == 1)
                    attendance.attend_ID = DateTime.Now.Year.ToString() + month + day + "01" + ID;
                else return false;
                var s = ctx.Attendances.AsNoTracking().SingleOrDefault(e => e.attend_ID == attendance.attend_ID);
                if (s != null)
                    return false;
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
        public attendanceData GetTimes(string ID,bool success)
        {
            int timesTotal = DateTime.Now.Day*2;
            int times = 0;
            List<AttendanceDTO> attendanceDTOs = (List<AttendanceDTO>)GetByAId(ID);
            int mon = DateTime.Now.Month;
            int yea = DateTime.Now.Year;
            attendanceData attendanceData = new attendanceData();
            for(int i=0;i<attendanceData.attArr.Length;i++)
            {
                attendanceData.attArr[i] = 0;
            }
            foreach (var s in attendanceDTOs)
            {
               int month=int.Parse(s.attend_ID[4].ToString() + s.attend_ID[5].ToString());
               int year = int.Parse(s.attend_ID[0].ToString() + s.attend_ID[1].ToString() + s.attend_ID[2].ToString() + s.attend_ID[3].ToString());
               int day= int.Parse(s.attend_ID[6].ToString() + s.attend_ID[7].ToString());
               int up = int.Parse(s.attend_ID[8].ToString() + s.attend_ID[9].ToString());
                if ( month==mon&&year==yea)
                {
                    times++;
                }
                if(up==0)
                {
                    attendanceData.attArr[day * 2 - 2] = 1;
                }
                else if(up==1)
                {
                    attendanceData.attArr[day * 2 - 1] = 1;
                }
                //string now = s.attend_ID[4].ToString() + s.attend_ID[5].ToString();
                /*int month = int.Parse(now);
                if()*/
            }
            attendanceData.attTime = times;
            attendanceData.attPri = times.ToString()+ "/"+timesTotal.ToString();
            attendanceData.remainTime= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)*2-timesTotal;
            attendanceData.success = success;
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
