using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling.Data_Class
{
    public class University
    {
        public enum Week
        {
            Saturday = 0,
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
        }
        public struct Requirments
        {
            public int ID;
            public string Name;
            public int Count;
        }
        int Uni_ID;
        int UserID;
        string Name;
        List<Tuple<Department, int>> Departments; //Tuple<Department,prorith>
        List<Course> Courses;
        List<Professor> Professors;
        public University(int UserID, int Uni_ID)
        {
            this.Uni_ID = Uni_ID;
            this.UserID = UserID;

            Departments = new List<Tuple<Department, int>>();
            Courses = new List<Course>();
            Professors = new List<Professor>();
        }
        public void Fill()
        {
            Database.Connect();
            Fill_Department();
            Fill_Professors();
            Fill_Courses();
            Database.Disconnect();
        }
        private void Fill_Department()
        {
            using (DataTable dataTable_Department = Database.Select_Department(Uni_ID))
            {
                for (int i = 0; i < dataTable_Department.Rows.Count; i++)
                {
                    Department Temp_Department = new Department();
                    int Dep_ID = (int)dataTable_Department.Rows[i]["Dep_ID"];
                    using (DataTable dataTable_AvailableTimes = Database.Select_AvailableTimes(Dep_ID))
                    {
                        for (int j = 0; j < dataTable_AvailableTimes.Rows.Count; j++)
                            Temp_Department.AvailableTimes.Add(new Duration(GetTime(dataTable_AvailableTimes.Rows[j]["AT_StartTime"]), GetTime(dataTable_AvailableTimes.Rows[j]["AT_FinishTime"])));                        
                    }
                    using (DataTable dataTable_Classrooms= Database.Select_Classrooms(Dep_ID))
                    {
                        for (int j = 0; j < dataTable_Classrooms.Rows.Count; j++)
                        {
                            int Cls_ID=(int)dataTable_Classrooms.Rows[j]["Cls_ID"];
                            Classroom Temp_Classroom = new Classroom(Cls_ID, (string)dataTable_Classrooms.Rows[j]["Cls_Name"]);
                            using (DataTable dataTable_ClassroomRequirments = Database.Select_ClassroomRequirments(Cls_ID))
                            {
                                for (int k = 0; k < dataTable_ClassroomRequirments.Rows.Count; k++)			                    			                                 
                                    using (DataTable dataTable_Requirments = Database.Select_Requirments_Req_ID((int)dataTable_ClassroomRequirments.Rows[k]["Req_ID"]))
                                    {   
                                       Requirments Temp_Requirments=new Requirments();
                                        Temp_Requirments.ID=(int)dataTable_Requirments.Rows[0]["Req_ID"];
                                        Temp_Requirments.Name=(string)dataTable_Requirments.Rows[0]["Req_Name"];
                                        Temp_Requirments.Count=(int)dataTable_ClassroomRequirments.Rows[k]["Req_ID"];                                        
                                        Temp_Classroom.AddRequirments(Temp_Requirments);    
                                    }                                
                            }                            
                            Temp_Department.Classrooms.Add(Temp_Classroom);
                        }
                    }
                    Departments.Add(new Tuple<Department, int>(Temp_Department, Dep_ID));
                }
            }                        
        }
        private void Fill_Professors()
        {
            using (DataTable dataTable_Professors = Database.Select_Professors(Uni_ID))
            {
                for (int i = 0; i < dataTable_Professors.Rows.Count; i++)
                {
                    Professor Temp_Professor = new Professor();
                    Temp_Professor.ID = (int)dataTable_Professors.Rows[i]["Uni_ID"];
                    Temp_Professor.Name = (string)dataTable_Professors.Rows[i]["Prf_Name"];
                    Temp_Professor.LastName = (string)dataTable_Professors.Rows[i]["Prf_LastName"];
                    Temp_Professor.Min_Unit = (int)dataTable_Professors.Rows[i]["Prf_MinUnit"];
                    Temp_Professor.Max_Unit = (int)dataTable_Professors.Rows[i]["Prf_MaxUnit"];
                    //CourseOffer
                    using (DataTable dataTable_ProfessorCourses = Database.Select_ProfessorCourses(Temp_Professor.ID))
                    {
                        for (int j = 0; j < dataTable_ProfessorCourses.Rows.Count; j++)                        
                            Temp_Professor.CourseOffer.Add(new Tuple<int, int>((int)dataTable_ProfessorCourses.Rows[j]["Crs_ID"], (int)dataTable_ProfessorCourses.Rows[j]["Prority"]));                        
                    }
                    //DepartmentPriority
                    using (DataTable dataTable_ProfessorDepartment = Database.Select_ProfessorDepartment(Temp_Professor.ID))
                    {
                        for (int j = 0; j < dataTable_ProfessorDepartment.Rows.Count; j++)
                            Temp_Professor.DepartmentPriority.Add(new Tuple<int, int>((int)dataTable_ProfessorDepartment.Rows[j]["Dep_ID"], (int)dataTable_ProfessorDepartment.Rows[j]["Priority"]));                        
                    }
                    //ProfessorDuration
                    using (DataTable dataTable_ProfessorTimes = Database.Select_ProfessorTimes())
                    {
                        for (int j = 0; j < dataTable_ProfessorTimes.Rows.Count; j++)
                        {
                            Duration Temp_Duration = new Duration();
                            Temp_Duration.StartTime = GetTime(dataTable_ProfessorTimes.Rows[j]["PT_StartTime"]);
                            Temp_Duration.FinishTime = GetTime(dataTable_ProfessorTimes.Rows[j]["PT_FinishTime"]);
                            Temp_Professor.ProfessorDuration.Add(new Tuple<Duration, int>(Temp_Duration, (int)dataTable_ProfessorTimes.Rows[j]["PT_Priority"]));
                        }
                    }
                    Professors.Add(Temp_Professor);
                }
            }                        
        }
        private void Fill_Courses()
        {
            using (DataTable dataTable_Courses = Database.Select_Courses(Uni_ID))
            {
                for (int i = 0; i < dataTable_Courses.Rows.Count; i++)
                {
                    Course Temp_Course = new Course();
                    Temp_Course.ID = (int)dataTable_Courses.Rows[i]["Crs_ID"];
                    Temp_Course.Name = (string)dataTable_Courses.Rows[i]["Crs_Name"];
                    Temp_Course.Unit = (int)dataTable_Courses.Rows[i]["Crs_Unit"];
                    //Requirments
                    using (DataTable dataTable_CourseRequirments = Database.Select_CourseRequirments(Temp_Course.ID))
                    {
                        for (int j = 0; j < dataTable_CourseRequirments.Rows.Count; j++)
                        {
                            int Req_ID = (int)dataTable_CourseRequirments.Rows[j]["Req_ID"];
                            int RequirmentAs = (int)dataTable_CourseRequirments.Rows[j]["CR_RequirmentAs"];
                            int RequirmentFrom = (int)dataTable_CourseRequirments.Rows[j]["CR_RequirmentFrom"];
                            Temp_Course.Requirments.Add(new Tuple<int, int, int>(Req_ID, RequirmentAs, RequirmentFrom));
                        }
                    }
                    //AbandenCourse
                    using (DataTable dataTable_AbandenCourse = Database.Select_AbandenCourse(Temp_Course.ID))
                    {
                        for (int j = 0; j < dataTable_AbandenCourse.Rows.Count; j++)                        
                            Temp_Course.AbandenCourse.Add(new Tuple<int, int>((int)dataTable_AbandenCourse.Rows[j]["Crs_ID_1"], (int)dataTable_AbandenCourse.Rows[j]["Priority"]));                        
                    }
                    //CourseDuration
                    using (DataTable dataTable_CourseDurations = Database.Select_CourseDurations(Temp_Course.ID))
                    {
                        for (int j = 0; j < dataTable_CourseDurations.Rows.Count; j++)
                            Temp_Course.CourseDuration.Add(GetTime(dataTable_CourseDurations.Rows[j]["CD_Time"]));
                    }
                    //DepartmentPriority
                    using (DataTable dataTable_CourseDepartment = Database.Select_CourseDepartment(Temp_Course.ID))
                    {
                        for (int j = 0; j < dataTable_CourseDepartment.Rows.Count; j++)                        
                            Temp_Course.DepartmentPriority.Add(new Tuple<int, int>((int)dataTable_CourseDepartment.Rows[j]["Dep_ID"], (int)dataTable_CourseDepartment.Rows[j]["Priority"]));                        
                    }
                    Courses.Add(Temp_Course);
                }
            }
        }
        private Time GetTime(Object SQLTime)
        {
            return new Time();
        }
    }
}
