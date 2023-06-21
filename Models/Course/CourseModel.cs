using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string CouresePrice { get; set; }

        //.....................
        public List<StudentCourseModel> StudentCoursesModel { get; set; }
    }
}