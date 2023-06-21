using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models.Coordinator
{
    public class CoordinatorModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        
        public string ContactNumber { get; set;}

        [Required(ErrorMessage = "User Name Required")]
        public string Password { get; set; }
        
    }
}