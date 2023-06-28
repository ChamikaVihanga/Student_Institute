using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Drawing;

namespace TestWebAppliction.Models.Batch
{
    public class BatchDbhandel
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TestWebApCon"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW Batch *********************
        public bool AddBatch(BatchModel bmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BatchNumber", bmodel.BatchNumber);
            cmd.Parameters.AddWithValue("@CreateDate ", bmodel.CreateDate);
            /*cmd.Parameters.AddWithValue("@CourseID", bmodel.CourseID);*/

            /*cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);*/

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW Batch DETAILS ********************
        public List<BatchModel> GetBatch()
        {
            connection();
            List<BatchModel> batchList = new List<BatchModel>();

            SqlCommand cmd = new SqlCommand("GetBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                batchList.Add(
                    new BatchModel
                    {
                        ID = Convert.ToInt32(dr["BatchId"]),
                        BatchNumber = Convert.ToInt32(dr["BatchNumber"]),
                        CreateDate = Convert.ToDateTime(dr["CreateDate"]),
                       /* CourseID = Convert.ToInt32(dr["CourseID"]),
                        CourseModel = new CourseModel { CourseName = Convert.ToString(dr["CoureseName"])}*/
                 
                    });
            }
            return batchList;
        }

        // ***************** UPDATE Batch DETAILS *********************
        public bool UpdateBatch(BatchModel bmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BatchID", bmodel.ID);
            cmd.Parameters.AddWithValue("@BatchNumber", bmodel.BatchNumber);
            cmd.Parameters.AddWithValue("@Createdate ", bmodel.CreateDate);
            /*cmd.Parameters.AddWithValue("@CourseID", bmodel.CourseID);*/


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Batch DETAILS *******************
        public bool DeleteBatch(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteBatch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BatchId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}