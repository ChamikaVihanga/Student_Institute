using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using TestWebAppliction.Models.Coordinator;

namespace TestWebAppliction.Models
{
    public class Db_Entity : DbContext
    {
       

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }*/



        public DbSet<StudentModel> Students { get; set; }
        public virtual DbSet<CoordinatorModel> Coordinators { get; set; }

        
    }
}