using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models.StudentCourse;

namespace TestWebAppliction.Models.Payment
{
    public class PaymentDbHandel
    {
        private SqlConnection con;
        private void connection()
        {   
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        //****************** add new pay *************
        
        public bool AddPay(PaymentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewPayment", con);
            cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.AddWithValue("@PayDate", smodel.PayDate);
            cmd.Parameters.AddWithValue("@StudentCourseID", smodel.StudentCourseModelID);
            cmd.Parameters.AddWithValue("@PayMethard", smodel.PayMethard);
            cmd.Parameters.AddWithValue("@Price", smodel.Price);

            /*cmd.Parameters.AddWithValue("@StudentID", smodel.StudenModeltId);
            cmd.Parameters.AddWithValue("@BatchID", smodel.BatchModelId);*/

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        /* public ActionResult GetStudentCourseDetails(int studentID)
         {
             List<StudentCourseDetailsModel> studentCourse = new List<StudentCourseDetailsModel>();

              
             using (SqlConnection connection = new SqlConnection("YourConnectionString"))
             {
                
                 using (SqlCommand command = new SqlCommand("GetStudentCourseDetails", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;

                      
                     command.Parameters.AddWithValue("@StudentID", studentID);

                     connection.Open();

                     using (SqlDataReader reader = command.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             StudentCourseDetailsModel details = new StudentCourseDetailsModel();
                             details.StudentName = reader["StudentName"].ToString();
                             details.CourseName = reader["CourseName"].ToString();
                             details.CoursePrice = Convert.ToDecimal(reader["CoursePrice"]);

                           
                         }
                     }
                 }
             }

             
             return View(studentCourse);
         }*/

        private ActionResult View(List<StudentCourseDetailsModel> studentCourse)
        {
            throw new NotImplementedException();
        }

        /*  private ActionResult View(List<StudentCourseDetailsModel> studentCourse)
          {
              throw new NotImplementedException();
          }*/



        // ********** VIEW Payment DETAILS ********************
        public List<PaymentModel> GetPayment()
        {
            connection();
            List<PaymentModel> payList = new List<PaymentModel>();
            List<StudentModel> studentList = new List<StudentModel>();  
            StudentModel studentModel = new StudentModel();

            SqlCommand cmd = new SqlCommand("GetPay", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                payList.Add(
                    new PaymentModel
                    {
                        Id = Convert.ToInt32(dr["PaymentId"]),
                        PayDate = Convert.ToDateTime(dr["PayDate"]),      
                        StudentCourseModelID = Convert.ToInt32(dr["StudentCourseID"]),
                        Price = Convert.ToString(dr["Price"]),
                        PayMethard = Convert.ToString(dr["PayMethard"]),
                        StudentCourseModel = new StudentCourseModel { StudentModel = new StudentModel { Name = Convert.ToString(dr["Name"]) }, CourseModel = new CourseModel {CourseName = Convert.ToString(dr["CoureseName"])}}  
                    });
            }
            return payList;
        }



        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdatePay(PaymentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePay", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PaymentId", smodel.Id);
            cmd.Parameters.AddWithValue("@PayDate", smodel.PayDate);
            cmd.Parameters.AddWithValue("@Methard", smodel.PayMethard);
            cmd.Parameters.AddWithValue("@Price", smodel.Price);
            cmd.Parameters.AddWithValue("@StudentCourseID", smodel.StudentCourseModelID);

            /*cmd.Parameters.AddWithValue("@StudentID", smodel.StudenModeltId);
            cmd.Parameters.AddWithValue("@BatchID", smodel.BatchModelId);*/

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeletePay(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeletePay", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PaymentId", id);

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