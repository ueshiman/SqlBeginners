using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using SqlConnection connection = new SqlConnection();
            // Data Source=LAPTOP-VSS7FKD8;Initial Catalog=biginPre;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False
            connection.ConnectionString = @"Server=localhost;Database=biginPre;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            //connection.ConnectionString = @"Data Source=LAPTOP-VSS7FKD8;Initial Catalog=biginPre;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            //connection.ConnectionString = @"Server =LAPTOP-VSS7FKD8;Database=biginPre;Trusted_Connection=True";
            //connection.ConnectionString = @"Data Source =LAPTOP-VSS7FKD8\biginPre;User Id = sa; Password = P@ssw0rd;";
            //using SqlConnection connection = new SqlConnection("Server =LAPTOP-VSS7FKD8;Database=biginPre;Trusted_Connection=True");
            //using SqlCommand command = new SqlCommand();

            connection.Open();

            var firstClasses = connection.Query<FirstClass>("SELECT * FROM firstStep");


        }
    }

    public class FirstClass
    {
        public int? id { get; set; }

        public string key { get; set; }

        public string value { get; set; }
    }
}
