using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models.Course
{
    public class CourseDbHandel
    {
       
            private SqlConnection con;
            private void connection()
            {
                string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
                con = new SqlConnection(constring);
            }

            // **************** ADD NEW STUDENT *********************
            public bool AddCourse(CourseModel cmodel)
            {
                connection();
                SqlCommand cmd = new SqlCommand("AddNewCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CoureseName", cmodel.CourseName);
                cmd.Parameters.AddWithValue("@CoursePrice", cmodel.CouresePrice);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }

            // ********** VIEW STUDENT DETAILS ********************
            public List<CourseModel> GetCourse()
            {
                connection();
                List<CourseModel> courseList = new List<CourseModel>();

                SqlCommand cmd = new SqlCommand("GetCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    courseList.Add(
                        new CourseModel
                        {
                            ID = Convert.ToInt32(dr["CourseID"]),
                            CourseName = Convert.ToString(dr["CoureseName"]),
                            CouresePrice = Convert.ToString(dr["CoursePrice"])       
                        });
                }
                return courseList;
            }

            // ***************** UPDATE STUDENT DETAILS *********************
            public bool UpdateCourse(CourseModel cmodel)
            {
                connection();
                SqlCommand cmd = new SqlCommand("UpdateCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StdId", cmodel.ID);
                cmd.Parameters.AddWithValue("@Name", cmodel.CourseName);
                cmd.Parameters.AddWithValue("@City", cmodel.CouresePrice);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }

            // ********************** DELETE STUDENT DETAILS *******************
            public bool DeleteCourse(int id)
            {
                connection();
                SqlCommand cmd = new SqlCommand("DeleteCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CourseID", id);

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