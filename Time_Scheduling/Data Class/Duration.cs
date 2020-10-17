using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.Data_Class
{
    public class Duration
    {
        public Time StartTime;
        public Time FinishTime;
        public Duration()
        {
        }
        public Duration(Time StartTime,Time FinishTime)
        {
            this.StartTime = StartTime;
            this.FinishTime = FinishTime;
        }
        public int GetOverlab(Duration duration)
        {
            if (this.StartTime.WeekDay != duration.StartTime.WeekDay)
                return 0;
            // max start time

            int Start = this.StartTime.GetNumbericTime();
            if (duration.StartTime.GetNumbericTime()>Start)
                Start = duration.StartTime.GetNumbericTime();

            //min finish time

            int Finish = this.FinishTime.GetNumbericTime();
            if (duration.FinishTime.GetNumbericTime() < Finish)
                Finish = duration.FinishTime.GetNumbericTime();

            // delta between start time and finish time

            if (Finish - Start <= 0)
                return 0;
            else
                return Finish - Start;
        }
    }
}
