using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P0DbContext.Models;

namespace P0._1._0
{
    class Fetch
    {
        DBContext context = new DBContext();
        public Fetch()
        {
            //Console.WriteLine("Fetch Module Start.");
        }

        public int LocationID(string locationName)
        {
            List<Location> result = context.Locations.Where(row => row.LocationName == locationName).ToList();
            foreach (var row in result)
            {
                return row.LocationId;
            }
            return -1;
        }

        public Location LocationInfo(int locationId)
        {
            Location result = new Location();
            List<Location> place = context.Locations.Where(row => row.LocationId == locationId).ToList();
            foreach (var row in place)
            {
                return row;
            }
            return result;
        }

        public List<string> StringListofAllLocations()
        {
            List<string> locations = new List<string>();
            string StringBuffer = "";
            foreach (var row in context.Locations)
            {
                StringBuffer = row.LocationName;
                //StringBuffer = "ID: " + row.LocationId + ": " + row.LocationName;
                locations.Add(StringBuffer);
            }
            return locations;
        }

        public Location LocationByIndex(int index)
        {

            Location result = new Location();
            foreach (var row in context.Locations)
            {
                if(index == 1)
                {
                    return row;
                }
                else
                {
                    index--;
                }
            }
            return result;
        }

        public List<string> UserNamesByFirstName(string Name)
        {
            string StringBuffer = "";
            List<string> ResultingList = new List<string>();
            List<Customer> MyQuery = context.Customers.Where(row => row.FirstName == Name).ToList();
            /*
            if(MyQuery != null)
            {
                ResultingList.Add("No Account could be found with the first name " + Name);
            }
            else
            {
                ResultingList.Add("Accounts with the first name " + Name);
            }
            */
            foreach (var row in MyQuery)
            {
                StringBuffer = row.FirstName + " " + row.LastName + ": " + row.UserName;
                ResultingList.Add(StringBuffer);
            }
            return ResultingList;
        }

        public Customer GetUserInfo(int userId)
        {
            Customer result = new Customer();
            List<Customer> user = context.Customers.Where(row => row.CustomerId == userId).ToList();
            foreach (var row in user)
            {
                return row;
            }
            return result;
        }

        public Customer GetUserInfo(string userName)
        {
            Customer result = new Customer();
            List<Customer> user = context.Customers.Where(row => row.UserName == userName).ToList();
            foreach(var row in user)
            {
                return row;
            }
            return result;
        }

        public string ProductNameFromProductID(int productID)
        {
            string name = (from row in context.Products
                           where row.ProductId == productID
                           select row.ProductName).ToString();

            return name;
        }

        public Product ProductFromProductID(int productID)
        {
            Product item = new Product();
            List<Product> result = context.Products.Where(row => row.ProductId == productID).ToList();
            foreach(var row in result)
            {
                item = row;
            }
            return item;
        }

        public Inventory InventoryFromProductID(int productID, int locationID)
        {
            Inventory item = new Inventory();
            List<Inventory> result = context.Inventories.Where(row => row.ProductId == productID && row.LocationId == locationID).ToList();
            foreach (var row in result)
            {
                item = row;
            }
            return item;
        }
    }
}

