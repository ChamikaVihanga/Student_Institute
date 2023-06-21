using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TestWebAppliction.Models
{
    public class StudentModel
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; }

        [Required(ErrorMessage = "StudentNo name is required.")]
        public int StudentNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        //.........
        public int BatchModelId { get; set; }
        public BatchModel BatchModel { get; set; }
        

        //.........
        public List<StudentCourseModel> StudentCoursesModel { get; set; }
        /*public List<PaymentModel> paymentModels { get; set; }*/

    }
}