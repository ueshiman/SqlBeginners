using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using Dapper;
using System.Data.SqlClient;

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

            foreach (var firstClass in firstClasses)
            {
                Console.WriteLine($"{firstClass.id}, {firstClass.key}, {firstClass.value}");
            }



            var firstClasses2 = connection.Query<FirstClass>(@"
SELECT id, 
CASE 
WHEN [key] = 'apple' then '林檎'
WHEN [key] = 'banana' then 'バナナ'
WHEN [key] = 'tomato' then 'トマト'
ELSE [key] END as [key]
, value
FROM firstStep");

            foreach (var firstClass in firstClasses2)
            {
                Console.WriteLine($"{firstClass.id}, {firstClass.key}, {firstClass.value}");
            }
        }
    }

    public class FirstClass
    {
        public int? id { get; set; }

        public string key { get; set; }

        public string value { get; set; }
    }

 
}
