using System;
using System.Data;
using System.Data.SqlClient;

namespace CommandFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=biginPre;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

            Reader(@"Select * from firstStep;", connectionString);
            Console.WriteLine("insert!");
            Execute(@"Insert into firstStep([key],value) VALUES('A','alpha')", connectionString);
            ParameterizedCreate("B", "bravo", connectionString);
            Reader(@"Select * from firstStep;", connectionString);


        }
        private static void Reader(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
            }
        }

        private static int Execute(string queryString, string connectionString)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            return command.ExecuteNonQuery();
        }

        private static int ParameterizedCreate(string key, string value, string connectionString)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string createSql = @"Insert into firstStep([key],value) VALUES(@KEY,@VALUE)";
            SqlCommand command = new SqlCommand(createSql, connection);
            command.Connection.Open();
            command.Parameters.Add("@KEY", SqlDbType.NChar, 10);
            command.Parameters.Add("@VALUE", SqlDbType.NChar, 10);
            command.Parameters["@KEY"].Value = key;
            command.Parameters["@VALUE"].Value = value;

            return command.ExecuteNonQuery();
        }

        //static void Main()
        //{
        //    string str = @"Data Source=LocalHost;Initial Catalog=biginPre;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        //    //string str = "Data Source=LAPTOP-VSS7FKD8;Initial Catalog=biginPre;user id=sal;password=P@ssw0rd";
        //    //+ "Integrated Security=SSPI";
        //    string qs = "SELECT * FROM firstStep;";
        //    CreateCommand(qs, str);
        //}
        //private static void CreateCommand(string queryString,
        //    string connectionString)
        //{
        //    using (SqlConnection connection = new SqlConnection(
        //        connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);

        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}