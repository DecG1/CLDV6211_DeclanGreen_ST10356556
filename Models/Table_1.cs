using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace WebApplication1.Models
{
	public class Table_1 
	{
public static string con_string = "Server=tcp:cldv-sql-server1.database.windows.net,1433;Initial Catalog=cloud-db;Persist Security Info=False;User ID=Dec1;Password={WhatCanMagicDo_96};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

public static SqlConnection con = new SqlConnection(con_string);


		public String Name {  get; set; }

		public String Surname { get; set; }

		public String Email {  get; set; }



		public int InsertUser(Table_1 table)
		{


		
                string sql = "INSERT INTO Table_1 (user_Name, user_Surname, user_Email) VALUES (@Name, @Surname, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", table.Name); ;
                cmd.Parameters.AddWithValue("@Surname", table.Surname);
                cmd.Parameters.AddWithValue("@Email", table.Email);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
		
	}
}
