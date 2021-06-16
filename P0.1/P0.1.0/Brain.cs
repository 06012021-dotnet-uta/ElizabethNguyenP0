using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using P0DbContext;
using P0DbContext.Models;
using System.Linq;
using ApplicationLayer;

namespace P0._1._0
{
    public class Brain
    {
        Customer SessionUser = new Customer();
        Location SessionLocation = new Location();
        List<Inventory> SessionCart = new List<Inventory>();
        DBContext context = new DBContext();
        CheckIf CheckIf = new CheckIf();
        Fetch Fetch = new Fetch();

        public Brain()
        {
            //Console.WriteLine("Initializting Controller.");
        }

        public void Start_Point()
        {
            bool task_successful = false;
    
            //Create An Account Task
            //CreateUserAccount();

            //Log-In Task
            LookUpAccountByFirstName();
            
            task_successful = GetLogInInfo();
            while(task_successful == false)
            {
                UserIO.ConsolePrintLn("Account Not Found. Please try again.");
                task_successful = GetLogInInfo();
            }
            UserIO.ConsolePrintLn("Account Found. Logging In.");
            task_successful = false;

            //Choose Location Task
            ChooseNewLocation();

            //View all available products of that store
            DisplayInventoryAtLocation();
        }

        public bool LookUpAccountByFirstName()
        {
            string Fname = UserIO.GetUserInput("Please Enter your first Name for account look up:");
            UserIO.ConsolePrintList(Fetch.UserNamesByFirstName(Fname));

            return true;
        }

        public bool LogIn()
        {
            var task_successful = GetLogInInfo();
            if(task_successful == false)
            {
                UserIO.ConsolePrintLn("Account Not Found. Login Failed.");
                return false;
            }
            return true;
        }
        
        public bool GetLogInInfo()
        {
            SessionUser.UserName = UserIO.GetUserInput("To Log-in, please enter your username: ");
            if(CheckIf.UsedUserName(SessionUser.UserName))
            {
                SessionUser = Fetch.GetUserInfo(SessionUser.UserName);
                //insert Password Check when created.
                return true;
            }
            return false;
        }

        public bool CreateUserAccount()
        {
            bool validInput = false;
            var stringInput = "";
            var newcust = new Customer();

            //Grab User Input For New Account
            newcust.FirstName = GetValid.StringInput(25, "Enter your first Name: ");

            newcust.LastName = GetValid.StringInput(25, "Enter your last Name: ");
            
            newcust.Age = GetValid.Age();

            while(validInput == false)
            {
                stringInput = GetValid.StringInput(25, "Enter a username: ");
                if (CheckIf.UsedUserName(stringInput) == false)
                {
                    validInput = true;
                }
            }
            newcust.UserName = stringInput;
            validInput = false;

            context.Add(newcust);
            context.SaveChanges();

            return true;
        }

        public bool ChooseNewLocation()
        {
            int Option = 0;
            Option = GetValid.OptionChoice(Fetch.StringListofAllLocations());
            SessionLocation = Fetch.LocationByIndex(Option);
            Console.WriteLine("Selected " + SessionLocation.LocationId + ": " + SessionLocation.LocationName);
            /*
            string stringInput = new string("");
            bool validInput = false;
            int LocationID = -1;
            PrintAllLocations();
            while(validInput == false)
            {
                stringInput = UserIO.GetUserInputNoClean("Choose a location to shop from: ");
                validInput = CheckIf.ValidLocation(stringInput);
                if(validInput == false)
                {
                    UserIO.ConsolePrintLn("Invalid Location: " +stringInput);
                }
            }
            LocationID = Fetch.LocationID(stringInput);
            SessionLocation = Fetch.LocationInfo(LocationID);
            UserIO.ConsolePrintLn("You've choosen the " + stringInput + " store.");
            */
            return true;
        }

        public void PrintAllLocations()
        {
            UserIO.ConsolePrintNumberedList(Fetch.StringListofAllLocations());
        }
        
        public bool DisplayInventoryAtLocation()
        {
            bool ValidInput = false;
            int index = 1;
            ValidInput = CheckIf.ValidLocation(SessionLocation.LocationId);
            if(ValidInput)
            {
                List<Inventory> LocationIventory = context.Inventories.Where(row => row.LocationId == SessionLocation.LocationId).ToList();
                IQueryable<Product> CurrentProduct;
                string StringBuilder = new string("");
                foreach (var row in LocationIventory)
                {
                    Console.Write(index++ + ": ");
                    CurrentProduct = context.Products.Where(item => item.ProductId == row.ProductId);
                    foreach(var item in CurrentProduct)
                    {
                        StringBuilder = item.ProductName + "  costs $" + item.Price + ".  (" + row.Amount + " remaining)";
                        Console.WriteLine(StringBuilder);

                    }
                }
                Console.WriteLine("End.");
            }
            else
            {
                Console.WriteLine("Not valid location.");
            }
            return true;
        }

        public bool AddProductToCart()
        {
            int amount = 0;
            int max_amount = 0;
            int Option = 0;
            int index = 0;
            Inventory desiredItem = new Inventory();
            Product ItemInfo = new Product();

            List<Inventory> LocationIventory = context.Inventories.Where(row => row.LocationId == SessionLocation.LocationId).ToList();
            Option = GetValid.NumberOption(LocationIventory.Count);
            index = Option;
            foreach(var item in LocationIventory)
            {
                Option--;
                if (Option == 0)
                {
                    max_amount = item.Amount;
                    desiredItem.LocationId = item.LocationId;
                    desiredItem.ProductId = item.ProductId;
                    ItemInfo = Fetch.ProductFromProductID(desiredItem.ProductId);
                    amount = GetValid.NumberOption("How many " + ItemInfo.ProductName + " would you like?", max_amount);
                    desiredItem.Amount = amount;
                    SessionCart.Add(desiredItem);
                }
            }

            return true;
        }

        public bool ViewItemsInCart()
        {
            Product CurrentCartItem = new Product();
            Console.WriteLine("You have the following items in your cart:");
            double CartTotal = 0;
            foreach(var item in SessionCart)
            {
                CurrentCartItem = Fetch.ProductFromProductID(item.ProductId);
                CartTotal += (CurrentCartItem.Price * item.Amount);
                Console.WriteLine(item.Amount + " " + CurrentCartItem.ProductName + " @ $" + CurrentCartItem.Price);
            }
            Console.WriteLine("Your Cart Total is $" + CartTotal);
            return true;
        }

        public bool ShowSessionLocation()
        {
            Console.WriteLine("Your are at the " + SessionLocation.LocationName + " Location");
            return true;
        }

        public bool EmptyShoppingCart()
        {
            SessionCart.Clear();
            return true;
        }

        public bool EditItemAmount()
        {
            int amount = 0;
            int max_amount = 0;
            int Option = 0;
            int index = 1;
            Inventory InventoryItem = new Inventory();
            Product CurrentItem = new Product();
            Console.Clear();
            ViewItemsInCart();
            Console.WriteLine();

            foreach(var item in SessionCart)
            {
                CurrentItem = Fetch.ProductFromProductID(item.ProductId);
                Console.WriteLine(index + ": " + CurrentItem.ProductName);
                index++;
            }

            Option = GetValid.NumberOption("Which cart item do you want to edit?", SessionCart.Count);
            foreach (var item in SessionCart)
            {
                Option--;
                if (Option == 0)
                {
                    InventoryItem = Fetch.InventoryFromProductID(item.ProductId, item.LocationId);
                    CurrentItem = Fetch.ProductFromProductID(item.ProductId);
                    max_amount = InventoryItem.Amount;
                    amount = GetValid.NumberOption("How many " + CurrentItem.ProductName + " would you like?", max_amount);
                    item.Amount = amount;
                }
            }
            return true;
        }

        public bool DeleteItem()
        {
            int Option = 0;
            Inventory InventoryItem = new Inventory();
            Product CurrentItem = new Product();

            Console.WriteLine();
            int index = 1;
            foreach (var item in SessionCart)
            {
                CurrentItem = Fetch.ProductFromProductID(item.ProductId);
                Console.WriteLine(index + ": " + CurrentItem.ProductName);
                index++;
            }
            Option = GetValid.NumberOption("Which cart item do you want to remove?", SessionCart.Count);
            index = Option - 1;
            SessionCart.RemoveAt(index);
            return true;
        }

        public bool GetProductDetails()
        {
            int Option = 0;
            List<Inventory> LocationIventory = context.Inventories.Where(row => row.LocationId == SessionLocation.LocationId).ToList();
            Product CurrentItem = new Product();

            Option = GetValid.NumberOption("Which product do you want to know about?", LocationIventory.Count());
          
            foreach (var item in LocationIventory)
            {
                Option--;
                if (Option == 0)
                {
                    CurrentItem = Fetch.ProductFromProductID(item.ProductId);
                    Console.WriteLine(CurrentItem.ProductName + " contains a " + CurrentItem.ProductDescription);
                }
            }
            return true;
        }

        public bool Checkout()
        {
            Console.WriteLine("Beginning CheckOut");

            Order thisOrder = new Order();
            thisOrder.LocationId = SessionLocation.LocationId;
            thisOrder.CustomerId = SessionUser.CustomerId;
            thisOrder.OrderDate = DateTime.Now;

            try
            {
                context.Orders.Add(thisOrder);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Unable to Insert Order.");
            };

            IEnumerable<Order> RecentOrders = context.Orders.Where(row => row.OrderDate == thisOrder.OrderDate).ToList();

            Console.WriteLine("Potentially the recorded Order:");
            foreach (var order in RecentOrders)
            {
                Console.WriteLine(order.OrderId + ": " + order.OrderDate);
            }

            
            foreach (var item in SessionCart)
            {
                List<Inventory> LocationIventory = context.Inventories.Where(row => row.LocationId == SessionLocation.LocationId && row.ProductId == item.ProductId).ToList();
                foreach(var stock in LocationIventory)
                {
                    stock.Amount -= item.Amount;
                }
            }

            context.SaveChanges();
            
            return true;
        }

        public bool ViewOrderHistoryByCustomer()
        {
            List<Order> Orders = context.Orders.Where(row => row.CustomerId == SessionUser.CustomerId).ToList();
            Location location = new Location();
            Customer Buyer = new Customer();
            foreach(var order in Orders)
            {
                location = Fetch.LocationInfo(order.LocationId);
                Buyer = Fetch.GetUserInfo(order.CustomerId);
                Console.WriteLine(order.OrderId + " " + Buyer.UserName + ": @ " + order.OrderDate + " @ " + location.LocationName);
            }
            return true;
        }

        public bool ViewOrderHistoryByLocation()
        {
            List<Order> Orders = context.Orders.Where(row => row.LocationId == SessionLocation.LocationId).ToList();
            Location location = new Location();
            Customer Buyer = new Customer();
            foreach (var order in Orders)
            {
                location = Fetch.LocationInfo(order.LocationId);
                Buyer = Fetch.GetUserInfo(order.CustomerId);
                Console.WriteLine(order.OrderId + " " + Buyer.UserName + ": @ " + order.OrderDate + " @ " + location.LocationName);
            }
            return true;
        }
    }
}