using System;
using System.Linq;
using sqlBasicPre.DataAccess.DbContexts;

namespace sqlBasicPre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyDbContext myDbContext = new MyDbContext();

            string[] inn = {"aaa", "bbb", "ccc"};

            //var v = myDbContext.FirstSteps.Where(s=>inn.Contains(s.Key)).ToArray();
            var v = myDbContext.FirstSteps.ToArray();
        }
    }
}
