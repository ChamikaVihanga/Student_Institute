using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TestWebAppliction.Models.Coordinator;

namespace TestWebAppliction.Models.Clerk
{
    public class ClerkDbHandel
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Clark *********************
        public bool AddClark(S_Clerk cmodel)
        {
            connection();
            SqlCommand cmd1 = new SqlCommand("AddNewClerk", con);
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@C_UserName", cmodel.C_UserName);
           
            cmd1.Parameters.AddWithValue("@C_Password", cmodel.C_Password);

            con.Open();
            int i = cmd1.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        
        // ********** VIEW Clerk DETAILS ********************
        public List<S_Clerk> GetCLerk()
        {
            connection();
            List<S_Clerk> ClerkList = new List<S_Clerk>();

            SqlCommand cmd = new SqlCommand("GetClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ClerkList.Add(
                    new S_Clerk
                    {
                        Id = Convert.ToInt32(dr["ClerkId"]),
                        C_UserName = Convert.ToString(dr["C_UserName"]),
                        C_Password = Convert.ToString(dr["C_Password"])
                    });
            }
            return ClerkList;
        }

        // ***************** UPDATE Clerk DETAILS *********************
        public bool UpdateClerk(S_Clerk cmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CoorId", cmodel.Id);
            cmd.Parameters.AddWithValue("@C_UserName", cmodel.C_UserName);
            cmd.Parameters.AddWithValue("@C_Password", cmodel.C_Password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE clerk DETAILS *******************
        public bool DeleteClerk(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateClerk", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClerkId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        internal bool AddCoordinator(StudentModel smodel)
        {
            throw new NotImplementedException();
        }
    }
}