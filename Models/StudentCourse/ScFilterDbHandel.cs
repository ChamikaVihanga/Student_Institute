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