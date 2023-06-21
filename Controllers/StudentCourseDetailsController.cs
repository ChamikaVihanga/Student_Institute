using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebAppliction.Models.StudentCourse;
using System.Configuration;

namespace TestWebAppliction.Controllers
{
    public class StudentCourseDetailsController : Controller
    {

        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // GET: StudentCourseDetails
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetStudentCourseDetails(int studentID)
        {
            List<StudentCourseDetailsModel> studentCourse = new List<StudentCourseDetailsModel>();


            using (SqlConnection connection = new SqlConnection("TestWebApCon"))
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
        }

    }
}