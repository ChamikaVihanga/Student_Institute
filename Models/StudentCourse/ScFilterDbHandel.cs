using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models.StudentCourse
{
    public class ScFilterDbHandel
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }
        public StudentCourseModel GetCourseByID(int cId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString(); // Replace with your actual database connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetCourseByID", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter for CourseID
                command.Parameters.AddWithValue("@CourseID", cId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                StudentCourseModel course = null;

                if (reader.Read())
                {
                    // Retrieve course details from the SqlDataReader
                    int courseId = reader.GetInt32(0);
                    string courseName = reader.GetString(1);
                    string coursePrice = reader.GetString(2);
                    // Create a new Course object
                    course = new StudentCourseModel()
                    {
                        CourseModeId = courseId,
                        CourseModel = new CourseModel {CourseName = courseName, CouresePrice=coursePrice }

                        //ID = courseId,
                        //CourseName = courseName,
                        //CouresePrice = coursePrice
                    };
                }
                reader.Close();
                connection.Close();
                return course;
            }
        }


        public List<StudentCourseModel> GetFilter(int id)
        {
            connection();
            List<StudentCourseModel> scList = new List<StudentCourseModel>();

            SqlCommand cmd = new SqlCommand("GetStudentCourseDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentNo", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                scList.Add(
                    new StudentCourseModel
                    {
                        ID = Convert.ToInt32(dr["StuCourBatchID"]),
                        StudentId = Convert.ToInt32(dr["StudentID"]),
                        /*CourseModeId = Convert.ToInt32(dr["CourseID"]),*/
                        StudentModel = new StudentModel { Name = Convert.ToString(dr["Name"]), StudentNo = Convert.ToInt16(dr["StudentNo"]) },
                        CourseModel = new CourseModel { CourseName = Convert.ToString(dr["CoureseName"]), CouresePrice = Convert.ToString(dr["CoursePrice"]) }
                    });
            }
            return scList;

        }
    }
}