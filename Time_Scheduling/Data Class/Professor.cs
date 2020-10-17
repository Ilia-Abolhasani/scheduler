using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling
{
    public class Professor
    {
        public int ID;
        public string Name;
        public string LastName;
        public int Min_Unit;
        public int Max_Unit;

        public List<Tuple<Data_Class.Duration, int>> ProfessorDuration;//Tuple<Duration, priority>
        public List<Tuple<int, int>> CourseOffer;//Tuple<Course_ID, priority>
        public List<Tuple<int, int>> DepartmentPriority;//Tuple<Dep_ID, priority>
        public Professor()
        {

        }        
    }
}
