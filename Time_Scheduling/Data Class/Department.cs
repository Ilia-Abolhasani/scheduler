using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.Data_Class
{
    public class Department
    {
        public int ID;
        public List<Duration> AvailableTimes;
        public List<Classroom> Classrooms;
        public Department()
        {
            AvailableTimes = new List<Duration>();
            Classrooms = new List<Classroom>();
        }
    }
}
