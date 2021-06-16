using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer;

namespace P0._1._0
{
    public class MenuStateMachine
    {
        GetValid GetValid = new GetValid();
        WelcomePage StartPage = new WelcomePage("Start Page");
        LogInPage LogInPage = new LogInPage("Log-in Page");
        ShoppingPage ShoppingPage = new ShoppingPage();
        CartPage CartPage = new CartPage();
        ProductPage ProductPage = new ProductPage();
        EditCartPage EditCartPage = new EditCartPage();
        HistoryPage HistoryPage = new HistoryPage();
        
        Brain Logic = new Brain();
        public MenuStateMachine()
        {
        }

        public enum Menus
        {
            StartMenu = 0,
            LoginMenu = 1,
            Exit = -1,
            ShoppingMenu = 2,
            CartMenu = 3,
            ProductMenu = 4,
            EditCartMenu = 5,
            HistoryMenu = 6
        };
        
        public void Start()
        {
            Menus CurrentMenu = Menus.StartMenu;
            int Option = 0;
            while(CurrentMenu != Menus.Exit)
            {
                Console.Clear();
                UserIO.ConsolePrintLn("Welcome UMAI Treats. We hope to set hearts ablaze one dish at time.");
                Logic.ShowSessionLocation();
                switch (CurrentMenu)
                {
                    case Menus.StartMenu:
                        Option = GetValid.OptionChoice(StartPage.Options);
                        switch(Option)
                        {
                            case 1:
                                Console.WriteLine("Let's make you an account!~");
                                Logic.CreateUserAccount();
                                break;
                            case 2:
                                break;
                        }
                        CurrentMenu = Menus.LoginMenu;
                        break;
                    
                    case Menus.LoginMenu:
                        Option = GetValid.OptionChoice(LogInPage.Options);
                        switch(Option)
                        {
                            case 1:
                                Logic.CreateUserAccount();
                                break;
                            case 2:
                                Logic.LookUpAccountByFirstName();
                                break;
                            case 3:
                                if(Logic.LogIn())
                                {
                                    CurrentMenu = Menus.ShoppingMenu;
                                    Console.Clear();
                                    Logic.ChooseNewLocation();
                                }
                                break;
                            case 4:
                            default:
                                CurrentMenu = Menus.Exit;
                                break;
                        }
                        break;

                    case Menus.ShoppingMenu:
                        Option = GetValid.OptionChoice(ShoppingPage.Options);
                        switch(Option)
                        {
                            case 1:
                                Logic.ChooseNewLocation();
                                break;
                            case 2:
                                CurrentMenu = Menus.ProductMenu;
                                break;
                            case 3:
                                CurrentMenu = Menus.CartMenu;
                                break;
                            case 4:
                                Logic.Checkout(); 
                                Option = GetValid.OptionChoice(ShoppingPage.Options);
                                break;
                            case 5:
                                Logic.EmptyShoppingCart();
                                CurrentMenu = Menus.LoginMenu;
                                break;
                            case 6:
                            default:
                                CurrentMenu = Menus.Exit;
                                break;
                            case 7:
                                CurrentMenu = Menus.HistoryMenu;
                                break;
                        }
                        break;

                    case Menus.CartMenu:
                        Console.WriteLine("\nYour Cart: ");
                        Logic.ViewItemsInCart();
                        Console.WriteLine("\nUser Menu: ");
                        Option = GetValid.OptionChoice(CartPage.Options);
                        switch(Option)
                        {
                            case 1:
                                CurrentMenu = Menus.EditCartMenu;
                                break;
                            case 2:
                                Logic.DisplayInventoryAtLocation();
                                CurrentMenu = Menus.ProductMenu;
                                break;
                            case 3:
                                Logic.Checkout();
                                break;
                            case 4:
                                Logic.EmptyShoppingCart();
                                CurrentMenu = Menus.LoginMenu;
                                break;
                            case 5:
                            default:
                                CurrentMenu = Menus.Exit;
                                break;
                        }
                        break;

                    case Menus.EditCartMenu:
                        Console.WriteLine("\nYour Cart: ");
                        Logic.ViewItemsInCart();
                        Console.WriteLine("\nUser Menu: ");
                        Option = GetValid.OptionChoice(EditCartPage.Options);
                        switch (Option)
                        {
                            case 1:
                                Logic.EditItemAmount();
                                break;
                            case 2:
                                Logic.DeleteItem();
                                break;
                            case 3:
                                CurrentMenu = Menus.ProductMenu;
                                break;
                            case 4:
                                Logic.Checkout();
                                break;
                            case 5:
                                Logic.EmptyShoppingCart();
                                CurrentMenu = Menus.LoginMenu;
                                break;
                            case 6:
                            default:
                                CurrentMenu = Menus.Exit;
                                break;
                        }
                        break;

                    case Menus.ProductMenu:
                        Console.WriteLine("\nProduct Menu: ");
                        Logic.DisplayInventoryAtLocation();
                        Console.WriteLine("\nUser Menu: ");
                        Option = GetValid.OptionChoice(ProductPage.Options);
                        switch(Option)
                        {
                            case 1:
                                Logic.GetProductDetails();
                                break;
                            case 2:
                                Logic.AddProductToCart();
                                break;
                            case 3:
                                CurrentMenu = Menus.ShoppingMenu;
                                break;
                            case 4:
                                Logic.EmptyShoppingCart();
                                CurrentMenu = Menus.LoginMenu;
                                break;
                            case 5:
                            default:
                                CurrentMenu = Menus.Exit;
                                break;
                        }
                        break;

                    case Menus.HistoryMenu:

                        Console.WriteLine("\nOrder History By Customer:");
                        Logic.ViewOrderHistoryByCustomer();

                        Console.WriteLine("\nOrder History By Location:");
                        Logic.ViewOrderHistoryByLocation();
                        Console.WriteLine();

                        Option = GetValid.OptionChoice(ProductPage.Options);
                        switch (Option)
                        {
                            case 1:
                                CurrentMenu = Menus.ProductMenu;
                                break;
                            case 2:
                                CurrentMenu = Menus.ShoppingMenu;
                                break;
                            case 3:
                                Logic.EmptyShoppingCart();
                                CurrentMenu = Menus.LoginMenu;
                                break;
                            case 4:
                            default:
                                CurrentMenu = Menus.Exit;
                                break;
                        }
                        break;
                    
                    case Menus.Exit:
                    default:
                        break;

                }
            }
        }
    }
}
