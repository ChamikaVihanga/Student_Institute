using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models
{
    public class BatchModel
    {
        public int ID { get; set; }
        public int BatchNumber { get; set; }
        public DateTime CreateDate { get; set; }

        public List<StudentCourseModel> StudentCourseModels { get; set; }
       /* public List<StudentModel> StudentModels { get; set; }*/

       /* public int CourseID { get; set; }
        public CourseModel CourseModel { get; set; }*/

        /*public string CostOfBatch { get; set; }*/

        

        /*public int StudentID { get; set; }
        public StudentModel StudentModel { get; set; }*/
    }
}