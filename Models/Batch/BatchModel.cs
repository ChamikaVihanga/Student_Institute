using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebAppliction.Models
{
    public class BatchModel
    {
        public int ID { get; set; }
        public string BatchName { get; set; }
        public string CreateDate { get; set; }

        public List<StudentModel> StudentModels { get; set; }

        /*public string CostOfBatch { get; set; }*/

        

        /*public int StudentID { get; set; }
        public StudentModel StudentModel { get; set; }*/
    }
}