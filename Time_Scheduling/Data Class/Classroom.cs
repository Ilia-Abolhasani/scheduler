using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Scheduling.Data_Class;

namespace Time_Scheduling
{
    public class Classroom
    {
        public int ClassroomID;
        public string ClassrormName;
        public List<University.Requirments> Requirments;
        public Classroom()
        {
            Requirments = new List<University.Requirments>();
        }
        public Classroom(int ID,string Name)
        {
            Requirments = new List<University.Requirments>();
            this.ClassrormName = Name;
            this.ClassroomID = ID;
        }
        public void AddRequirments(University.Requirments requirments)
        {
            Requirments.Add(requirments);
        }
        public void AddRequirments(int ID , string Name , int Count)
        {
            University.Requirments requirments = new University.Requirments();
            requirments.ID = ID;
            requirments.Name=Name;
            requirments.Count=Count;
            Requirments.Add(requirments);
        }
    }
}
