using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TestWebAppliction.Controllers;

namespace TestWebAppliction.Models
{
    public class StudentDbHandel
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddStudent(StudentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", con);
            SqlCommand cmd1 = new SqlCommand("AddNewStudentCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@StudentNo", smodel.StudentNo);
            cmd.Parameters.AddWithValue("@Age", smodel.Age);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);
            cmd.Parameters.AddWithValue("@BatchID", smodel.BatchModelId);
            cmd1.Parameters.AddWithValue("@CourseID", smodel.StudentCourseModel.CourseModeId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<StudentModel> GetStudent()
        {
            connection();
            List<StudentModel> studentlist = new List<StudentModel>();

            SqlCommand cmd = new SqlCommand("getStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new StudentModel
                    {
                        ID = Convert.ToInt32(dr["StudentId"]),
                        Name = Convert.ToString(dr["Name"]),
                        StudentNo = Convert.ToInt16(dr["StudentNo"]),
                        Age = Convert.ToString(dr["Age"]),     
                        Address = Convert.ToString(dr["Address"]),
                        Password = Convert.ToString(dr["Password"]),
                        BatchModelId = Convert.ToInt32(dr["BatchID"]),
                        BatchModel = new BatchModel { BatchName = Convert.ToString(dr["BatchName"]),}
                    });
            }
            return studentlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(StudentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StuId", smodel.ID);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@StudentNo", smodel.StudentNo);
            cmd.Parameters.AddWithValue("@Age", smodel.Age);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);
            cmd.Parameters.AddWithValue("@BatchID", smodel.BatchModelId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StuId", id);

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