using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Scheduling
{
   public static class Query
   {    
       
        //Select    
       public static string Select_AbandenCourse = "select * from [Time_Scheduling].[dbo].[AbandenCourse]";
       public static string Select_AvailableTimes = "select * from [Time_Scheduling].[dbo].[AvailableTimes]";
       public static string Select_ClassroomRequirments = "select * from [Time_Scheduling].[dbo].[ClassroomRequirments]";
       public static string Select_Classrooms = "select * from [Time_Scheduling].[dbo].[Classrooms ]";
       public static string Select_CourseDepartment = "select * from [Time_Scheduling].[dbo].[CourseDepartment]";
       public static string Select_CourseDurations = "select * from [Time_Scheduling].[dbo].[CourseDurations  ]";
       public static string Select_CourseRequirments = "select * from [Time_Scheduling].[dbo].[CourseRequirments ]";
       public static string Select_Courses = "select * from [Time_Scheduling].[dbo].[Courses] ";
       public static string Select_Department = "select * from [Time_Scheduling].[dbo].[Department]";
       public static string Select_ProfessorCourses = "select * from [Time_Scheduling].[dbo].[ProfessorCourses] ";
       public static string Select_ProfessorDepartment = "select * from [Time_Scheduling].[dbo].[ProfessorDepartment] ";
       public static string Select_Professors = "select * from [Time_Scheduling].[dbo].[Professors] ";
       public static string Select_ProfessorTimes = "select * from [Time_Scheduling].[dbo].[ProfessorTimes] ";
       public static string Select_Requirments = "select * from [Time_Scheduling].[dbo].[Requirments] ";
       public static string Select_University = "select * from [Time_Scheduling].[dbo].[University] ";
       public static string Select_User = "select * from [Time_Scheduling].[dbo].[User] ";
       public static string Select_Week = "select * from [Time_Scheduling].[dbo].[Week ]";        
        // Insert
        public static string Insert_AbandenCourse = "";
        public static string Insert_AvailableTimes = "";
        public static string Insert_Classrooms = "";
        public static string Insert_ClassroomRequirments = "";
        public static string Insert_CourseDurations = "";
        public static string Insert_CourseRequirments = "";
        public static string Insert_Courses = "";
        public static string Insert_ProfessorCourses = "";
        public static string Insert_Professors = "";
        public static string Insert_ProfessorTimes = "";
        public static string Insert_Requirments = "";
        public static string Insert_Week = "";
        //Delete
        public static string Delete_AbandenCourse = "";
        public static string Delete_AvailableTimes = "";
        public static string Delete_Classrooms = "";
        public static string Delete_ClassroomRequirments = "";
        public static string Delete_CourseDurations = "";
        public static string Delete_CourseRequirments = "";
        public static string Delete_Courses = "";
        public static string Delete_ProfessorCourses = "";
        public static string Delete_Professors = "";
        public static string Delete_ProfessorTimes = "";
        public static string Delete_Requirments = "";
        public static string Delete_Week = "";
        //Update        
        public static string Update_AbandenCourse = "";
        public static string Update_AvailableTimes = "";
        public static string Update_ClassroomRequirments = "";
        public static string Update_ClassRequirments = "";
        public static string Update_CourseDurations = "";
        public static string Update_CourseRequirments = "";
        public static string Update_Courses = "";
        public static string Update_ProfessorCourses = "";
        public static string Update_Professors = "";
        public static string Update_ProfessorTimes = "";
        public static string Update_Requirments = "";
        public static string Update_Week = "";
    }
}
