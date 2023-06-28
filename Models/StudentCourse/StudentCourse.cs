using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models
{
    public class StudentCourseModel
    {
        public int ID { get; set; }
        
        //.................
        public int StudentId { get; set;}
        public StudentModel StudentModel { get; set; }

        //.....................
        public int CourseModeId { get; set; }
        public CourseModel CourseModel { get; set; }

        public string Amount { get; set; }

        //................
        public int BatchModelId { get; set; }
        public BatchModel BatchModel { get; set; }

        //................
        public List<PaymentModel> paymentModels { get; set; }
        /*public List<StudentModel> studentModels { get; set; }*/



    }
}