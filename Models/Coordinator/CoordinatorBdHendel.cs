using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TestWebAppliction.Models.Coordinator;
using TestWebAppliction.Models;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast;

namespace TestWebAppliction.Controllers
{
    public class CoordinatorBdHendel

    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Coor *********************
        public bool AddCoor(CoordinatorModel smodel)
        {
            connection();
            SqlCommand cmd1 = new SqlCommand("AddNewCoor", con);
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@UserName", smodel.UserName);
            cmd1.Parameters.AddWithValue("@ContactNumber", smodel.ContactNumber);
            cmd1.Parameters.AddWithValue("@Password", smodel.Password);

            con.Open();
            int i = cmd1.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        /* private String connectionString = "Data Source=DESKTOP-88C78GN\\SQLEXPRESS;Initial Catalog=testdb;Integrated Security=True";*/
        // ********** VIEW Coor DETAILS ********************
        public List<CoordinatorModel> GetCoor()
        {
            connection();
            List<CoordinatorModel> coordinatorList = new List<CoordinatorModel>();

            SqlCommand cmd = new SqlCommand("GetCoor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                coordinatorList.Add(
                    new CoordinatorModel
                    {
                        ID = Convert.ToInt32(dr["Id"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        ContactNumber = Convert.ToString(dr["ContactNumber"]),
                        Password = Convert.ToString(dr["Password"])
                    });
            }
            return coordinatorList;

            /* List<CoordinatorModel> list = new List<CoordinatorModel>();

             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 conn.Open();
                 string procedure = "GetAllVideos";


                 //SqlCommand qr = new SqlCommand("select * from Videos", conn);
                 SqlCommand cmd = new SqlCommand(procedure, conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 SqlDataReader vrd = cmd.ExecuteReader();

                 while (vrd.Read())
                 {
                     CoordinatorModel cood = new CoordinatorModel();
                     *//*cood.Id = vrd.GetInt32();*//*
                     cood.UserName = vrd.GetString(0);
                     cood.Password = vrd.GetString(1);


                     list.Add(cood);
                 }
                 conn.Close();
             }
             return Task.FromResult(list);
 */


        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateCoor(CoordinatorModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateCoor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CoorId", smodel.ID);
            cmd.Parameters.AddWithValue("@UserName", smodel.UserName);
            cmd.Parameters.AddWithValue("@ContactNumber", smodel.ContactNumber);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteCoor(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteCoor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CoorId", id);

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
