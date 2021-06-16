using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0DbContext.Models;

namespace P0._1._0
{
    class CheckIf
    {
        DBContext context = new DBContext();
        public CheckIf()
        {
            //Console.WriteLine("Input Validation Module Started.");
        }
        public bool ValidLocation(int location)
        {
            List<Location> result = context.Locations.Where(row => row.LocationId == location).ToList();
            foreach (var row in result)
            {
                //Debug Statement
                //Console.WriteLine("Checked Location: " + location + ": " + row.LocationId);
                return true;
            }
            return false;
        }

        public bool ValidLocation(string location)
        {
            List<Location> result = context.Locations.Where(row => row.LocationName == location).ToList();
            foreach (var row in result)
            {
                //Debug Statement
                //Console.WriteLine("Checked Location: " + location + ": " + row.LocationId);
                return true;
            }
            return false;
        }

        public bool UsedUserName(string userName)
        {
            List<Customer> result = context.Customers.Where(row => row.UserName == userName).ToList();
            foreach (var row in result)
            {
                return true;
            }
            return false;
        }
    }
}
