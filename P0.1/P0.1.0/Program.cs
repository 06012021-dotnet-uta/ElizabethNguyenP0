using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using P0DbContext;
using P0DbContext.Models;
using System.Linq;
using System.Data;
using ApplicationLayer;

namespace P0._1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext Context = new DBContext();
            MenuStateMachine Application = new MenuStateMachine();

            Application.Start();

            //Trial things to learn how SQL works in c#

            //Example 1 of SQL Code
            /*
            List<Customer> result = Context.Customers.Where(row => row.FirstName == "Elizabeth").ToList();
            foreach (var row in result)
            {
                Console.WriteLine(row.CustomerId);
            }
            */

            //Example 2 of SQL Code
            /*
            var newcust = new Customer();

            newcust.FirstName = "Elizabeth";
            newcust.LastName = "Nguyen";
            newcust.Age = 25;
            newcust.Age = 25;
            newcust.UserName = "liznguyen12";

            IEnumerable<int> query_row = from Customers in Context.Customers
                                    where Customers.FirstName == "Elizabeth"
                                    select Customers.CustomerId;

            Console.WriteLine("All Customers ID with username: ");
            foreach (var row in query_row)
            {
                Console.WriteLine(row);
            }

            context.Add(newcust);
            context.SaveChanges();
            */

        }

    }
}
