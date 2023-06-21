using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestWebAppliction.Models.Clerk;
using TestWebAppliction.Models.Coordinator;



namespace TestWebAppliction.Models.Student
{
    public class EntityModelModel : DbContext
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }
        /*public EntityModel() 
            : base("Name=EntityModel")
        { 
        }*/
       
        public DbSet<CoordinatorModel> CoordinatorModels { get; set; }
        public DbSet<StudentModel> StudentModels { get; set; }
        public DbSet<S_Clerk> Clerk { get; set; }
        public DbSet<PaymentModel> PaymentModels { get; set; }
        public DbSet<BatchModel> BatchModels { get; set; }
        public DbSet<StudentCourseModel> StudentCourseModels { get; set;}
        public DbSet<CourseModel> CourseModels { get; set; }

        
    }
    
}