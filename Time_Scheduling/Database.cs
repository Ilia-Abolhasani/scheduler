using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Time_Scheduling
{
    public static class Database
    {
        public static SqlConnection sqlConnection;

        #region Connection

        /// <summary>
        /// Connect SqlConnection to sql server database 
        /// </summary>
        public static void Connect()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
            "Data Source=127.0.0.1,1433;" +
            "Initial Catalog=Time_Scheduling;" +
            "User id=sa;" +
            "Password=sa;";
            sqlConnection.Open();
        }

        public static void Disconnect()
        {
            sqlConnection.Dispose();
        }
        #endregion

        #region Selection
        public static DataTable Select(string Query)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlDataAdapter.Fill(dataTable);
                }

            }
            return dataTable;
        }
        public static DataTable Select_AbandenCourse()
        {
            return Select(Query.Select_AbandenCourse);
        }
        public static DataTable Select_AbandenCourse(int Crs_ID)
        {
            return Select(string.Format(Query.Select_AbandenCourse + "where Crs_ID={0}", Crs_ID));
        }
        public static DataTable Select_AvailableTimes()
        {
            return Select(Query.Select_AvailableTimes);
        }
        public static DataTable Select_AvailableTimes(int Dep_ID)
        {
            return Select(string.Format(Query.Select_AvailableTimes + "where Dep_ID={0}", Dep_ID));
        }
        public static DataTable Select_ClassroomRequirments()
        {
            return Select(Query.Select_ClassroomRequirments);
        }
        public static DataTable Select_ClassroomRequirments(int Cls_ID)
        {
            return Select(string.Format(Query.Select_ClassroomRequirments + "where Cls_ID={0}", Cls_ID));
        }
        public static DataTable Select_Classrooms()
        {
            return Select(Query.Select_Classrooms);
        }
        public static DataTable Select_Classrooms(int Dep_ID)
        {
            return Select(string.Format(Query.Select_Classrooms + "where Dep_ID={0}", Dep_ID));
        }
        public static DataTable Select_CourseDepartment()
        {
            return Select(Query.Select_CourseDepartment);
        }
        public static DataTable Select_CourseDepartment(int Cls_ID)
        {
            return Select(string.Format(Query.Select_CourseDepartment + "where Cls_ID={0}", Cls_ID));
        }
        public static DataTable Select_CourseDurations()
        {
            return Select(Query.Select_CourseDurations);
        }
        public static DataTable Select_CourseDurations(int Crs_ID)
        {
            return Select(string.Format(Query.Select_CourseDurations + "where Crs_ID={0}", Crs_ID));
        }
        public static DataTable Select_CourseRequirments()
        {
            return Select(Query.Select_CourseRequirments);
        }
        public static DataTable Select_CourseRequirments(int Crs_ID)
        {
            return Select(string.Format(Query.Select_CourseRequirments + "where Crs_ID={0}", Crs_ID));
        }
        public static DataTable Select_Courses()
        {
            return Select(Query.Select_Courses);
        }
        public static DataTable Select_Courses(int Uni_ID)
        {
            return Select(string.Format(Query.Select_Courses + "where Uni_ID={0}", Uni_ID));
        }
        public static DataTable Select_Department()
        {
            return Select(Query.Select_Department);
        }
        public static DataTable Select_Department(int Uni_ID)
        {
            return Select(string.Format(Query.Select_Department + "where Uni_ID={0}", Uni_ID));
        }
        public static DataTable Select_ProfessorCourses()
        {
            return Select(Query.Select_ProfessorCourses);
        }
        public static DataTable Select_ProfessorCourses(int Prf_ID)
        {
            return Select(string.Format(Query.Select_ProfessorCourses + "where Prf_ID={0}", Prf_ID));
        }
        public static DataTable Select_ProfessorDepartment()
        {
            return Select(Query.Select_ProfessorDepartment);
        }
        public static DataTable Select_ProfessorDepartment(int Prf_ID)
        {
            return Select(string.Format(Query.Select_ProfessorDepartment + "where Prf_ID={0}", Prf_ID));
        }
        public static DataTable Select_Professors()
        {
            return Select(Query.Select_Professors);
        }
        public static DataTable Select_Professors(int Uni_ID)
        {
            return Select(string.Format(Query.Select_Professors + "where Uni_ID={0}", Uni_ID));
        }
        public static DataTable Select_ProfessorTimes()
        {
            return Select(Query.Select_ProfessorTimes);
        }
        public static DataTable Select_ProfessorTimes(int Prf_ID)
        {
            return Select(string.Format(Query.Select_ProfessorTimes + "where Prf_ID={0}", Prf_ID));
        }
        public static DataTable Select_Requirments()
        {
            return Select(Query.Select_Requirments);
        }
        public static DataTable Select_Requirments_Uni_ID(int Uni_ID)
        {
            return Select(string.Format(Query.Select_Requirments + "where Uni_ID={0}", Uni_ID));
        }
        public static DataTable Select_Requirments_Req_ID(int Req_ID)
        {
            return Select(string.Format(Query.Select_Requirments + "where Req_ID={0}", Req_ID));
        }
        public static DataTable Select_University()
        {
            return Select(Query.Select_University);
        }
        public static DataTable Select_University(int Uni_ID)
        {
            return Select(string.Format(Query.Select_University + "where Uni_ID={0}", Uni_ID));
        }
        public static DataTable Select_User()
        {
            return Select(Query.Select_User);
        }
        public static DataTable Select_User(string User_Name)
        {
            return Select(string.Format(Query.Select_User + "where User_Name=N'{0}'", User_Name));
        }
        public static DataTable Select_Week()
        {
            return Select(Query.Select_Week);
        }

        #endregion

        #region Update
        #endregion

        #region Insert
        #endregion

        #region Delete
        #endregion

    }
}
