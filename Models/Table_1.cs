using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace Online_Store.Models
{
    public class Table_1
    {
        public static string con_string = "Server=tcp:cldv-sql-server1.database.windows.net,1433;Initial Catalog=cloud-db;Persist Security Info=False;User ID=Dec1;Password=WhatCanMagicDo_96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);


        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }



        public int InsertUser(Table_1 table)
        {

            try
            {

                string sql = "INSERT INTO Table_1 (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", table.Name); ;
                cmd.Parameters.AddWithValue("@Surname", table.Surname);
                cmd.Parameters.AddWithValue("@Email", table.Email);
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
    }
}
