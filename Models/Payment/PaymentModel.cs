using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Web;

namespace TestWebAppliction.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }  
        public DateTime PayDate { get; set; }
        public string PayMethard { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }

        /*public int StudenModeltId { get; set; }
        public StudentModel StudentModel { get; set; }
        
        public int BatchModelId { get; set; }
        public BatchModel BatchModel { get; set; }*/

        public int StudentCourseModelID { get; set; }
        public StudentCourseModel StudentCourseModel { get; set; }


    }
    public enum Methard
    {
        Cash,
        Card
    }
}