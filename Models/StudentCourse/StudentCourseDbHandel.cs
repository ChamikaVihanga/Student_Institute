using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models.StudentCourse
{
    public class StudentCourseDbHandel
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddSC(StudentCourseModel scmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStudentCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@StudentID", scmodel.StudentId);
            cmd.Parameters.AddWithValue("@CourseID", scmodel.CourseModeId);
            cmd.Parameters.AddWithValue("@Amount", scmodel.Amount);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<StudentCourseModel> GetSC()
        {
            connection();
            List<StudentCourseModel> courseList = new List<StudentCourseModel>();

            SqlCommand cmd = new SqlCommand("GetStudentCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                courseList.Add(
                    new StudentCourseModel
                    {
                        ID = Convert.ToInt32(dr["StudentCourseID"]),
                        Amount = Convert.ToString(dr["Amount"]),
                        StudentId = Convert.ToInt32(dr["StudentID"]),
                        CourseModeId = Convert.ToInt32(dr["CourseID"]),
                        StudentModel = new StudentModel { Name = Convert.ToString(dr["Name"]), StudentNo = Convert.ToInt16(dr["StudentNo"]) },
                        CourseModel = new CourseModel { CourseName = Convert.ToString(dr["CoureseName"]), CouresePrice = Convert.ToString(dr["CoursePrice"]) }
                    });
            }
            return courseList;
        }

        //****************** get for Payment *******************

       /* public List <StudentCourseModel> SetFilter ()
        {
            connection();
            List<StudentCourseModel> scList = new List<StudentCourseModel>();
            SqlCommand cmd = new SqlCommand("GetStudentCourseDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                scList.Add(
                    new StudentCourseModel
                    {
                        ID = Convert.ToInt32(dr["StudentCourseID"]),
                        StudentModel = new StudentModel { Name = Convert.ToString(dr["Name"]), StudentNo = Convert.ToInt16(dr["StudentNo"])},
                        CourseModel = new CourseModel { CourseName = Convert.ToString(dr["CoureseName"]), CouresePrice = Convert.ToString(dr["CoursePrice"]) }
                    });
            }
            return scList;

        }*/

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateSC(StudentCourseModel cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentCourseID", cmodel.ID);
            cmd.Parameters.AddWithValue("@Amount", cmodel.Amount);
            cmd.Parameters.AddWithValue("@StudentID", cmodel.StudentId);
            cmd.Parameters.AddWithValue("@CourseID", cmodel.CourseModeId);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteSC(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudentCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentCourseID", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}