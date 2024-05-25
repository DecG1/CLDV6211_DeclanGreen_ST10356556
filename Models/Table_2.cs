using System.Data.SqlClient;

namespace Online_Store.Models
{
    public class Table_2


    {

        public static string con_string = "Server=tcp:cldv-sql-server1.database.windows.net,1433;Initial Catalog=cloud-db;Persist Security Info=False;User ID=Dec1;Password=WhatCanMagicDo_96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";

        public static SqlConnection con = new SqlConnection(con_string);


        public int ProductID {  get; set; }  
        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }



        public int Insert_product(Table_2 p)
        {


            try
            {
                string sql = "INSERT INTO Table_2 (ProductName, ProductPrice, ProductCategory, ProductAvailibility) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }


        


        public static List<Table_2> GetAllProducts()
        {
            List<Table_2> products = new List<Table_2>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Table_2";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Table_2 product = new Table_2();
                    product.ProductID = Convert.ToInt32(rdr["ProductID"]);
                    product.Name = rdr["ProductName"].ToString();
                    product.Price = rdr["ProductPrice"].ToString();
                    product.Category = rdr["ProductCategory"].ToString();
                    product.Availability = rdr["ProductAvailibility"].ToString();

                    products.Add(product);
                }   
            }
           
            return products;
        }

    }
}

