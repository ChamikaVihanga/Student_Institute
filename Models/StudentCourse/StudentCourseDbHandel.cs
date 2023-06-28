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
            SqlCommand cmd = new SqlCommand("AddNewStuCoreBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@StudentID", scmodel.StudentId);
            cmd.Parameters.AddWithValue("@CourseID", scmodel.CourseModeId);
            cmd.Parameters.AddWithValue("@BatchID", scmodel.BatchModelId);
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

            SqlCommand cmd = new SqlCommand("GetStuCourBatch", con);
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
                        ID = Convert.ToInt32(dr["StuCourBatchID"]),
                        Amount = Convert.ToString(dr["Amount"]),
                        StudentId = Convert.ToInt32(dr["StudentID"]),
                        CourseModeId = Convert.ToInt32(dr["CourseID"]),
                        BatchModelId = Convert.ToInt32(dr["BatchID"]),
                        StudentModel = new StudentModel { Name = Convert.ToString(dr["Name"]), StudentNo = Convert.ToInt16(dr["StudentNo"]) },
                        CourseModel = new CourseModel { CourseName = Convert.ToString(dr["CoureseName"]), CouresePrice = Convert.ToString(dr["CoursePrice"]) },
                        BatchModel = new BatchModel { BatchNumber = Convert.ToInt16(dr["BatchNumber"])}
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
            SqlCommand cmd = new SqlCommand("UpdateStuCourBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StuCourBatchID", cmodel.ID);
            cmd.Parameters.AddWithValue("@StudentID", cmodel.StudentId);
            cmd.Parameters.AddWithValue("@CourseID", cmodel.CourseModeId);
            cmd.Parameters.AddWithValue("@BatchID", cmodel.BatchModelId);
            cmd.Parameters.AddWithValue("@Amount", cmodel.Amount);


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
            SqlCommand cmd = new SqlCommand("DeleteStuCourBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StuCourBatchID", id);

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