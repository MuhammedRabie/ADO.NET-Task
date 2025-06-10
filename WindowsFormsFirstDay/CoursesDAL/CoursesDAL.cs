using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFirstDay.CoursesDAL
{
    public class CoursesDAL
    {
        //DB Connection
        static SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CoursesDB;Integrated Security=True"); //Connection String
        
        //Select Command 
        public static DataTable SelectCommand(SqlCommand _cmd)
        {
            DataTable dt = new DataTable();
            _cmd.Connection = con;
            SqlDataAdapter adapter = new SqlDataAdapter(_cmd);
            adapter.Fill(dt);
            return dt;
        }
        
        //DML Commands
        public static int DMLCommand(SqlCommand _cmd)
        {
            int result = 0;
            _cmd.Connection = con;
            con.Open();
            result = _cmd.ExecuteNonQuery();
            con.Close();
            return result;
        } 
        
        public static DataTable GetUserByUserName(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT * From Users Where [UserName]=@UserName");
            cmd.Parameters.AddWithValue("@UserName", username);
            return SelectCommand(cmd);
        }
        public static int InsertCourse(string courseName, string description, int duration, string trackName)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Courses (CourseName, Description, Duration, TrackName) " +
                "VALUES (@CourseName, @Description, @Duration, @TrackName)"
            );

            cmd.Parameters.AddWithValue("@CourseName", courseName);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Duration", duration);
            cmd.Parameters.AddWithValue("@TrackName", trackName);

            return DMLCommand(cmd);
        }
        public static DataTable GetAppCourses(SqlCommand cmd)
        {
            return SelectCommand(cmd);
        }
        public static int UpdateCourse(int courseID,string courseName, string description, int duration, string trackName)
        {
            SqlCommand cmd = new SqlCommand("UPDATE COURSES SET CourseName=@courseName,Description=@description,Duration=@duration,TrackName=@trackName WHERE CourseID=@courseID");
            cmd.Parameters.AddWithValue("@courseID", courseID);
            cmd.Parameters.AddWithValue("@courseName", courseName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@trackName", trackName);
            return DMLCommand(cmd);
        }
        public static int DeleteCourse(int courseID)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM COURSES WHERE CourseID=@courseID");
            cmd.Parameters.AddWithValue("@courseID", courseID);
            return DMLCommand(cmd);
        }
        public static DataTable GetProfile(int userID)
        {
            SqlCommand cmd = new SqlCommand("Select * FROM UserProfiles Where UserID=@userID");
            cmd.Parameters.AddWithValue("@userID", userID);
            return SelectCommand(cmd);
        }
        public static int UpdateUserProfileSelective(int userID, string fullName, string email, string phone, byte[] imageBytes)
        {
            StringBuilder query = new StringBuilder("UPDATE UserProfiles SET ");
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (fullName != null)
            {
                query.Append("FullName=@FullName, ");
                parameters.Add(new SqlParameter("@FullName", fullName));
            }

            if (email != null)
            {
                query.Append("Email=@Email, ");
                parameters.Add(new SqlParameter("@Email", email));
            }

            if (phone != null)
            {
                query.Append("Phone=@Phone, ");
                parameters.Add(new SqlParameter("@Phone", phone));
            }

            if (imageBytes != null)
            {
                query.Append("ProfileImage=@Image, ");
                parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary) { Value = imageBytes });
            }

            if (parameters.Count == 0)
                return 0; // Nothing to update

            // Remove trailing comma
            query.Length -= 2;
            query.Append(" WHERE UserID=@UserID");
            parameters.Add(new SqlParameter("@UserID", userID));

            SqlCommand cmd = new SqlCommand(query.ToString());
            cmd.Parameters.AddRange(parameters.ToArray());

            return DMLCommand(cmd);
        }

    }
}
