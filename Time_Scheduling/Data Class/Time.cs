using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.Data_Class
{
    public class Time
    {
        public University.Week WeekDay;
        public int hour;
        public int Minute;
        public int GetNumbericTime()
        {
            return hour * 60 + Minute;
        }
        public int TimeDifference(Time time)
        {
            if (this.WeekDay == time.WeekDay)
                throw new Exception("compare two day with wrong WeekDay");

            return Math.Abs(this.GetNumbericTime() - time.GetNumbericTime());            
        }
    }
}
