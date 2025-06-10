using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFirstDay.CoursesBL
{
    public class CoursesBL
    {
        public static bool ValidateLogin(string username, string password, out int userId, out string trackName)
        {
            userId = -1;
            trackName = string.Empty;

            DataTable userData = CoursesDAL.CoursesDAL.GetUserByUserName(username);

            if (userData.Rows.Count == 0)
                return false; 

            string dbPassword = userData.Rows[0]["UserPass"].ToString();

            if (dbPassword == password)
            {
                userId = Convert.ToInt32(userData.Rows[0]["UserID"]);
                trackName = userData.Rows[0]["TrackName"].ToString();
                return true;
            }

            return false;
        }
        public static int AddNewCourse(string courseName, string description, int duration, string trackName)
        {
            return CoursesDAL.CoursesDAL.InsertCourse(courseName, description, duration, trackName);
        }
        public static DataTable GetAllCourses() {
            SqlCommand cmd = new SqlCommand("Select * From Courses");
            return CoursesDAL.CoursesDAL.SelectCommand(cmd);
        }
        public static int UpdateCourse(int courseID, string courseName, string description, int duration, string trackName)
        {
            return CoursesDAL.CoursesDAL.UpdateCourse(courseID, courseName, description, duration, trackName);
        }
        public static int DeleteCourse(int courseID)
        {
            return CoursesDAL.CoursesDAL.DeleteCourse(courseID);
        }
        public static DataTable DisplayProfile(int userID)
        {
            return CoursesDAL.CoursesDAL.GetProfile(userID);
        }
        public static bool UpdateUserProfileSelective(int userID, string fullName, string email, string phone, byte[] imageBytes)
        {
            return CoursesDAL.CoursesDAL.UpdateUserProfileSelective(userID, fullName, email, phone, imageBytes) > 0;
        }

    }
}
