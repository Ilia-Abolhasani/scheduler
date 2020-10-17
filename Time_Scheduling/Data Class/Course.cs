using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling
{
    public class Course
    {
        public int ID;
        public string Name;
        public int Unit;
        
        public List<Tuple<int, int, int>> Requirments;//Tuple<Req_ID ,RequirmentAs ,RequirmentFrom>
        public List<Tuple<int, int>> AbandenCourse;//Tuple<Abanden Course ID , priority>
        public List<Data_Class.Time> CourseDuration;
        public List<Tuple<int, int>> DepartmentPriority;//Tuple<Department ID , priority>
        public Course()
        {            
        }
    }
}
