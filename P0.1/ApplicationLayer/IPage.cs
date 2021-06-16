using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer 
{
    interface IPage
    {
        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; }

        //public int Run();

    }

    public class WelcomePage : IPage
    {
        public WelcomePage(string pageName)
        {
            PageName = pageName;
            PageHeader = "Welcome to UMAI Treats. We hope to set hearts ablaze one meal at time.";
            MenuPrompt = "To get started, are you a:";
            //Console.WriteLine("Page: " + PageName + " created.");
            Options.Add("New Customer");
            Options.Add("Exisiting Customer");
        }

        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; } = new List<string>();

        //public Dictionary<int, Func<bool>> OptionActions = new Dictionary<int, System.Func<bool>>();
        //I eventually wanna try doing a dictionary with a delegate? I'm having trouble with static being need tho?
    }

    public class LogInPage : IPage
    {
        //Default Constructor
        public LogInPage(string pageName)
        {
            PageName = pageName;
            PageHeader = "User Log-In Menu";
            MenuPrompt = "No Menu Prompt";
            //MenuPrompt = "";

            Options.Add("Create an Account");
            Options.Add("Look up an Account by first name");
            Options.Add("Log-in");
            Options.Add("Exit");
        }

        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }

    public class ShoppingPage : IPage
    {
        public ShoppingPage()
        {
            PageName = "Home Menu";
            PageHeader = "Shopping Menu";
            MenuPrompt = "What would you like to do?";

            Options.Add("Change Location");
            Options.Add("View Products at this Location");
            Options.Add("View/Edit Cart");
            Options.Add("Checkout");
            Options.Add("LogOut");
            //Options.Add("View Your Order History");
            //Options.Add("View Store's Order History");
            Options.Add("Exit");
        }
        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }

    public class CartPage : IPage
    {
        public CartPage()
        {
            PageName = "Cart Menu";
            PageHeader = "Cart Menu";
            MenuPrompt = "What would you like to do?";

            Options.Add("Edit Cart");
            Options.Add("View Products at this Location");
            Options.Add("Checkout");
            Options.Add("LogOut");
            Options.Add("Exit");
        }
        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }

    public class EditCartPage : IPage
    {
        public EditCartPage()
        {
            PageName = "Edit Cart Menu";
            PageHeader = "Edit Cart Menu";
            MenuPrompt = "What would you like to do?";

            Options.Add("Edit Item Amount");
            Options.Add("Delete Item");
            Options.Add("View Products at this Location");
            Options.Add("Checkout");
            Options.Add("LogOut");
            Options.Add("Exit");
        }
        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }

    public class ProductPage : IPage
    {
        public ProductPage()
        {
            PageName = "Product Menu";
            PageHeader = "Product Menu";
            MenuPrompt = "What would you like to do?";

            Options.Add("View item details");
            Options.Add("Add item to cart");
            Options.Add("Return to Home Menu");
            Options.Add("LogOut");
            Options.Add("Exit");
        }
        public string PageName { get; set; }
        public string PageHeader { get; set; }
        public string MenuPrompt { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }
}
