using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CommandFirst
{
    class Program
    {
        static void Main()
        {
            string str = @"Data Source=LocalHost;Initial Catalog=biginPre;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            //string str = "Data Source=LAPTOP-VSS7FKD8;Initial Catalog=biginPre;user id=sal;password=P@ssw0rd";
            //+ "Integrated Security=SSPI";
            string qs = "SELECT * FROM firstStep;";
            CreateCommand(qs, str);
        }
        private static void CreateCommand(string queryString,
            string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}