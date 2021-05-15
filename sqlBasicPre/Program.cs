using System;
using System.Linq;
using System.Runtime.Intrinsics;
using Microsoft.EntityFrameworkCore;
using sqlBasicPre.DataAccess.DataAccessModels;
using sqlBasicPre.DataAccess.DbContexts;

namespace sqlBasicPre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Selected();

            FromSql();


        }

        private static void Selected()
        {
            string[] inn = { "apple", "A", "B" };

            MyDbContext myDbContext = new MyDbContext();

            var where = myDbContext.FirstSteps.Find(1);

            Console.WriteLine($"{where.Id},{where.Key},{where.Value}");


            var all = myDbContext.FirstSteps;

            Console.WriteLine("all");
            foreach (FirstStep firstStep in all)
            {
                Console.WriteLine($"{firstStep.Id},{firstStep.Key},{firstStep.Value}");
            }

            Console.WriteLine("find");




            var contain = myDbContext.FirstSteps.Where(s => inn.Contains(s.Key));

            foreach (FirstStep firstStep in contain)
            {
                Console.WriteLine($"{firstStep.Id},{firstStep.Key},{firstStep.Value}");
            }

            var contain2 = myDbContext.FirstSteps.Where(s => inn.Contains(s.Key));

            var v = contain2.GetEnumerator();

            while (v.MoveNext())
            {
                var firstStep = v.Current;
                Console.WriteLine($"{firstStep?.Id},{firstStep?.Key},{firstStep?.Value}");
            }

            var v1 = myDbContext.FirstSteps;
            var v2 = v1.Where(s => inn.Contains(s.Key));

            foreach (FirstStep firstStep in v2)
            {
                Console.WriteLine($"{firstStep.Id},{firstStep.Key},{firstStep.Value}");
            }
            Console.WriteLine("-------------------------------");

            var v3 = v2.Where(f => f.Key == "A");

            foreach (FirstStep firstStep in v3)
            {
                Console.WriteLine($"{firstStep.Id},{firstStep.Key},{firstStep.Value}");
            }

        }

        private static void FromSql()
        {
            MyDbContext myDbContext = new MyDbContext();

            string kye = "A";

            var fromSql = myDbContext.FirstSteps.FromSqlInterpolated($"Select * from firstStep where [key] = {kye}");

            foreach (FirstStep firstStep in fromSql)
            {
                Console.WriteLine($"{firstStep.Id},{firstStep.Key},{firstStep.Value}");
            }

            System.FormattableString sql = $"Select * from firstStep where [key] = {kye}";
            var fromSql2 = myDbContext.FirstSteps.FromSqlInterpolated(sql);

            foreach (FirstStep firstStep in fromSql2)
            {
                Console.WriteLine($"{firstStep.Id},{firstStep.Key},{firstStep.Value}");
            }
        }
    }
}
