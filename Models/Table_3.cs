using System.Data.SqlClient;

namespace Online_Store.Models
{
    public class Table_3
    {

        public static string con_string = "Server=tcp:cldv-sql-server1.database.windows.net,1433;Initial Catalog=cloud-db;Persist Security Info=False;User ID=Dec1;Password=WhatCanMagicDo_96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int TransactionID { get; set; }
        public int UserID { get; set; }

        public int ProductID { get; set; }


        public int InsertTransaction(Table_3 table)
        {
            try
            {
                string sql = "INSERT INTO Table_3 (UserID, ProductID) VALUES (@UserID, @ProductID)";
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@UserID", table.UserID);
                    cmd.Parameters.AddWithValue("@ProductID", table.ProductID);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Table_3> GetTransaction()
        {
            List<Table_3> transactions = new List<Table_3>();
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Table_3";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    Table_3 transaction = new Table_3();
                    transaction.TransactionID = Convert.ToInt32(rdr["TransactionID"]);
                    transaction.UserID = Convert.ToInt32(rdr["UserID"]);
                    transaction.ProductID = Convert.ToInt32(rdr["ProductID"]);

                    transactions.Add(transaction);
                }
            }
            return transactions;
        }
    }
}
