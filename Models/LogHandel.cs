using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TestWebAppliction.Models.Coordinator;
using System.Web.Mvc;

namespace TestWebAppliction.Models
{
    public class LogHandel
    {

        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Coor *********************
        public bool LogIn(string UserName,string Password)
        {
            int status = 0;

            connection();
            SqlCommand cmd1 = new SqlCommand("LoginProcedure", con);
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@UserName", UserName);
            cmd1.Parameters.AddWithValue("@Password",Password);

            SqlParameter statusParameter = new SqlParameter("@Status", System.Data.SqlDbType.Int);
            statusParameter.Direction = System.Data.ParameterDirection.Output;
            cmd1.Parameters.Add(statusParameter);
            con.Open();
            cmd1.ExecuteNonQuery();

            status = (int)cmd1.Parameters["@Status"].Value;

            con.Close();

            if (status == 1)
                return true;
            else
                return false;
        }
    }
}